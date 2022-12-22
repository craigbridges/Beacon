namespace Beacon.Domain.Tracking.Events
{
    using Beacon.Domain.SharedKernel.Risk;

    public record class ActivityStartedEvent : IDomainEvent
    {
        public required Guid ActivityId { get; init; }
        public required string ActivityName { get; init; }
        public string? Notes { get; init; }
        public required UserInformation User { get; init; }
        public required ActivityType ActivityType { get; init; }
        public required RiskLevel Risk { get; init; }
        public required DateTime DateStarted { get; init; }
    }
}
