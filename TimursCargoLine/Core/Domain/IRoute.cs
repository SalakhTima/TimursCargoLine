namespace TimursCargoLine.Core.Domain;

public interface IRoute
{
    IEnumerable<Coordinates> GetIntermediateCoordinates();
    double GetDistance();
    double GetDuration();
}