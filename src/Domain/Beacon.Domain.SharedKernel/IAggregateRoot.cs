namespace Beacon.Domain
{
    /// <summary>
    /// Defines a domain aggregate root entity
    /// </summary>
    public interface IAggregateRoot : IEntity
    {
        /// <summary>
        /// Gets a collection of domain events that have not been published
        /// </summary>
        public List<IDomainEvent> UnpublishedEvents { get; }
    }
}
