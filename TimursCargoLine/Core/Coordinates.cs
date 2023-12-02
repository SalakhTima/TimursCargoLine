namespace TimursCargoLine.Core;

public readonly struct Coordinates : IEquatable<Coordinates>
{
    public required double Latitude { get; init; }
    public required double Longitude { get; init; }

    public bool Equals(Coordinates other) =>
        Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);

    public override bool Equals(object? obj) => obj is Coordinates other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(Latitude, Longitude);

    public static bool operator ==(Coordinates left, Coordinates right) => left.Equals(right);

    public static bool operator !=(Coordinates left, Coordinates right) => !left.Equals(right);
}