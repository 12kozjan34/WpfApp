using PersonManager.Utils;
using Project.Dal;
using Project.Models;
using Project.Utils;
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
    /// Interaction logic for AddCoursePage.xaml
    /// </summary>
    public partial class AddCoursePage : FramedPage
    {
        private readonly Student student;
        public AddCoursePage(AppViewModel appViewModel, Student student) : base(appViewModel)
        {
            InitializeComponent();
            this.student = student;
            cbCourses.ItemsSource = appViewModel.Kolegiji;
            DataContext = student;
        }

        private void btnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                student.Kolegiji.Add((Kolegij)cbCourses.SelectedItem);

                Kolegij kolegij = (Kolegij)cbCourses.SelectedValue;

                RepositoryFactory.GetRepository().UpdateStudentKolegij(kolegij.IDKolegij, student.IDStudent);

                Frame?.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool ok = true;

            grid.Children.OfType<TextBox>().ToList().ForEach(tb =>
            {
                tb.Background = Brushes.White;
                if (string.IsNullOrEmpty(tb.Text.Trim())
                    || "Int".Equals(tb.Tag) && !int.TryParse(tb.Text.Trim(), out int r)
                    || "Email".Equals(tb.Tag) && !ValidationUtils.IsValidEmail(tb.Text.Trim()))
                {
                    ok = false;
                    tb.Background = Brushes.Red;
                }
            });

            return ok;
        }
    }
}
