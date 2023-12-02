namespace TimursCargoLine.Core;

internal static class CostCalculator
{
    private const int BaseRatePerKilometerByTruck = 150;
    private const int BaseRatePerKilometerByPlane = 210;

    public static double CalculateCostOfTransportation(TypeOfTransportation transportation, 
        TypeOfCargo cargo, double distance, int containersAmount)
    {
        var transportationMultiplier = DefineMultiplierForTransportationType(transportation);
        var cargoMultiplier = DefineMultiplierForCargoType(cargo);

        return Math.Round(distance * transportationMultiplier * cargoMultiplier * containersAmount, 2); 
    }

    private static int DefineMultiplierForTransportationType(TypeOfTransportation transportation) => transportation switch
    {
        TypeOfTransportation.Truck => BaseRatePerKilometerByTruck,
        TypeOfTransportation.Plane => BaseRatePerKilometerByPlane,
        _ => 1
    };

    private static double DefineMultiplierForCargoType(TypeOfCargo cargo) => cargo switch
    {
        TypeOfCargo.Medicines => 1.2,
        TypeOfCargo.Chemicals => 1.4,
        TypeOfCargo.Jewelry => 2.1,
        TypeOfCargo.TobaccoAndAlcohol => 2.7,
        TypeOfCargo.Antiques => 1.7,
        TypeOfCargo.Auto => 1.8,
        _ => 1.0
    };
}