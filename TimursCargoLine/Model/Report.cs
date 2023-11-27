using TimursCargoLine.Core;

namespace TimursCargoLine.Model;

public class Report : PropertyChanger
{
    private string _from = null!;
    private string _to = null!;
    private TypeOfTransportation _transportation;
    private TypeOfCargo _cargo;
    private string _distance = null!;
    private string _duration = null!;
    private int _containersAmount;
    private string _approximateCost = null!;
    private DateTime _creationTime;

    public string From
    {
        get => _from;
        set => SetField(ref _from, value);
    }

    public string To
    {
        get => _to;
        set => SetField(ref _to, value);
    }

    public TypeOfTransportation Transportation
    {
        get => _transportation;
        set => SetField(ref _transportation, value);
    }
    
    public TypeOfCargo Cargo
    {
        get => _cargo;
        set => SetField(ref _cargo, value);
    }
    
    public string Distance
    {
        get => _distance;
        set => SetField(ref _distance, value);
    }

    public string Duration
    {
        get => _duration;
        set => SetField(ref _duration, value);
    }

    public int ContainersAmount
    {
        get => _containersAmount;
        set => SetField(ref _containersAmount, value);
    }

    public string ApproximateCost
    {
        get => _approximateCost;
        set => SetField(ref _approximateCost, value);
    }

    public DateTime CreationTime
    {
        get => _creationTime;
        set => SetField(ref _creationTime, value);
    }
}