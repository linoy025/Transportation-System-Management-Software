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
    /// חלון לתצוגת קווי אוטובוס, ולחיצה על רשומה מובילה ללוח הזמנים של הקו
    /// </summary>
    public partial class SchedulesList : Window
    {
        public ObservableCollection<BO.Line> lines = new ObservableCollection<BO.Line>();
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public SchedulesList(IBL B1)
        {
            try
            {
                InitializeComponent();
                B = B1;
                IEnumerable<int> lines1 = B.GetAllLines();

                // תצוגת הקווים ברשימה
                foreach (int item in lines1)
                {
                    lines.Add(B.GetLine(item));
                }
                lineListView.ItemsSource = lines;
            }        
            catch (BO.BadLineIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadFirstStationIdSecondStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (BO.BadLineIdStartingTimeIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        /// <summary>
        /// לחיצה על רשומה מרשימת הקווים מובילה לחלון בו מופיע לוח הזמנים של האוטובוס
        /// </summary>
        private void LineListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Line line = (BO.Line)lineListView.SelectedItem;
            ScheduleDetails scheduleDetails = new ScheduleDetails(line.LineId, B);
            _ = scheduleDetails.ShowDialog();
            lineListView.Items.Refresh();
        }

    }
}
