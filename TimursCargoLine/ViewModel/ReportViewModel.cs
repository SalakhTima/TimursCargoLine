using TimursCargoLine.Model;

namespace TimursCargoLine.ViewModel;

public class ReportViewModel : PropertyChanger
{
    private Report _currentReport = new();
    public Report CurrentReport
    {
        get => _currentReport;
        set => SetField(ref _currentReport, value);
    }

    public ReportViewModel()
    {
        CurrentReport = StaticContainer.ReportData!;
    }
}