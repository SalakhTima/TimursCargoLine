using System.Collections.Generic;

namespace TimursCargoLine.Core;

public interface IRouteable
{
    IEnumerable<Coordinates> GetIntermediateCoordinates();
    double GetDistance();
    double GetDuration();
}