using Newtonsoft.Json;

namespace TimursCargoLine.Core;

internal class Target(string data)
{
    private readonly JsonTargetFormat _data = JsonConvert.DeserializeObject<JsonTargetFormat>(data)!;

    public Coordinates Coordinates => new()
    {
        Latitude = _data.Features![0].Geometry!.Coordinates![1], 
        Longitude = _data.Features![0].Geometry!.Coordinates![0]
    };
    public string Country => _data.Features![0].Properties!.Country!;
    public string Region => _data.Features![0].Properties!.Region!;
    public string Street => _data.Features![0].Properties!.Street!;
    public string HouseNumber => _data.Features![0].Properties!.HouseNumber!;
    public string PostalCode => _data.Features![0].Properties!.Postalcode!;
    public string Label => _data.Features![0].Properties!.Label!;
}