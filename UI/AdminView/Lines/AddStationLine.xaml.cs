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

namespace UI.AdminView.Lines
{
    /// <summary>
    /// Interaction logic for AddStationLine.xaml
    /// </summary>
    public partial class AddStationLine : Window
    {
      //IBL B = BLFactory.GetBL();

        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;

        // רשימת תחנות פיזיות לצפייה 
        ObservableCollection<BO.Station> stations = new ObservableCollection<BO.Station>();

        // רשימת קווים לצפיה
        private BO.StationLine StationLine;
        LinesList linesList;
        LineDetails lineDetails;
        public AddStationLine(LineDetails lineDetails1, LinesList linesList1, BO.StationLine StationLine1 , IBL B1)
        {
                try
                {
                    InitializeComponent();                  
                    linesList = linesList1;
                    lineDetails = lineDetails1;
                    StationLine = StationLine1;
                    B = B1;
                // הצגת כל התחנות ברשימת התחנות לצפייה
                    foreach (var id in B.GetAllStations())
                    {
                        stations.Add(B.GetStation(id));
                    }
                    stationListView.ItemsSource = stations;
                }
                catch (BO.BadStationIdException ex)
                {

                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
        }
        
        private void Button_Click_Add_Station_to_Line(object sender, RoutedEventArgs e)
        {
            try
            { 

                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to add a new station after this station?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                switch (messageBoxResult)
                {
                    case MessageBoxResult.OK:

                        // הוספת תחנה לקו כוללת גם הוספת שתי ישויות של תחנות עוקבות
                        var fxElt = sender as FrameworkElement;
                        BO.Station SelectedStationToAdd = fxElt.DataContext as BO.Station;
                        StationLine.StationId = SelectedStationToAdd.StationId;
                        lineDetails.stationLines.Clear();
                        B.AddStationLine(StationLine);
                        foreach (var item in B.StationLineList(StationLine.LineId))
                        {
                            lineDetails.stationLines.Add(item);
                        }
                        lineDetails.listOfStationLineListView.Items.Refresh();                       
                       

                        Close();
                        break;
                    case MessageBoxResult.Cancel:
                        Close();
                        break;

                    default:
                        break;
                }
            }
            catch (BO.BadLineIdStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void stationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Station station = (BO.Station)stationListView.SelectedItem;

        }
    }
}
