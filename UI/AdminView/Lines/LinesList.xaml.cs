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
using BLApi;
//using BO;
namespace UI.AdminView.Lines
{
    /// <summary>
    ///תצוגה של  הקווים עם  אפשרות להוספת קו חדש, מחיקה ועדכון של קווים קיימים
    /// </summary>
    /// 

    public partial class LinesList : Window
    {
        public ObservableCollection<BO.Line> lines = new ObservableCollection<BO.Line>();

        // BL המופע דרכו ניתן לגשת למתודות בשכבת ה
        private IBL B;
        public LinesList(IBL B1)
        {
            InitializeComponent();
            B = B1;
            //הצגת כל הקווים ברשימה  
            IEnumerable<int> lines1 = B.GetAllLines();
            try
            {

                foreach (int item in lines1)
                {
                    if (B.GetLine(item) != null)
                    {
                        lines.Add(B.GetLine(item));
                    }
                    
                }

                lineListView.ItemsSource = lines;
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
        /// פתיחת חלון חדש עבור  כפתור להוספת קו 
        /// </summary>       
        private void Button_Click_Adding_New_Line(object sender, RoutedEventArgs e)
        {
            AddLine add = new AddLine(B, this);
            add.Show();
        }

        /// <summary>
        ///  בלחיצה על הרשומה ברשימת הקווים נפתח חלון ובו פרטי הקו עם אפשרות להוספת ומחיקת תחנות מהקו
        /// </summary>
        private void LineListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //BO.Line line = (BO.Line)lineListView.MouseDoubleClick;
            BO.Line line = (BO.Line)lineListView.SelectedItem;
            LineDetails lineDetails = new LineDetails(line, this, B);
            _ = lineDetails.ShowDialog();
            lineListView.Items.Refresh();

        }


        /// <summary>
        ///  מחיקת קו ספציפי  על ידי לחיצה על כפתור 
        /// </summary>
        private void Button_Click_Delete_Line(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this line?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var fxElt = sender as FrameworkElement;
                    BO.Line lineData = fxElt.DataContext as BO.Line;
                    //  מחיקת הקו
                    B.DeleteLine(lineData.LineId);
                    // הסרת הקו מתצוגה
                    lines.Remove(lineData);

                    lineListView.Items.Refresh();

                }
                else
                {
                    return;
                }
            }
            catch (BO.BadLineIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///   פתיחת חלון לעדכון פרטי קו ספציפי על ידי לחיצה על כפתור לעדכון קו 
        /// </summary>
        private void Button_Click_Update_Line(object sender, RoutedEventArgs e)
        {
            try
            {
                var fxElt = sender as FrameworkElement;
                BO.Line lineData = fxElt.DataContext as BO.Line;
                int i = lines.IndexOf(lineData);

                // שליחת האינדקס של הקו ברשימת התצוגה על מנת שהעדכון יתבצע בדיוק באותה רשומה
                UpdateLine update = new UpdateLine(lineData, B, this, i);
                update.ShowDialog();
                // this.Close();
            }
            catch (BO.BadLineIdException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadFirstStationIdSecondStationIDException ex)
            {
                MessageBox.Show(ex.Message, "Operation Failure", MessageBoxButton.OK, MessageBoxImage.Error);

            }
           

        }

    }
}



