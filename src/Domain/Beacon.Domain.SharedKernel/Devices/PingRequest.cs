namespace Beacon.Domain.SharedKernel.Devices
{
    using Beacon.Domain.SharedKernel.Location;
    using Beacon.Domain.SharedKernel.Users;
    using System.Net;

    /// <summary>
    /// Represents a single ping request from a device
    /// </summary>
    public record class PingRequest
    {
        /// <summary>
        /// Gets information about the device that sent the ping
        /// </summary>
        public required DeviceInformation Device { get; init; }

        /// <summary>
        /// Gets the IP address the ping request was sent from
        /// </summary>
        public required IPAddress IpAddress { get; init; }

        /// <summary>
        /// Gets information about the user of the device
        /// </summary>
        public required UserInformation User { get; init; }

        /// <summary>
        /// Gets the geographical location where the ping was sent from
        /// </summary>
        public required GeoCoordinate Coordinate { get; init; }

        /// <summary>
        /// Gets the device locations local date and time when the request was sent
        /// </summary>
        public required DateTime DateSentLocal { get; init; }

        /// <summary>
        /// Gets the UTC date and time when the request was sent
        /// </summary>
        public required DateTime DateSentUtc { get; init; }

        /// <summary>
        /// Gets any meta data set for the ping request
        /// </summary>
        public Dictionary<string, string> MetaData { get; init; } = new();
    }
}
