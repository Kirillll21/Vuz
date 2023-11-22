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

namespace Vuz.Pages
{
    /// <summary>
    /// Interaction logic for TeacherList.xaml
    /// </summary>
    public partial class TeacherList : Page
    {
        public TeacherList()
        {
            InitializeComponent();
            var allItems = DbConnect.entObj.AcademicRanks.ToList();
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

                MessageBox.Show(except.Message, "Что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
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

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void TeacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void CmbFilter_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as AcademicRank;
            var allItems = DbConnect.entObj.Teachers.ToList();
            var items = (select != null) ? allItems.Where(x => x.AcademicRanksId == select.Id) : allItems;
            ListTeacher.ItemsSource = items;
        }

        private void CmbSort_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnGoBack_Click_1(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void ListTeacher_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
