using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLApi;
using UI;


namespace UI.AdminView.Stations
{
    /// <summary>
    /// חלון לתצוגת תחנות ואפשרות לעדכון ומחיקה של תחנה ספציפית והוספת תחנה חדשה
    /// </summary>
    public partial class StationsList : Window
    {
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public BO.Station Station1 { get; set; }
        public ObservableCollection<BO.Station> stations = new ObservableCollection<BO.Station>();
        
        public StationsList(IBL B1)
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
            }          
             catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

     


        /// <summary>
        ///  בלחיצה על כפתור ההוספה נפתח חלון להוספת תחנה חדשה 
        /// </summary>
        private void Button_Click_Adding_New_Station(object sender, RoutedEventArgs e)
        {
            AdminView.Stations.AddStation add = new AdminView.Stations.AddStation(B, this);
            add.Show();
            stationListView.Items.Refresh();
        }

        /// <summary>
        ///  לחיצה על הרשומה ברשימת התחנות מובילה לפתיחת חלון חדש ובו פרטי התחנה
        /// </summary>
        private void StationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Station station = (BO.Station)stationListView.SelectedItem;
            StationDetails stationDetails = new StationDetails(station, B);
            _ = stationDetails.ShowDialog();
        }

        /// <summary>
        ///  לחיצה על הכפתור לעדכון תחנה ספציפית מוביל לפתיחת חלון חדש ובו אפשרות לעדכון התחנה
        /// </summary>
        private void Button_Click_Update_Station(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            BO.Station stationData = fxElt.DataContext as BO.Station;

            int i = stations.IndexOf(stationData);
            UpdateStation update = new UpdateStation(stationData, B, i, this);
            update.Show();

        }

        /// <summary>
        ///  לחיצה על הכפתור למחיקת  תחנה ספציפית מוביל למחיקת התחנה עם הודעה לאישור המחיקה
        /// </summary>
        private void Button_Click_Delete_Station(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this station?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var fxElt = sender as FrameworkElement;
                    BO.Station stationData = fxElt.DataContext as BO.Station;
                    // מחיקת התחנה
                    B.DeleteStation(stationData.StationId);

                    // הסרת התחנה מהתצוגה
                    stations.Remove(stationData);
                    stationListView.Items.Refresh();
                }
                else
                {
                    return;
                }
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }



}





