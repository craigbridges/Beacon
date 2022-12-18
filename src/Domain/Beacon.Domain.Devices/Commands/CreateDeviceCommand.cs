namespace Beacon.Domain.Devices.Commands
{
    public record class CreateDeviceCommand
    {
        public required Guid OwnerId { get; init; }
        public required string DeviceName { get; init; }
        public required DeviceInformation DeviceInformation { get; init; }
    }
}
