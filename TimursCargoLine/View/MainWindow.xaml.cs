using System.Windows;
using TimursCargoLine.ViewModel;

namespace TimursCargoLine.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}