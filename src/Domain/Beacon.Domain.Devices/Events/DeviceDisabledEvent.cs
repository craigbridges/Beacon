namespace Beacon.Domain.Devices.Events
{
    public record class DeviceDisabledEvent : IDomainEvent
    {
        public required Guid DeviceId { get; init; }
        public required Guid OwnerId { get; init; }
        public required DateTime DateDisabled { get; init; }
        public required string DeviceName { get; init; }
        public required DeviceInformation DeviceInformation { get; init; }
    }
}
