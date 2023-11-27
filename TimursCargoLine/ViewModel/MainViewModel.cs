using TimursCargoLine.Model;

namespace TimursCargoLine.ViewModel;

public class MainViewModel : PropertyChanger
{
    private ContentSwitcher? _contentSwitcher = new();
    public ContentSwitcher? ContentSwitcher
    {
        get => _contentSwitcher;
        set => SetField(ref _contentSwitcher, value);
    }
}