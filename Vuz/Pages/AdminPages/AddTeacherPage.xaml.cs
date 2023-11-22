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
using System.Xml.Linq;
using Vuz.AppServices;
using Vuz.Data;

namespace Vuz.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        public AddTeacherPage()
        {
            InitializeComponent();
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (DbConnect.entObj.Teachers.Count(x => x.FIO == txbFio.Text) > 0)
            {
                System.Windows.MessageBox.Show("Такой преподаватель уже есть!",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }
            else
            {
                if (txbFio.Text == null | txbFio.Text.Trim() == "" | txbCountChildren.Text == null | txbCountChildren.Text.Trim() == "" | txbSalary.Text == null | txbSalary.Text.Trim() == ""  | txbScWork.Text.Trim() == "" | txbScWork.Text == null)
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

                        Teacher TeacherObj = new Teacher()
                        {
                            FIO = txbFio.Text,
                            Salary = Int32.Parse(txbSalary.Text),
                            CountChildren = Int32.Parse(txbCountChildren.Text),
                            ScWordks = txbScWork.Text,
                            Aspirant = CmbAspirant.Text,
                            AcademicRanksId = Int32.Parse(CmbCategory.Text),
                            ScTopicsId = 2,
                            GenderId = Int32.Parse(CmbGender.Text),
                            CategoryId = 1,
                            DepartmentId = Int32.Parse(CmbDepatrment.Text)
                              

                        };

                        DbConnect.entObj.Teachers.Add(TeacherObj);
                        DbConnect.entObj.SaveChanges();

                        System.Windows.MessageBox.Show("Преподаватель добавлен!",
                            "Уведомление",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show("Ошибка добавления преподавателя: " + ex.Message.ToString(),
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
            try
            {
                CmbCategory.ItemsSource = DbConnect.entObj.AcademicRanks.ToList();
                CmbCategory.DisplayMemberPath = "Id";

                CmbDepatrment.ItemsSource = DbConnect.entObj.Departments.ToList();
                CmbDepatrment.DisplayMemberPath = "Id";

                CmbGender.ItemsSource = DbConnect.entObj.Genders.ToList();
                CmbGender.DisplayMemberPath = "Id";

                
                


            }
            catch (Exception except)
            {

                System.Windows.MessageBox.Show(except.Message, "Что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void AspirantYesNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ScTopics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
