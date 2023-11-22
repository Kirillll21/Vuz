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
using Vuz.AppServices;
using Vuz.Data;

namespace Vuz.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for AddStudentsPage.xaml
    /// </summary>
    public partial class AddStudentsPage : Page
    {
        public AddStudentsPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Students.Count(x => x.FIO == txbFio.Text) > 0)
            {
                System.Windows.MessageBox.Show("Такой студент уже есть!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            else
            {
                if (txbFio.Text == null | txbFio.Text.Trim() == "" | txbAge.Text == null | txbAge.Text.Trim() == "" | txbStipendSize.Text == null | txbStipendSize.Text.Trim() == "" | txbStipendReason.Text == null | txbStipendReason.Text.Trim() == "" | txbCountChildren.Text == null | txbCountChildren.Text.Trim() == "")
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

                        Student StudentObj = new Student()
                        {
                            FIO = txbFio.Text,
                            Age = Int32.Parse(txbAge.Text),
                            Children = Int32.Parse(txbCountChildren.Text),
                            StipendSize = Int32.Parse(txbStipendSize.Text),
                            StipendReason = txbStipendReason.Text,
                            GroupId = Int32.Parse(CmbFilterGroup.Text),
                            GenderId = Int32.Parse(CmbFilterGender.Text)

                        };

                        DbConnect.entObj.Students.Add(StudentObj);
                        DbConnect.entObj.SaveChanges();

                        System.Windows.MessageBox.Show("Студент добавлен!",
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Ошибка добавления студента: " + ex.Message.ToString(),
                        "Критический сбой работы приложения",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void CmbFilterGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }

        private void CmbFilterGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CmbFilterGroup.ItemsSource = DbConnect.entObj.Groups.ToList();
            CmbFilterGroup.DisplayMemberPath = "Id";

            CmbFilterGender.ItemsSource = DbConnect.entObj.Genders.ToList();
            CmbFilterGender.DisplayMemberPath = "Id";

            CmbFilterGroup.SelectedIndex = 0;
            CmbFilterGender.SelectedIndex = 0;




        }

        private void CmbFilterGroup_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
