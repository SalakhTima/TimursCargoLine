using TimursCargoLine.Core;

namespace TimursCargoLine.Model;

internal class DefaultValues
{
    public static IEnumerable<Coordinates> DefaultCoordinates { get; } = new List<Coordinates>
    {
        new() { Latitude = 0.0, Longitude = 0.0 },
        new() { Latitude = 0.0, Longitude = 0.0 }
    };
    public static Report DefaultReport { get; } = new()
    {
        From = "Undefined",
        To = "Undefined",
        Transportation = TypeOfTransportation.Truck,
        Cargo = TypeOfCargo.Auto,
        CreationTime = DateTime.Now,
        Distance = "Undefined",
        Duration = "Undefined",
        ApproximateCost = "Undefined"
    };
}