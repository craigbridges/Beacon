namespace Beacon.Domain.Devices.Events
{
    public record class DeviceEnabledEvent : IDomainEvent
    {
        public required Guid DeviceId { get; init; }
        public required Guid OwnerId { get; init; }
        public required DateTime DateEnabled { get; init; }
        public required string DeviceName { get; init; }
        public required DeviceInformation DeviceInformation { get; init; }
    }
}
