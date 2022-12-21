namespace Beacon.Domain.Tracking.Events;

public record class LocationPingedEvent(Guid PingId, PingRequest Request) : IDomainEvent { }
