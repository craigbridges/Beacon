namespace Beacon.Domain.SharedKernel.Devices
{
    /// <summary>
    /// Represents information about a single physical device
    /// </summary>
    public record class DeviceInformation
    {
        /// <summary>
        /// Gets the devices serial number
        /// </summary>
        public required string SerialNumber { get; init; }

        /// <summary>
        /// Gets the devices Media Access Control (MAC) address
        /// </summary>
        public required string MacAddress { get; init; }

        /// <summary>
        /// Gets the device type
        /// </summary>
        public required DeviceType DeviceType { get; init; }

        /// <summary>
        /// Gets the operating system being run on the device
        /// </summary>
        public required OperatingSystem OperatingSystem { get; init; }

        /// <summary>
        /// Gets the name of the devices brand
        /// </summary>
        public string? Brand { get; init; }

        /// <summary>
        /// Gets the name of the devices manufacturer
        /// </summary>
        public string? Manufacturer { get; init; }
    }
}
