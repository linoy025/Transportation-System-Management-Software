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

namespace UI.AdminView.AdjacentStations
{
    /// <summary>
    /// חלון לעדכון זמן ומרחק של  זוג  תחנות ספציפי 
    /// </summary>
    public partial class UpdateAdjacentStations : Window
    {
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;


        public BO.AdjacentStations AdjacentStations1 { get; set; }

        AdjacentStationsList adjacentStationsList2;
        /// <summary>
        ///  חלון שמאפשר עדכון בין זוג ספציפי של תחנות עוקבות  מקבל כפרמטר את
        ///  היישות תחנות עוקבות עליו לחצנו ברשימת כל זוגות התחנות העוקבות
        /// </summary>
        public UpdateAdjacentStations(BO.AdjacentStations adjacentStations, AdjacentStationsList adjacentStationsList, IBL B1)
        {
            InitializeComponent();
            adjacentStationsList2 = adjacentStationsList;
            AdjacentStations1 = adjacentStations;
            this.DataContext = adjacentStations;
            B = B1;
        }

        /// <summary>
        ///  פונקציה שמוודאת שהתוכן שנכנס הוא ספרות בלבד
        /// </summary>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
       /// פונקציה שמקבלת מצביע לאובייקט ששלח את האירוע    
        /// </summary>
        private void Button_Click_Confirm_Updating_AdjacentStations(object sender, RoutedEventArgs e)
        {
            try
            {
                // קבלת הנתונים מהמשתמש זמן ומרחק
               AdjacentStations1.AverageTravelTime = double.Parse(averageTravelTimeTextBox.Text);
                AdjacentStations1.DistanceBetweenTwoAdjacentSations = double.Parse(distanceBetweenTwoAdjacentSationsTextBox.Text);

                // עדכון הפרטים בקובץ
                B.UpdateAdjacentStations(AdjacentStations1);

                // עדכון הפרטים בתצוגה
                adjacentStationsList2.adjacentStations.Remove(AdjacentStations1);
                adjacentStationsList2.adjacentStations.Add(B.GetAdjacentStations(AdjacentStations1.StationId1, AdjacentStations1.StationId2));
                Close();
            }
            catch (BO.BadFirstStationIdSecondStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                // MessageBox.Show("The adjacent stations were updated successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
