using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vuz.AppServices;
using Vuz.Data;
using Vuz.Pages.AdminPages.AdminListPages;

namespace Vuz.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();

            UserList.ItemsSource = DbConnect.entObj.Users.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void CmbFilter_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbSort_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDelStd_Click(object sender, RoutedEventArgs e)
        {
            var userForRemoving = UserList.SelectedItems.Cast<User>().ToList();

            var cancel = System.Windows.Forms.MessageBox.Show("Вы подтверждаете удаление?",
                            "Подтверждение",
                            MessageBoxButtons.OKCancel);
            if (DialogResult.Cancel == cancel)
            {
                FrameApp.frmObj.Navigate(new UserListPage());
            }
            else
            {

                try
                {
                    DbConnect.entObj.Users.RemoveRange(userForRemoving);
                    DbConnect.entObj.SaveChanges();
                    System.Windows.MessageBox.Show("Данные удалены");

                    UserList.ItemsSource = DbConnect.entObj.Users.ToList();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void btnAddStd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddUsers());
        }
    }
}
