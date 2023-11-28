using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using TimursCargoLine.Core;
using TimursCargoLine.Model;
using TimursCargoLine.ViewModel;

namespace TimursCargoLine.View.UserControl;

public partial class Report : System.Windows.Controls.UserControl
{
    public Report()
    {
        InitializeComponent();
        DataContext = new ReportViewModel();
    }
    
    private void MapLoaded(object sender, RoutedEventArgs e)
    {
        GMaps.Instance.Mode = AccessMode.ServerAndCache;
        Map.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
        Map.MinZoom = 2;
        Map.MaxZoom = 17;
        Map.Zoom = 2;
        Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
        Map.CanDragMap = true;
        Map.DragButton = MouseButton.Left;

        var mapRoutePoints = new List<PointLatLng>();
        var routeCoordinates = StaticContainer.Coordinates;

        foreach (Coordinates c in routeCoordinates!)
        {
            mapRoutePoints.Add(new PointLatLng
            {
                Lat = c.Longitude,
                Lng = c.Latitude
            });
        }
        
        DrawRouteOnMap(mapRoutePoints);
    }
    
    private void DrawRouteOnMap(List<PointLatLng> routePoints)
    {
        Map.Markers.Clear();
        
        foreach (var point in routePoints)
        {
            var marker = new GMapMarker(point)
            {
                Shape = new Ellipse
                {
                    Width = 2,
                    Height = 2,
                    Fill = Brushes.Orange, 
                    Stroke = Brushes.Orange,
                    StrokeThickness = 1
                }
            };
            
            Map.Markers.Add(marker);
        }
    }
}