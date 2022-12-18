namespace Beacon.Domain.Devices.Events
{
    public record class DeviceCreatedEvent : IDomainEvent
    {
        public required Guid DeviceId { get; init; }
        public required Guid OwnerId { get; init; }
        public required DateTime DateCreated { get; init; }
        public required string DeviceName { get; init; }
        public required DeviceInformation DeviceInformation { get; init; }
    }
}
