using PersonManager.Utils;
using Project.Dal;
using Project.Models;
using Project.Utils;
using Project.ViewModels;
using System;
using System.Collections;
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
    public partial class EditCoursePage : FramedPage
    {
        private readonly Kolegij? kolegij;
        public EditCoursePage(AppViewModel appViewModel, Kolegij? kolegij = null) : base(appViewModel)
        {
            InitializeComponent();
            this.kolegij = kolegij ?? new Kolegij();
            cbProfesors.ItemsSource = AddProfesors();
        }

        private IList AddProfesors()
        {
            List<Profesor> list = new List<Profesor>();
            list = RepositoryFactory.GetRepository().GetProfesors().ToList();
            return list;
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                kolegij!.Name = tbFirstName.Text.Trim();
                kolegij!.Profesor = (Profesor?)cbProfesors.SelectedItem;

                if (kolegij.IDKolegij == 0)
                {
                    AppViewModel.Kolegiji.Add(kolegij);
                }

                Frame?.NavigationService.GoBack();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame?.NavigationService.GoBack();
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
