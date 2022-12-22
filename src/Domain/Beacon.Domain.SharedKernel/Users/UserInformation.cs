namespace Beacon.Domain.SharedKernel.Users
{
    /// <summary>
    /// Represents information about a single user
    /// </summary>
    public record class UserInformation
    {
        /// <summary>
        /// Gets the users username
        /// </summary>
        public required string UserName { get; init; }

        /// <summary>
        /// Gets the users email address
        /// </summary>
        public required string EmailAddress { get; init; }

        /// <summary>
        /// Gets the users phone number
        /// </summary>
        public string? PhoneNumber { get; init; }

        /// <summary>
        /// Gets the users heart rate reading (represented as the number of beats per minute)
        /// </summary>
        public int? HeartRateReading { get; init; }

        /// <summary>
        /// Overridden to provide a custom descriptor
        /// </summary>
        /// <returns>The user name</returns>
        public override string ToString() => UserName;
    }
}
