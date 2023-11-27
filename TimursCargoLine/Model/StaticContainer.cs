using TimursCargoLine.Core;

namespace TimursCargoLine.Model;

public static class StaticContainer
{
    public static Report? ReportData { get; set; }
    public static IEnumerable<Coordinates>? Coordinates { get; set; }
}