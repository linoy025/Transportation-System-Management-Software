using System;
using System.Collections.Generic;
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
namespace UI.AdminView.Stations
{
    /// <summary>
    /// חלון ובו פרטי תחנה פיזית
    /// </summary>
    public partial class StationDetails : Window
    {
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public BO.Station station1 { get; set; }
        public StationDetails(BO.Station station, IBL B1)
        {
            try
            {
                InitializeComponent();
                B = B1;
                station1 = station;
                grid1.DataContext = station1;

                // הצגת כל הקווים העוברים בתחנה
                IEnumerable<BO.Line> lines = B.GetAllLinesInSpecificStation(station1.StationId);
                listOfLinesThatPassInStationListView.ItemsSource = lines;
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
