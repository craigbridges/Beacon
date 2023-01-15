namespace Beacon.Domain.Alerts.Events
{
    public record class AlertCreatedEvent : IDomainEvent
    {
        public required Guid AlertId { get; init; }
        public required AlertRequest Request { get; init; }
        public required DateTime DateCreated { get; init; }
    }
}
