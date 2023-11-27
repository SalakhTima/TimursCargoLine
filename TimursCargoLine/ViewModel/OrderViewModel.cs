using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TimursCargoLine.Core;
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
        var outputReport = new Report();
        
        var targetARequestUri = UrlBuilder.BuildTargetRequestUrl(CurrentOrder.PointA, CurrentOrder.PointACountryCode);
        var targetBRequestUri = UrlBuilder.BuildTargetRequestUrl(CurrentOrder.PointB, CurrentOrder.PointBCountryCode);

        var targetAResponse = await WebClient.GetRequestDataAsync(targetARequestUri);
        var targetBResponse = await WebClient.GetRequestDataAsync(targetBRequestUri);

        var targetA = new Target(targetAResponse);
        var targetB = new Target(targetBResponse);
        
        Enum.TryParse(CurrentOrder.Cargo.ToString(), out TypeOfCargo cargo);
        Enum.TryParse(CurrentOrder.Transportation.ToString(), out TypeOfTransportation transportation);
        
        outputReport.From = targetA.Label;
        outputReport.To = targetB.Label;
        outputReport.Transportation = transportation;
        outputReport.Cargo = cargo;
        outputReport.ContainersAmount = CurrentOrder.ContainersAmount;
        outputReport.CreationTime = DateTime.Now;
        
        switch (transportation)
        {
            case TypeOfTransportation.Truck:
                var routeRequestUri = UrlBuilder.BuildRouteRequestUrl(targetA.Coordinates, targetB.Coordinates);
                var routeResponse = await WebClient.GetRequestDataAsync(routeRequestUri);
                var truckRoute = new TruckRoute(routeResponse);
                outputReport.Distance = $"{truckRoute.GetDistance()} км";
                outputReport.Duration = $"{truckRoute.GetDuration()} ч";
                outputReport.ApproximateCost = $"{CostCalculator.CalculateCostOfTransportation(transportation, cargo,
                    truckRoute.GetDistance(), CurrentOrder.ContainersAmount)} руб";
                StaticContainer.Coordinates = truckRoute.GetIntermediateCoordinates();
                return outputReport;
            
            case TypeOfTransportation.Plane:
                var planeRoute = new PlaneRoute(targetA.Coordinates, targetB.Coordinates);
                outputReport.Distance = $"{planeRoute.GetDistance()} км";
                outputReport.Duration = $"{planeRoute.GetDuration()} ч";
                outputReport.ApproximateCost = $"{CostCalculator.CalculateCostOfTransportation(transportation, cargo,
                    planeRoute.GetDistance(), CurrentOrder.ContainersAmount)} руб";
                StaticContainer.Coordinates = planeRoute.GetIntermediateCoordinates();
                return outputReport;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}