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

namespace UI.AdminView.AdjacentStations
{
    /// <summary>
    /// חלון תצוגת התחנות העוקבות עם אפשרות לעדכון זמן ומרחק בין זוג תחנות עוקבות
    /// כאשר מתווספת תחנה לקו  מתווספות גם שתי ישויות של תחנות עוקבות
    /// כאשר נמחקת  תחנה פיזית, נמחקות גם תחנות הקו וכתוצאה מכך   מתווספת ישות  של תחנות עוקבות
    /// וכאן ניתן לעדכן את הזמן והמרחק בינהן
    /// </summary>
    public partial class AdjacentStationsList : Window
    {
        public ObservableCollection<BO.AdjacentStations> adjacentStations = new ObservableCollection<BO.AdjacentStations>();
        public static Random Random = new Random(DateTime.Now.Millisecond);
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public AdjacentStationsList(IBL B1)
        {
            try
            {
                InitializeComponent();
                B = B1;
                
                // הצגת התחנות העוקבות ברשימת התצוגה
                var adjacentStationsList = B.GetAllAdjacentStations().ToList();
                //foreach (BO.AdjacentStations item in B.GetAllAdjacentStations())
                //{
                //    item.AverageTravelTime = Random.Next(3, 15);
                //    item.DistanceBetweenTwoAdjacentSations = Random.Next(7, 17);
                //    B.UpdateAdjacentStations(item);
                //}
                foreach (BO.AdjacentStations item in B.GetAllAdjacentStations())
                {
                    adjacentStations.Add(item);
                }
               
                adjacentStationsListView.ItemsSource = adjacentStations;
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
        ///  כפתור לפתיחת חלון חדש עבור עדכון זמן ומרחק בין זוג תחנות עוקבות ספציפי 
        /// </summary>
        private void Button_Click_Update_Distance_And_Travel_Time(object sender, RoutedEventArgs e)
        {
            var fxElt = sender as FrameworkElement;
            BO.AdjacentStations adjacentStationsData = fxElt.DataContext as BO.AdjacentStations;

            UpdateAdjacentStations update = new UpdateAdjacentStations(adjacentStationsData, this, B);
            update.Show();
        }
    }
}
