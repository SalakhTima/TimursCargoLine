using System.Windows;
using System.Windows.Input;
using TimursCargoLine.Core;
using TimursCargoLine.Core.Domain;
using TimursCargoLine.Core.Factories;
using TimursCargoLine.Core.Web;
using TimursCargoLine.Model;

namespace TimursCargoLine.ViewModel;

public class OrderViewModel : PropertyChanger
{
    private Order _currentOrder = new();
    public Order CurrentOrder
    {
        get => _currentOrder;
        set => SetField(ref _currentOrder, value);
    }
    
    private ICommand? _submitOrderCommand;
    public ICommand SubmitOrderCommand
    {
        get
        {
            return _submitOrderCommand ??= new RelayCommand(async obj =>
            {
                StaticContainer.ReportData = await CreateReport();
            });
        }
    }

    private async Task<Report> CreateReport()
    {
        if (!Validate())
        {
            MessageBox.Show("Some data missing");
            StaticContainer.Coordinates = DefaultValues.DefaultCoordinates;
            return DefaultValues.DefaultReport; 
        }

        var outputReport = new Report();

        var targetA = await GetTarget(CurrentOrder.PointA, CurrentOrder.PointACountryCode);
        var targetB = await GetTarget(CurrentOrder.PointB, CurrentOrder.PointBCountryCode);

        Enum.TryParse(CurrentOrder.Cargo.ToString(), out TypeOfCargo cargo);
        Enum.TryParse(CurrentOrder.Transportation.ToString(), out TypeOfTransportation transportation);

        IRouteFactory factory = FactoryMethod.GetFactory(transportation);
        IRoute route = await factory.GetRoute(CurrentOrder);

        outputReport.From = targetA.Label;
        outputReport.To = targetB.Label;
        outputReport.Transportation = transportation;
        outputReport.Cargo = cargo;
        outputReport.ContainersAmount = CurrentOrder.ContainersAmount;
        outputReport.CreationTime = DateTime.Now;
        outputReport.Distance = $"{route.GetDistance()} км";
        outputReport.Duration = $"{route.GetDuration()} ч";
        outputReport.ApproximateCost = $"{CostCalculator.CalculateCostOfTransportation(transportation, cargo,
            route.GetDistance(), CurrentOrder.ContainersAmount)} руб";

        StaticContainer.Coordinates = route.GetIntermediateCoordinates();

        return outputReport;
    }

    private async Task<Target> GetTarget(string keyWords, string countryCode)
    {
        var targetRequestUrl = UrlBuilder.BuildTargetRequestUrl(keyWords, countryCode);
        var targetResponse = await WebClient.GetRequestDataAsync(targetRequestUrl);

        return new Target(targetResponse);
    }

    private bool Validate()
    {
        return !string.IsNullOrEmpty(CurrentOrder.PointA)
               && !string.IsNullOrEmpty(CurrentOrder.PointACountryCode)
               && !string.IsNullOrEmpty(CurrentOrder.PointB)
               && !string.IsNullOrEmpty(CurrentOrder.PointBCountryCode);
    }
}