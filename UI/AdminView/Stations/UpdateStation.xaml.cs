using BLApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI.AdminView.Stations
{
    /// <summary>
    /// חלון לעדכון פרטי תחנה
    /// </summary>
    public partial class UpdateStation : Window
    {

        private IBL B;
        public BO.Station station1 { get; set; }
        public int index { get; set; }
        StationsList stationsList;

        // מקבל כפרמטר את האובייט תחנה שנלחץ בחלון הקודם לשם עדכון
        public UpdateStation(BO.Station station, IBL B1, int i, StationsList stationsList1)
        {
            InitializeComponent();
            B = B1;
            station1 = station;
            this.DataContext = station;
            index = i;
            stationsList = stationsList1;
        }

        private void Button_Click_Confirm_Updating_Station(object sender, RoutedEventArgs e)
        {

            try
            {

                //var fxElt = sender as Button;
                //var station = fxElt.DataContext as BO.Station;
                //int id = station.StationId;
                //station1.StationId = station.StationId;
                station1.IsAvailableStation = (bool)isAvailableStationCheckBox.IsChecked;
                station1.Latitude = Latitude.Value;
                station1.Logtitude = Logtitude.Value;
                station1.StationAddress = stationAddressTextBox.Text;
                station1.StationName = stationNameTextBox.Text;

                // עדכון התחנה
                B.UpdateStation(station1);

                stationsList.stations.RemoveAt(index);
                stationsList.stations.Insert(index, B.GetStation(station1.StationId));

                // הוספת התחנה המעודכנת לתצוגה
                MessageBox.Show("The station was updated successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                // MessageBox.Show("The station doesn't exists in line", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // פונקציה שמוודאת שהוכנסו רק אותיות על ידי המשתמש
        private void StationNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
