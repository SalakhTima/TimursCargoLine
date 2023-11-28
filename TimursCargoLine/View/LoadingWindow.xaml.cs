using System.Windows;
using TimursCargoLine.Core.Web;

namespace TimursCargoLine.View;

public partial class LoadingWindow : Window
{
    public LoadingWindow()
    {
        InitializeComponent();
        Loaded += LoadingWindow_Loaded;
    }

    private async void LoadingWindow_Loaded(object sender, RoutedEventArgs e)
    {
        await StartApplication();
    }

    private async Task StartApplication()
    {
        if (ConnectionChecker.IsNetworkAvailable())
        {
            ProcessStatus.Text = "ЗАГРУЗКА...";
            await AnimateProgressBarWidth(2);
            
            var mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
        else
        {
            ProcessStatus.Text = "СОЕДИНЕНИЕ НЕ УСТАНОВЛЕНО";
        }
    }

    private async Task AnimateProgressBarWidth(double durationSeconds)
    {
        var endWidth = LoadingBar.ActualWidth; 
        
        for (var i = 1; i <= 100; i++)
        {
            var ratio = i / (double)100;
            var interpolatedWidth = 0 + (endWidth - 0) * ratio;
            LoadingBar.Width = interpolatedWidth;

            await Task.Delay((int)(durationSeconds * 1000) / 100);
        }
    }
}