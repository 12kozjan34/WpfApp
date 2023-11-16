using Project.Dal;
using Project.Models;
using Project.ViewModels;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for ListStudentPage.xaml
    /// </summary>
    public partial class AppPage : FramedPage
    {
        private List<Kolegij>kolegiji = new List<Kolegij>();
        public AppPage(AppViewModel appViewModel) : base(appViewModel)
        {
            InitializeComponent();
            lvStudents.ItemsSource = appViewModel.Studenti;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditStudentPage(AppViewModel)
            {
                Frame = Frame
            });
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvStudents.SelectedItem != null)
            {
                AppViewModel.Studenti.Remove((lvStudents.SelectedItem as Student)!);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvStudents.SelectedItem != null)
            {
                Frame?.Navigate(new EditStudentPage(
                    AppViewModel,
                    lvStudents.SelectedItem as Student
                    )
                {
                    Frame = Frame
                });
            }
        }

        private void ListViewItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int id = (lvStudents.SelectedItem as Student).IDStudent;
            kolegiji = RepositoryFactory.GetRepository().GetKolegijiZaStudent(id);
            lvCourses.ItemsSource = kolegiji;
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Navigate to new frame and show data for selected Course and selected Proffesor
            Frame?.Navigate(new CoursePage(AppViewModel)
            {
                Frame = Frame
            });

        }

        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new AddCoursePage(AppViewModel,(Student)lvStudents.SelectedItem)
            {
                Frame = Frame
            });
        }
    }
}
