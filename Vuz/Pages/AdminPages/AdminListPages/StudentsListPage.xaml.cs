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

namespace Vuz.Pages.AdminPages.AdminListPages
{
    /// <summary>
    /// Interaction logic for StudentsListPage.xaml
    /// </summary>
    public partial class StudentsListPage : Page
    {
        public StudentsListPage()
        {
            InitializeComponent();
            var allItems = DbConnect.entObj.Groups.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.Groups.ToList();
                CmbFilter.DisplayMemberPath = "Name";
                CmbSort.SelectedIndex = 0;
                CmbFilter.SelectedIndex = 0;

                StudentList.ItemsSource = DbConnect.entObj.Students.Take(15).ToList();

                ResultTxb.Text = StudentList.Items.Count + "/" + DbConnect.entObj.Students.Count().ToString();
            }
            catch (Exception except)
            {

                System.Windows.MessageBox.Show(except.Message, "Что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as Group;
            var allItems = DbConnect.entObj.Students.ToList();
            var items = (select != null) ? allItems.Where(x => x.GroupId == select.Id) : allItems;
            StudentList.ItemsSource = items;
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    StudentList.ItemsSource = DbConnect.entObj.Students.ToList();
                    break;
                case 1:
                    StudentList.ItemsSource = DbConnect.entObj.Students.OrderBy(i => i.FIO).ToList();
                    break;
                case 2:
                    StudentList.ItemsSource = DbConnect.entObj.Students.OrderByDescending(i => i.FIO).ToList();
                    break;
                case 3:
                    StudentList.ItemsSource = DbConnect.entObj.Students.OrderBy(i => i.StipendSize).ToList();
                    break;
                case 4:
                    StudentList.ItemsSource = DbConnect.entObj.Students.OrderByDescending(i => i.StipendSize).ToList();
                    break;
                case 5:
                    StudentList.ItemsSource = DbConnect.entObj.Students.OrderBy(i => i.Children).ToList();
                    break;
                case 6:
                    StudentList.ItemsSource = DbConnect.entObj.Students.OrderByDescending(i => i.Children).ToList();
                    break;

            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                StudentList.ItemsSource = DbConnect.entObj.Students.Where(x => x.FIO.Contains(TxbSearch.Text)).ToList();
                ResultTxb.Text = StudentList.Items.Count + "/" + DbConnect.entObj.Students.Where(x => x.FIO.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnAddStd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddStudentsPage());
        }

        private void btnDelStd_Click(object sender, RoutedEventArgs e)
        {
            var studentsForRemoving = StudentList.SelectedItems.Cast<Student>().ToList();

            var cancel = System.Windows.Forms.MessageBox.Show("Вы подтверждаете удаление?",
                            "Подтверждение",
                            MessageBoxButtons.OKCancel);
            if (DialogResult.Cancel == cancel)
            {
                FrameApp.frmObj.Navigate(new StudentsListPage());
            }
            else
            {

                try
                {
                    DbConnect.entObj.Students.RemoveRange(studentsForRemoving);
                    DbConnect.entObj.SaveChanges();
                    System.Windows.MessageBox.Show("Данные удалены");

                    StudentList.ItemsSource = DbConnect.entObj.Students.ToList();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
