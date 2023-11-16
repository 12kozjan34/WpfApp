using Microsoft.Win32;
using PersonManager.Utils;
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
    /// Interaction logic for EditStudentPage.xaml
    /// </summary>
    public partial class EditStudentPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Student? student;
        public EditStudentPage(AppViewModel appViewModel, Student? student=null) : base(appViewModel)
        {
            InitializeComponent();

            this.student = student ?? new Student();
            DataContext = student;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = Filter
            };
            if (dialog.ShowDialog() == true)
            {
                var image = new BitmapImage(new Uri(dialog.FileName));
                picture.Source = image;
            }
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                student!.FirstName = tbFirstName.Text.Trim();
                student!.LastName = tbLastName.Text.Trim();
                student!.Email = tbEmail.Text.Trim();
                student!.Age = int.Parse(tbAge.Text.Trim());

                student!.Picture = ImageUtils.BitmapImageToByteArray((picture.Source as BitmapImage)!);

                if (student.IDStudent == 0)
                {
                    AppViewModel.Studenti.Add(student);
                }
                else
                {
                    AppViewModel.UpdatePerson(student);
                }

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

            pictureBorder.BorderBrush = Brushes.White;
            if (picture.Source == null)
            {
                pictureBorder.BorderBrush = Brushes.Red;
                ok = false;
            }

            return ok;
        }
    }
}
