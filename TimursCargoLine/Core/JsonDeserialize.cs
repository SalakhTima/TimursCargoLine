namespace TimursCargoLine.Core;


//Target's classes for deserializing
public class JsonTargetFormat
{
    public GeocodingFeature[]? Features { get; set; }
}

public class GeocodingFeature
{
    public GeocodingGeometry? Geometry { get; set; }
    public GeocodingProperties? Properties { get; set; }
}

public class GeocodingGeometry
{
    public double[]? Coordinates { get; set; }
}

public class GeocodingProperties
{
    public string? HouseNumber { get; set; }
    public string? Street { get; set; }
    public string? Postalcode { get; set; }
    public string? Country { get; set; }
    public string? Region { get; set; }
    public string? Label { get; set; }
}

//Route's classes for deserializing
public class JsonRouteFormat
{
    public Feature[]? Features { get; set; }
}

public class Geometry
{
    public double[][]? Coordinates { get; set; }
}

public class Feature
{
    public PProperties? Properties { get; set; }
    public Geometry? Geometry { get; set; }
}

public class PProperties
{
    public Summary? Summary { get; set; }
}

public class Summary
{
    public double Distance { get; set; }
}
