using BLApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI.AdminView.DigitalPanel;

namespace UI.AdminView.AdminAccess
{
    /// <summary>
    /// חלון ובו תצוגת האפשרויות עבור יישות מנהל
    /// </summary>
    public partial class AdminOptions : Window
    {
        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public AdminOptions(IBL B1)
        {
            InitializeComponent();
            B = B1;
        }

        /// <summary>
        ///  כפתור המוביל לתצוגת קווים
        /// </summary>
        private void Button_Click_Lines_List_Display(object sender, RoutedEventArgs e)
        {
            AdminView.Lines.LinesList add = new AdminView.Lines.LinesList(B);
            add.Show();
        }


        /// <summary>
        ///  כפתור המוביל לתצוגת תחנות
        /// </summary>
        private void Button_Click_Stations_List_Display(object sender, RoutedEventArgs e)
        {
            Stations.StationsList add = new Stations.StationsList(B);
           add.Show();
        }

        /// <summary>
        ///  כפתור המוביל לתצוגת אוטובוסים
        /// </summary>
        private void Button_Click_Buses_List_Display(object sender, RoutedEventArgs e)
        {
            AdminView.Buses.BusesList add = new AdminView.Buses.BusesList(B);
            add.Show();
        }

        /// <summary>
        ///  כפתור המוביל לתצוגת תחנות עוקבות
        /// </summary>
        private void Button_Click_Adjacent_Stations_List_Display(object sender, RoutedEventArgs e)
        {
            AdminView.AdjacentStations.AdjacentStationsList add = new AdminView.AdjacentStations.AdjacentStationsList(B);
            add.Show();
        }


        /// <summary>
        ///  כפתור המוביל לתצוגת לוחות זמנים של קווים
        /// </summary>
        private void Button_Click_Lines_Schedules_List_Display(object sender, RoutedEventArgs e)
        {
            AdminView.Schedules.SchedulesList add = new AdminView.Schedules.SchedulesList(B);
            add.Show();

        }

        /// <summary>
        ///  כפתור המוביל לתצוגת הגעת אוטובוסים לתחנה בזמן אמת
        /// </summary>
        private void Button_Click_Digital_Panel_Display(object sender, RoutedEventArgs e)
        {
            DigitalPanelView add = new DigitalPanelView(B);
            add.Show();
        }
    }
}
