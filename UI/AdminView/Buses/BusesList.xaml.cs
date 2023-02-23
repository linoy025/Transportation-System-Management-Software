using BLApi;
//using BO;
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

namespace UI.AdminView.Buses
{
    /// <summary>
    /// חלון של תצוגת אוטובוסים ברשימה
    /// </summary>
    public partial class BusesList : Window
    {
        private IBL B;

        public ObservableCollection<BO.Bus> buses = new ObservableCollection<BO.Bus>(); 
        public BusesList(IBL B1)
        {
            try
            {
                InitializeComponent();
                B = B1;
                var busesList = B.GetAllBuses().ToList();

                // הצגת האוטובוסים ברשימת התצוגה
                foreach (BO.Bus item in B.GetAllBuses())
                {
                    busesList.Add(item);
                }
                busListView.ItemsSource = busesList;
            }
            catch (BO.BadBusIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }



        }


        /// <summary>
        ///  פונקציה שפותחת חלון ובו פרטי אוטובוס ספציפי הודות ללחיצה על רשומה ברשימת האוטובוסים 
        /// </summary>
        private void BusListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Bus bus1 = (BO.Bus)busListView.SelectedItem;
            BusDetails busDetails = new BusDetails(bus1);
            _ = busDetails.ShowDialog();
        }
    }
}
