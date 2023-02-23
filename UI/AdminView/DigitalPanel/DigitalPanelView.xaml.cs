using BLApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI.AdminView.DigitalPanel
{
    /// <summary>
    /// חלון לתצוגת קווים העוברים בתחנה בזמן אמת
    /// </summary>
    public partial class DigitalPanelView : Window
    {
        public ObservableCollection<BO.Station> stations = new ObservableCollection<BO.Station>();
        public ObservableCollection<BO.LineTrip> lineTrips = new ObservableCollection<BO.LineTrip>();

        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public TimeSpan Time { get; set; }
        private Stopwatch stopWatch;
        private bool isTimerRun;

        // תהליכון האחראי על הצגת השעון וקצב התקדמותו
        private BackgroundWorker timerworker;

        // תהליכון האחראי על שליחת השעה לפונקציה שמחשבת עוד כמה זמן ואילו מהקווים יגיעו לתחנה
        private BackgroundWorker digitalPanelWorker;

        private BO.Station station;
        public DigitalPanelView(IBL B1)
        {
            try
            {
                InitializeComponent();
                B = B1;
                // הצגת התחנות ברשימת התצוגה
                foreach (var id in B.GetAllStations())
                {
                    stations.Add(B.GetStation(id));
                }

                stationListView.ItemsSource = stations;
                Time = new TimeSpan();
                stopWatch = new Stopwatch();
                timerworker = new BackgroundWorker();
                timerworker.DoWork += Worker_DoWork;
                timerworker.ProgressChanged += Worker_ProgressChanged;
                timerworker.WorkerReportsProgress = true;
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
          

        }

        /// <summary>
        ///  לחיצה על רשומה מרשימת התחנות תוביל לתצוגת כל הקווים העוברים בה
        ///  מתאפשרת הצגת הקווים העוברים בכל התחנות כולן ומידע על הקווים שבדרך לתחנה
        ///    הודות ליצירת אובייקט תהליכון חדש בכל לחיצה על רשומה 
        /// </summary>
        private void stationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                station = (BO.Station)stationListView.SelectedItem;
                IEnumerable<BO.Line> lines = B.GetAllLinesInSpecificStation(station.StationId);
                lineListView.ItemsSource = lines;
                digitalPanelWorker = new BackgroundWorker();
                digitalPanelWorker.DoWork += Worker_DoWork_Panl;
                digitalPanelWorker.ProgressChanged += Worker_ProgressChanged_Panl;
                digitalPanelWorker.WorkerReportsProgress = true;
                digitalPanelWorker.RunWorkerAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        /// <summary>
        ///  לחיצה על הכפתור התחלה  מובילה להפעלת התהליכון שכולל עדכון השעון לשעה הנוכחית והמשך פעילותו
        ///  לחיצה על הכפתור סטופ מובילה להפסקת פעילות שני התהליכונים, שהרי השני תלוי בראשון
        /// </summary>
        private void startTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerRun)
            {
                startTimerButton.Content = "Stop";
                stopWatch.Restart();
                isTimerRun = true;
                timerworker.RunWorkerAsync();
            }
            else
            {
                startTimerButton.Content = "Start";
                stopWatch.Stop();
                isTimerRun = false;
                this.timerTextBlock.Text = "00:00:00";
            }
        }

        /// <summary>
        /// דיווח על שינויים שכולל תצוגת קצב התקדמות השעון
        /// </summary>
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { 
            string timerText = stopWatch.Elapsed.ToString();
            timerText = timerText.Substring(0, 8);
            Time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second - Time.Milliseconds) + TimeSpan.Parse(timerText);
            this.timerTextBlock.Text = Time.ToString();
        }


        /// <summary>
        /// כל עוד התהליכון פועל - לא לחצו סטופ על השעון יש דיווח על שינויים
        /// </summary>
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timerworker.ReportProgress(1);
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// כל עוד התהליכון של השעון פועל - לא לחצו סטופ , התהליכון השני שמקבל מידע על הגעת הקווים לתחנה, פועל
        /// </summary>
        private void Worker_DoWork_Panl(object sender, DoWorkEventArgs e)
        {
            while (!timerworker.CancellationPending)
            {
                digitalPanelWorker.ReportProgress(1);
                Thread.Sleep(10000);
            }
        }

        /// <summary>
        /// כל עוד התהליכון פועל  יש דיווח על שינויים, זמן הגעת האוטובוס לתחנה מתעדכן
        /// </summary>
        private void Worker_ProgressChanged_Panl(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                lineTripListView.ItemsSource = null;
                lineTrips.Clear();
                foreach (BO.LineTrip item in B.DigitalPanel(station.StationId, Time))
                {
                    lineTrips.Add(item);
                }
                lineTripListView.ItemsSource = lineTrips;
            }
            catch (BO.BadLineIdStartingTimeIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
          


        }

    }
}
