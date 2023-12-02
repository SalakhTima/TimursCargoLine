namespace TimursCargoLine.Core.Factories;

internal static class FactoryMethod 
{
    public static IRouteFactory GetFactory(TypeOfTransportation transportation) => transportation switch
    {
        TypeOfTransportation.Truck => new TruckRouteFactory(),
        TypeOfTransportation.Plane => new PlaneRouteFactory(),
        _ => throw new ArgumentOutOfRangeException(nameof(transportation)),
    };
}