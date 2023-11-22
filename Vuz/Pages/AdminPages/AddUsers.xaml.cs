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

namespace Vuz.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Page
    {
        public AddUsers()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Users.Count(x => x.Login == txbName.Text) > 0)
            {
                System.Windows.MessageBox.Show("Пользователь с таким логином уже есть!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            else
            {
                if (txbName.Text == null | txbName.Text.Trim() == "" | txbPsw.Text == null | txbPsw.Text.Trim() == "" | txbIdRole.Text == null | txbIdRole.Text.Trim() == "")
                {
                    System.Windows.MessageBox.Show("Заполните все поля!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                }
                else
                {
                    try
                    {

                        User userObj = new User()
                        {
                            Login = txbName.Text,
                            Password = txbPsw.Text,
                            Id_Role = Int32.Parse(txbIdRole.Text),
                            image = "\\picture.png"


                        };

                        DbConnect.entObj.Users.Add(userObj);
                        DbConnect.entObj.SaveChanges();

                        System.Windows.MessageBox.Show("Пользователь добавлен!",
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Ошибка добавления пользователя: " + ex.Message.ToString(),
                        "Критический сбой работы приложения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
