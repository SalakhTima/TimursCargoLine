using System.Windows.Controls;
using System.Windows.Input;
using TimursCargoLine.Model;
using TimursCargoLine.View.UserControl;
using Order = TimursCargoLine.View.UserControl.Order;
using Report = TimursCargoLine.View.UserControl.Report;

namespace TimursCargoLine.ViewModel;

public class ContentSwitcher : PropertyChanger
{
    private ContentControl? _myContentControl;
    public ContentControl MyContentControl 
    {
        get => _myContentControl ??= new Order();
        set => SetField(ref _myContentControl, value);
    }

    private ICommand? _setContent;
    public ICommand SetContent
    {
        get
        {
            return _setContent ??= new RelayCommand(obj =>
            {
                _myContentControl = obj.ToString() switch
                {
                    "Order" => MyContentControl = new Order(),
                    "Report" => MyContentControl = new Report(),
                    "TypesOfTransportation" => MyContentControl = new TypesOfTransportation(),
                    "TypesOfCargo" => MyContentControl = new TypesOfCargo(),
                    _ => _myContentControl
                };
            });
        }
    }
}