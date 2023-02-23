using BLApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace UI.AdminView.Lines
{
    /// <summary>
    /// חלון לעדכון פרטי קו 
    /// </summary>
    public partial class UpdateLine : Window
    {
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;  
        public int Id { get; set; }
        public BO.Line line1 { get; set; }
        public int  IndexOfLine{ get; set; }

        LinesList linesList;
        public UpdateLine(BO.Line line, IBL B1, LinesList linesList1, int index)
        {
            try
            {
                InitializeComponent();
                B = B1;
                linesList = linesList1;
                IndexOfLine = index;
                line1 = line;
                // תצוגת האזורים הניתנים לבחירה 
                areaComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.AREA));

                // הצגת האזור הראשון בקומבו בוקס
                areaComboBox.SelectedIndex = 0;
            }
            catch (BO.BadStationIdException ex)
            {

                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // פונקציה שמוודאת כי הוכנסו מספרים בלבד
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        ///  פונקציה שמעדכנת את פרטי הקו על פי בחירת המשתמש 
        /// </summary>
        private void Button_Click_Confirm_Updating_Line(object sender, RoutedEventArgs e)
        {
            try
            {
                line1.LineNumber = int.Parse(lineNumberTextBox.Text);
                line1.IsUrbanLine = (bool)isUrbanLineCheckBox.IsChecked;
                line1.IsNightLine = (bool)isNightLineCheckBox.IsChecked;
                line1.Area = (BO.Enums.AREA)areaComboBox.SelectedItem;
                B.UpdateLine(line1);

                // עדכון הקו על פי אינדקס על מנת שהעדכון יתבצע בדיוק ברשומה המתאימה
                linesList.lines.RemoveAt(IndexOfLine);
                linesList.lines.Insert(IndexOfLine, B.GetLine(line1.LineId));
                Close();
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
    }
}
