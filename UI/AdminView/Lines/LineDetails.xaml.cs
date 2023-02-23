
using BLApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace UI.AdminView.Lines
{
    /// <summary>
    /// חלון לתצוגת פרטי קו ספציפי עם תצוגת התחנות שלו ואפשרות למחיקתן ולהוספת תחנות נוספות בקו  
    /// </summary>
    /// 
    public partial class LineDetails : Window
    {
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public ObservableCollection<BO.StationLine> stationLines = new ObservableCollection<BO.StationLine>();
        public BO.StationLine stationLine { get; set; }
        public BO.Line Line1 { get; set; }
        public bool RunW { get; private set; }

        LinesList linesList;
        private BackgroundWorker worker;

        public LineDetails(BO.Line line, LinesList linesList1, IBL B1)
        {
            InitializeComponent();
            B = B1;
            //worker = new BackgroundWorker();
            //worker.DoWork += Worker_DoWork;
            //worker.ProgressChanged += Worker_ProgressChanged;
            //worker.WorkerReportsProgress = true;
           Line1 = line;
            grid1.DataContext = Line1;
            linesList = linesList1;
            try
            { 
                // הצגת תחנות הקו של הקו הספציפי
                if(line != null)
                { 
                    foreach (var item in line.ListOfStationLine)
                    {
                        stationLines.Add(item);
                    }
                    listOfStationLineListView.ItemsSource = stationLines;
                }
            }
            catch (BO.BadLineIdStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadFirstStationIdSecondStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (BO.BadStationIdException ex)
            {

                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                TimeCaming.ItemsSource = B.HelpCalculateArrivingTimeToStation(stationLine.LineId, stationLine.StationId, new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// כל עוד התהליכון פועל - לא לחצו סטופ על השעון יש דיווח על שינויים
        /// </summary>
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!RunW)
            {
                worker.ReportProgress(1);
                Thread.Sleep(30000);
            }
            
        }

       

        //public LineDetails(BO.StationLine stationLines1, BO.Line Line)
        //{
        //    InitializeComponent();
        //    Line1 = Line;
        //    grid1.DataContext = Line1;
        //    foreach (var item in Line.ListOfStationLine)
        //    {
        //        stationLines.Add(item);
        //    }
        //    listOfStationLineListView.ItemsSource = stationLines;
        //    stationLine = stationLines1;
        //}

        /// <summary>
        ///  כפתור המוביל למחיקת תחנת קו מקו
        /// </summary>
        private void Button_Click_Delete_Station_from_Line(object sender, RoutedEventArgs e)
        {

            try
            {
                var fxElt = sender as FrameworkElement;
                BO.StationLine SelectedStationLineToDelete = fxElt.DataContext as BO.StationLine;
                int num = SelectedStationLineToDelete.LineId;
                int count =  B.GetNumberStationLine(num);

                // בדיקה האם התחנה המתבקשת למחיקה אינה התחנה הראשונה או האחרונה - תחנות שאינן ניתנות למחיקה
                if (SelectedStationLineToDelete.StationInLineLocation != 0 && SelectedStationLineToDelete != stationLines[stationLines.Count - 1])
                { 
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this station line?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                      

                        // מחיקת תחנת קו מרשימת תחנות הקו
                        B.DeleteStationLine(Line1.LineId, SelectedStationLineToDelete.StationId);

                        // הסרה מתצוגה
                        stationLines.Clear();
                        //Line1.ListOfStationLine.RemoveAll(x => x.StationId == SelectedStationLineToDelete.StationId); 
                        foreach (BO.StationLine item in B.StationLineList(Line1.LineId))
                        {
                            stationLines.Add(item);
                        }                                                                                  
                        listOfStationLineListView.Items.Refresh();
                        MessageBox.Show("The station was deleted successfully from line", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                        //Close();
                    }
                }
                else
                {
                    MessageBox.Show("First and Last station cannot be deleted", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                }
              
            }

            catch (BO.BadLineIdStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        ///  כפתור המוביל להוספת תחנת קו לקו
        /// </summary>
        private void add_Click(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            BO.StationLine SelectedStationLineToAdd = fxElt.DataContext as BO.StationLine;
            if (SelectedStationLineToAdd != null)
            {
                // אין אפשרות להוסיף תחנת קו אחרי התחנה האחרונה בקו
                if (SelectedStationLineToAdd == stationLines[stationLines.Count - 1])
                {
                    MessageBox.Show("Last Station Cannot Be Replaced", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // הוספת תחנת קו לקו באינדקס רצוי מסויים 
                    BO.StationLine stationLine = new BO.StationLine();
                    stationLine.PreviousStationId = SelectedStationLineToAdd.StationId;

                    foreach (BO.StationLine item in stationLines)
                    {
                        if (item.StationInLineLocation == SelectedStationLineToAdd.StationInLineLocation + 1)
                        {
                            stationLine.NextStationId = item.StationId;
                            stationLine.StationInLineLocation = item.StationInLineLocation;
                        }
                    }
                    stationLine.IsAvailableStationInLine = true;
                    stationLine.LineId = Line1.LineId;
                    stationLine.DropOffStation = true;
                    stationLine.UploadStation = true;
                    AddStationLine add = new AddStationLine(this, linesList, stationLine , B);
                    add.Show();
                }
            }
            
        }

        

        private void listOfStationLineListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int i = listOfStationLineListView.SelectedIndex;
            stationLine = (BO.StationLine)listOfStationLineListView.SelectedItem;
           
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        private void LineListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           
            // אם התחנה שנבחרה להוספה היא התחנה הראשונה
        }


    }
}















