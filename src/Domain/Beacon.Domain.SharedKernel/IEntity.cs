namespace Beacon.Domain
{
    /// <summary>
    /// Defines a domain entity with a unique identity
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets the entities unique ID
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the date and time the entity was created
        /// </summary>
        public DateTime DateCreated { get; }

        /// <summary>
        /// Gets the date and time the entity was last modified
        /// </summary>
        public DateTime DateModified { get; }
    }
}
