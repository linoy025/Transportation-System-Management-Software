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

namespace UI.AdminView.AdminAccess
{
    /// <summary>
    /// חלון להכנסת פרטי משתמש עבור יישות מנהל 
    /// </summary>
    public partial class AdminLogIn : Window
    {
        // יצירת המופע באופן חד פעמי   דרכו יהיה ניתן לגשת לשכבת ה BL 
        private IBL B = BLFactory.GetBL();
        public AdminLogIn()
        {
           InitializeComponent();
        }

        /// <summary>
        ///  כפתור שמוביל למסך ובו כפתורים עבור תצוגות רלוונטיות ליישות מנהל
        /// </summary>
        private void Button_Click_Admin_Options(object sender, RoutedEventArgs e)
        {
            try
            {


                BO.User user = B.GetUser(textBoxEmail.Text.ToString());
                if (user != null)
                {
                    if (user.UserPassword == passwordBox1.Password.ToString() && user.IsAvailableUser && user.IsAdmin)
                    {
                        AdminOptions add = new AdminOptions(B);
                        add.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password, please try again", "ErrorPassword", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("User does not exist", "ErrorUser", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (BO.BadUserIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
    }
}
