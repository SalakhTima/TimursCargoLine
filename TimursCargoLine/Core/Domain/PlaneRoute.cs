namespace TimursCargoLine.Core.Domain;

internal class PlaneRoute(Coordinates airportA, Coordinates airportB) : IRoute
{
    private const int AveragePlaneSpeed = 900;
    private const int EarthRadius = 6371;

    public IEnumerable<Coordinates> GetIntermediateCoordinates() => new List<Coordinates>
    {
        airportA, 
        airportB
    };

    public double GetDistance()
    {
        var dLat = DegreesToRadians(airportB.Latitude - airportA.Latitude);
        var dLon = DegreesToRadians(airportB.Longitude - airportA.Longitude);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(airportA.Latitude)) *
                Math.Cos(DegreesToRadians(airportB.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return Math.Round(EarthRadius * c, 2);
    }

    public double GetDuration() => Math.Round(GetDistance() / AveragePlaneSpeed, 2);

    private double DegreesToRadians(double degrees) => degrees * Math.PI / 180;
}