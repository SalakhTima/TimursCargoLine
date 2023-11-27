using TimursCargoLine.Core;

namespace TimursCargoLine.Model;

public class Order : PropertyChanger
{
    private string _pointA = string.Empty;
    private string _pointACountryCode = string.Empty;
    private string _pointB = string.Empty;
    private string _pointBCountryCode = string.Empty;
    private TypeOfTransportation _transportation;
    private TypeOfCargo _cargo;
    private int _containersAmount;
    
    public string PointA
    {
        get => _pointA;
        set => SetField(ref _pointA, value);
    }
    
    public string PointACountryCode
    {
        get => _pointACountryCode;
        set => SetField(ref _pointACountryCode, value);
    }
    
    public string PointB 
    { 
        get => _pointB;
        set => SetField(ref _pointB, value);
    }
    
    public string PointBCountryCode
    {
        get => _pointBCountryCode;
        set => SetField(ref _pointBCountryCode, value);
    }
    
    public IEnumerable<TypeOfTransportation> TransportationTypes => 
        Enum.GetValues(typeof(TypeOfTransportation)).Cast<TypeOfTransportation>();
    public TypeOfTransportation Transportation
    {
        get => _transportation;
        set => SetField(ref _transportation, value);
    }
    
    public IEnumerable<TypeOfCargo> CargoTypes => 
        Enum.GetValues(typeof(TypeOfCargo)).Cast<TypeOfCargo>();
    public TypeOfCargo Cargo
    {
        get => _cargo;
        set => SetField(ref _cargo, value);
    }
    
    public int ContainersAmount
    {
        get => _containersAmount;
        set => SetField(ref _containersAmount, value);
    }
}