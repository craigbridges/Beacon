namespace Beacon.Domain.Tracking.Events
{
    public record class ActivityEndedEvent : IDomainEvent
    {
        public required Guid ActivityId { get; init; }
        public required string ActivityName { get; init; }
        public required UserInformation User { get; init; }
        public required ActivityType ActivityType { get; init; }
        public required DateTime DateEnded { get; init; }
    }
}
