
using System;
using System.Collections.Generic;

namespace TimursCargoLine.Core;

internal class PlaneRoute : IRouteable
{
    private const int AveragePlaneSpeed = 900;
    private const int EarthRadius = 6371;
    private readonly Coordinates _airportA;
    private readonly Coordinates _airportB;

    public PlaneRoute(Coordinates airportA, Coordinates airportB)
    {
        _airportA = airportA;
        _airportB = airportB;
    }

    public IEnumerable<Coordinates> GetIntermediateCoordinates()
    {
        return new List<Coordinates>
        {
            _airportA,
            _airportB
        };
    }

    public double GetDistance()
    {
        var dLat = DegreesToRadians(_airportB.Latitude - _airportA.Latitude);
        var dLon = DegreesToRadians(_airportB.Longitude - _airportA.Longitude);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(_airportA.Latitude)) * 
                Math.Cos(DegreesToRadians(_airportB.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return Math.Round(EarthRadius * c, 2);
    }

    public double GetDuration()
    {
        return Math.Round(GetDistance() / AveragePlaneSpeed, 2); 
    }

    private double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }
}