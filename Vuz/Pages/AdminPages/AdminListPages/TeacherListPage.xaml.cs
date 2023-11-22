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
    /// Interaction logic for TeacherListPage.xaml
    /// </summary>
    public partial class TeacherListPage : Page
    {
        public TeacherListPage()
        {
            InitializeComponent();
        }

        private void btnDelStd_Click(object sender, RoutedEventArgs e)
        {
            var teachersForRemoving = ListTeacher.SelectedItems.Cast<Teacher>().ToList();

            var cancel = System.Windows.Forms.MessageBox.Show("Вы подтверждаете удаление?",
                            "Подтверждение",
                            MessageBoxButtons.OKCancel);
            if (DialogResult.Cancel == cancel)
            {
                FrameApp.frmObj.Navigate(new TeacherListPage());
            }
            else
            {

                try
                {
                    DbConnect.entObj.Teachers.RemoveRange(teachersForRemoving);
                    DbConnect.entObj.SaveChanges();
                    System.Windows.MessageBox.Show("Данные удалены");

                    ListTeacher.ItemsSource = DbConnect.entObj.Teachers.ToList();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void btnAddStd_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddTeacherPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.AcademicRanks.ToList();
                CmbFilter.DisplayMemberPath = "Name";
                CmbSort.SelectedIndex = 0;
                CmbFilter.SelectedIndex = 0;

                ListTeacher.ItemsSource = DbConnect.entObj.Teachers.Take(15).ToList();

                ResultTxb.Text = ListTeacher.Items.Count + "/" + DbConnect.entObj.Teachers.Count().ToString();
            }
            catch (Exception except)
            {

                System.Windows.MessageBox.Show(except.Message, "Что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
           FrameApp.frmObj.GoBack();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    ListTeacher.ItemsSource = DbConnect.entObj.Teachers.ToList();
                    break;
                case 1:
                    ListTeacher.ItemsSource = DbConnect.entObj.Teachers.OrderBy(i => i.FIO).ToList();
                    break;
                case 2:
                    ListTeacher.ItemsSource = DbConnect.entObj.Teachers.OrderByDescending(i => i.FIO).ToList();
                    break;
                case 3:
                    ListTeacher.ItemsSource = DbConnect.entObj.Teachers.OrderBy(i => i.Salary).ToList();
                    break;
                case 4:
                    ListTeacher.ItemsSource = DbConnect.entObj.Teachers.OrderByDescending(i => i.Salary).ToList();
                    break;
                case 5:
                    ListTeacher.ItemsSource = DbConnect.entObj.Teachers.OrderBy(i => i.CountChildren).ToList();
                    break;
                case 6:
                    ListTeacher.ItemsSource = DbConnect.entObj.Teachers.OrderByDescending(i => i.CountChildren).ToList();
                    break;

            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as AcademicRank;
            var allItems = DbConnect.entObj.Teachers.ToList();
            var items = (select != null) ? allItems.Where(x => x.AcademicRanksId == select.Id) : allItems;
            ListTeacher.ItemsSource = items;
        }

        private void TxbSerach_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListTeacher.ItemsSource = DbConnect.entObj.Teachers.Where(x => x.FIO.Contains(TxbSearch.Text)).ToList();
                ResultTxb.Text = ListTeacher.Items.Count + "/" + DbConnect.entObj.Teachers.Where(x => x.FIO.Contains(TxbSearch.Text)).Count().ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void ListTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
