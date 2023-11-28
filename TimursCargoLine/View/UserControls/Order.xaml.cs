using TimursCargoLine.ViewModel;

namespace TimursCargoLine.View.UserControl;

public partial class Order : System.Windows.Controls.UserControl
{
    public Order()
    {
        InitializeComponent();
        DataContext = new OrderViewModel();
    }
}