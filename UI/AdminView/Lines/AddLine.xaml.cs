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

using System.Text.RegularExpressions;
namespace UI.AdminView.Lines
{
    /// <summary>
    /// חלון להוספת קו אוטובוס ובו פירוט על תחנות פיזיות הניתנות להוספה
    /// </summary>
    public partial class AddLine : Window
    {
        private IBL B;
        public BO.Line Line1 { get; set; }
        LinesList linesList;
        public AddLine(IBL B1, LinesList linesList1)
        {
            try
            {
                InitializeComponent();
                B = B1;
                linesList = linesList1;
                // הצגת מספרי תחנה לבחירה עבור התחנה הראשונה והאחרונה בקו 
                firstStationIdComboBox.ItemsSource = B.GetAllStations();
                lastStationIdComboBox.ItemsSource = B.GetAllStations();

                // הצגת  קוד התחנה הראשונה  והאחרונה בקומבו בוקס
                firstStationIdComboBox.SelectedIndex = 0;
                lastStationIdComboBox.SelectedIndex = 0;

                // תצוגת האזורים הניתנים לבחירה 
                areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.AREA));

                // הצגת האזור הראשון בקומבו בוקס
                areaComboBox.SelectedIndex = 0;

                // תצוגת תחנות למידע על הוספת קו כדי שהמשתמש ידע את פרטי התחנה על מספר התחנה בקומבו בוקס
                ObservableCollection<BO.Station> stations = new ObservableCollection<BO.Station>();

                // קבלת  התחנות והצגתן בגריד 
                foreach (var id in B.GetAllStations())
                {
                    stations.Add(B.GetStation(id));
                }
                stationDataGrid.DataContext = stations;
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

        /// <summary>
        ///  פונקציה שמוודאת שהתוכן שנכנס הוא ספרות בלבד
        /// </summary>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

      

        /// <summary>
        ///  פונקציה שמקבלת פרטי קו חדש מהמשתמש  עבור הוספתו לרשימת הקווים
        /// </summary>
        private void Button_Click_Confirm_Adding_Line(object sender, RoutedEventArgs e)
        {
            try
            {
                Line1 = new BO.Line();
                int temp;
                bool success = int.TryParse(lineNumberTextBox.Text, out temp);
                Line1.LineNumber = temp;
                Line1.FirstStationId = (int)firstStationIdComboBox.SelectedItem;
                Line1.LastStationId = (int)lastStationIdComboBox.SelectedItem;
                Line1.IsUrbanLine = (bool)isUrbanLineCheckBox.IsChecked;
                Line1.IsNightLine = (bool)isNightLineCheckBox.IsChecked;
                Line1.IsAvailableLine = (bool)isAvailableLineCheckBox.IsChecked;
                Line1.Area = (BO.Enums.AREA)areaComboBox.SelectedItem;

                Line1.ListOfStationLine = new List<BO.StationLine>();
                Line1.ListOfStationLine.Add(new BO.StationLine { StationId = Line1.FirstStationId });
                Line1.ListOfStationLine.Add(new BO.StationLine { StationId = Line1.LastStationId });
               
                //// בדיקה אם תחנה ראשונה שונה מאחרונה
                if (Line1.FirstStationId != Line1.LastStationId && success)
                {
                    B.AddLine(Line1);
                    linesList.lines.Add(B.GetLine(Line1.LineId));
                    MessageBox.Show("The line was added successfully", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Last station has to be different from the first station", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                    
               
            }
            catch (BO.BadLineIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);              
            }
            catch (BO.BadFirstStationIdSecondStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);              
            }

        }
    }
}
