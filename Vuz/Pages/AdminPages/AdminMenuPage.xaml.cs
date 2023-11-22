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
using Vuz.Pages.AdminPages;
using Vuz.Pages.AdminPages.AdminListPages;

namespace Vuz.Pages
{
    /// <summary>
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        private void btnAddStudents_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddStudentsPage());
        }

        private void btnAddStudents_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddTeacherPage());
        }

        private void btnGoStudentView_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new StudentsListPage());
        }

        private void btnGoTeacher_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new TeacherListPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new AddUsers());
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new UserListPage());
        }
    }
}
