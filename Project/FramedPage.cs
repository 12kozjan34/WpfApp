using Project.ViewModels;
using System.Windows.Controls;

namespace Project
{
    public class FramedPage : Page
    {
        public FramedPage(AppViewModel appViewMOdel)
        {
            AppViewModel = appViewMOdel;
        }

        public AppViewModel AppViewModel { get; }

        public Frame? Frame { get; set; }
    }
}