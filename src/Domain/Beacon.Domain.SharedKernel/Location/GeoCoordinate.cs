namespace Beacon.Domain.SharedKernel.Location
{
    public record class GeoCoordinate(double Latitude, double Longitude)
    {
        public override string ToString() => $"{Latitude}, {Longitude}";
    }
}
