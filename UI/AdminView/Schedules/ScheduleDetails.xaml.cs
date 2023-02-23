using BLApi;
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

namespace UI.AdminView.Schedules
{
    /// <summary>
    /// חלון שמציג את לוח הזמנים של קו ספציפי 
    /// </summary>
    public partial class ScheduleDetails : Window
    {
        private IBL B;

        public ObservableCollection<BO.LeavingLine> specificleavingLineList = new ObservableCollection<BO.LeavingLine>();
        int lineId;
        public ScheduleDetails(int lineId , IBL B1)
        {
            try
            {
                InitializeComponent();
                B = B1;
                // מציג את כל לוח הזמנים של הקו בתצוגה
                foreach (BO.LeavingLine item in B.GetAllLeavingLinesInSpecificLine(lineId))
                {
                    specificleavingLineList.Add(item);
                }
                lineSchedulesListView.ItemsSource = specificleavingLineList;
                this.lineId = lineId;
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
            catch (BO.BadLineIdStartingTimeIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }


        /// <summary>
        ///  פונקציה שמוחקת יציאת קו של קו ספציפי
        /// </summary>
        private void Button_Click_Delete_Leaving_Line(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this leaving line?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var fxElt = sender as FrameworkElement;
                    BO.LeavingLine leavingLineData = fxElt.DataContext as BO.LeavingLine;

                    // מחיקת יציאת הקו
                    B.DeleteLeavingLine(leavingLineData.LineId, leavingLineData.StartingTime);
                    
                    // הסרת יציאת הקו מהתצוגה
                    specificleavingLineList.Remove(leavingLineData);
                    lineSchedulesListView.Items.Refresh();

                }
                else
                {
                    return;
                }
            }
            catch (BO.BadLineIdStartingTimeIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
               

            }
        }

        /// <summary>
        ///  פונקציה להוספת יציאת קו חדשה עבור קו ספציפי 
        /// </summary>
        private void Button_Click_Adding_New_Leaving_Line(object sender, RoutedEventArgs e)
        {
            try
            {
                    AdminView.Schedules.AddLeavingLine add = new AdminView.Schedules.AddLeavingLine(lineId, B, this);
                    add.Show();
                    lineSchedulesListView.Items.Refresh();

            }
            catch (BO.BadLineIdStartingTimeIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
