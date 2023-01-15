namespace Beacon.Domain.Alerts
{
    using Beacon.Domain.SharedKernel.Location;
    using System.Net;

    /// <summary>
    /// Represents a request to create a new alert
    /// </summary>
    public record class AlertRequest
    {
        /// <summary>
        /// Gets the identifier of the user who sent the alert (usually a person ID)
        /// </summary>
        public required Guid UserId { get; init; }

        /// <summary>
        /// Gets the ID of the device that sent the alert
        /// </summary>
        public required Guid DeviceId { get; init; }

        /// <summary>
        /// Gets the local (to the alerter) date and time the alert was sent
        /// </summary>
        public required DateTime DateSentLocal { get; init; }

        /// <summary>
        /// Gets the UTC date and time the alert was sent
        /// </summary>
        public required DateTime DateSentUtc { get; init; }

        /// <summary>
        /// Gets the IP address the alert was sent from
        /// </summary>
        public required IPAddress IpAddress { get; init; }

        /// <summary>
        /// Gets the geographical location where the alert was sent from (if known)
        /// </summary>
        public GeoCoordinate? Coordinate { get; init; }

        /// <summary>
        /// Gets the alert type
        /// </summary>
        public required AlertType AlertType { get; init; }

        /// <summary>
        /// Gets the message added to the alert by the alerter (optional)
        /// </summary>
        public string? Message { get; init; }
    }
}
