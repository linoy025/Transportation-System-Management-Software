using BLApi;
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

namespace UI.AdminView.Buses
{
    /// <summary>
    /// חלון ובו תצוגת פרטי אוטובוס ספציפי
    /// </summary>
    public partial class BusDetails : Window
    { 
        public BO.Bus bus1 { get; set; }

        public BusDetails(BO.Bus bus)
        {
            InitializeComponent();
            bus1 = bus;
            grid1.DataContext = bus;
            
        }

      
    }
}
