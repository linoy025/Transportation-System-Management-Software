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


    namespace UI.AdminView.Schedules
    {

    /// <summary>
    /// חלון שמאפשר להוסיף יציאת קו חדשה  עבור קו ספציפי  
    /// </summary>
        public partial class AddLeavingLine : Window
        {
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public BO.LeavingLine LeavingLine1 { get; set; }

        ScheduleDetails scheduleDetails;
        ObservableCollection<BO.LeavingLine> leavingLines = new ObservableCollection<BO.LeavingLine>();

        int lineId;
        public AddLeavingLine(int lineId, IBL B1, ScheduleDetails scheduleDetails1) 
        {
            InitializeComponent();
            B = B1;
            scheduleDetails = scheduleDetails1;
            LeavingLine1 = new BO.LeavingLine() { LineId = lineId, StartingTime = new TimeSpan(00, 00, 00), IsAvailableLeavingLine = true };
            this.lineId = lineId;
            gridViewLeavingLine.DataContext = LeavingLine1;
        }

        // פונקציה שמוודאת שהמשתמש הכניס ספרות בלבד
        private void Time_Validation_TextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9:]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        ///  הוספת יציאת קו על ידי הכנסת שעה מהמשתמש
        /// </summary>
        private void Button_Click_Confirm_Adding_Leaving_Line(object sender, RoutedEventArgs e)
        {
            try
            {
                // הוספה לרשימת יציאות הקו 
                B.AddLeavingLine(LeavingLine1);

                // הוספה לרשימה בתצוגה
                scheduleDetails.specificleavingLineList.Add(B.GetLeavingLine(LeavingLine1.LineId, LeavingLine1.StartingTime));

                this.Close();
            }
            catch (BO.BadLineIdStartingTimeIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
