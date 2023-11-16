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
    /// Interaction logic for EditCoursePage.xaml
    /// </summary>
    public partial class CoursePage : FramedPage
    {
        private readonly Kolegij? kolegij; 
        public CoursePage(AppViewModel appViewModel, Kolegij? kolegij = null) : base(appViewModel)
        {
            InitializeComponent();
            lvCourses.ItemsSource = appViewModel.Kolegiji;
            this.kolegij = kolegij ?? new Kolegij();
            DataContext = kolegij;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame?.Navigate(new EditCoursePage(AppViewModel)
            {
                Frame = Frame
            });
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lvCourses.SelectedItem != null)
            {
                AppViewModel.Kolegiji.Remove((lvCourses.SelectedItem as Kolegij)!);
            }
        }
    }
}
