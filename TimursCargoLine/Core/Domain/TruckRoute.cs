﻿using Newtonsoft.Json;

namespace TimursCargoLine.Core.Domain;

internal class TruckRoute(string data) : IRoute
{
    private const int AverageTruckSpeed = 90;
    private readonly JsonRouteFormat _data = JsonConvert.DeserializeObject<JsonRouteFormat>(data)!;

    public IEnumerable<Coordinates> GetIntermediateCoordinates() =>
        from f in _data.Features
        from c in f.Geometry!.Coordinates!
        select new Coordinates { Latitude = c[0], Longitude = c[1] };

    public double GetDistance() => Math.Round(_data.Features![0].Properties!.Summary!.Distance / 1000, 2);

    public double GetDuration() => Math.Round(GetDistance() / AverageTruckSpeed, 2);
}