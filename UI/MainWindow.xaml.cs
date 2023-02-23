using BLApi;
using BO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// חלון ראשי עם שני כפתורים עבור משתמש ומנהל רשומים
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

     
        /// <summary>
        /// בלחיצה על הכפתור נפתח חלון חדש ובו כניסת מנהל 
        /// </summary>
        private void Button_Click_Admin_View(object sender, RoutedEventArgs e)
        {
            AdminView.AdminAccess.AdminLogIn add = new AdminView.AdminAccess.AdminLogIn();;
            add.Show();
            this.Close();

        }
        /// <summary>
        /// בלחיצה על הכפתור נפתח חלון חדש ובו כניסת משתמש נוסע  
        /// </summary>
        private void Button_Click_User_View(object sender, RoutedEventArgs e)
        {
            UserView.UserAccess.UserLogIn add = new UserView.UserAccess.UserLogIn();
            //add.ShowDialog();
            add.Show();
            this.Close();

        }
    }
}
