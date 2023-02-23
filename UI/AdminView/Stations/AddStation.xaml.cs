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
using UI.AdminView.Lines;

namespace UI.AdminView.Stations
{
    /// <summary>
    /// חלון להוספת תחנה חדשה
    /// </summary>
    public partial class AddStation : Window
    {
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        StationsList stationsList;
        public BO.Station Station1 { get; set; }
        public AddStation(IBL B1, StationsList stationsList1)
        {
            InitializeComponent();
            B = B1;
            stationsList = stationsList1;
        }

        // פונציה שמוודאת שהוכנסו רק אותיות 
        private void StationNameAndAddress_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }

        // פונציה שמוודאת שהוכנסו רק ספרות 
        private void NumberValidation_TextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // כפתור להוספת תחנה אחרי הזנת כל הפרטים על ידי המשתמש
        private void Button_Click_Add_New_Station(object sender, RoutedEventArgs e)
        {

            try
            {
                Station1 = new BO.Station();
                Station1.StationId = int.Parse(stationIdTextBox.Text);
                Station1.IsAvailableStation = (bool)isAvailableStationCheckBox.IsChecked;
                Station1.Latitude = Latitude.Value;
                Station1.Logtitude = Logtitude.Value;
                Station1.StationAddress = stationAddressTextBox.Text;
                Station1.StationName = stationNameTextBox.Text;

                // הוספת התחנה לרשימת התחנות הפיזיות
                B.AddStation(Station1);

                // הוספת התחנה לתצוגה
                stationsList.stations.Add(B.GetStation(Station1.StationId));
                Close();

                // אם מספר התחנה הזה לא נמצא ברשימת התחנות הפיזיות היא מתווספת לרשימה
                if (Station1.StationId == Station1.StationId)
                {
                    MessageBox.Show("The station was added successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
            }
            catch (BO.BadStationIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
               
            } 
        }

      
    }
}
