namespace Beacon.Domain.Tracking;

using System.Net;

/// <summary>
/// Aggregate root that represents a single location ping
/// </summary>
public class LocationPing : IAggregateRoot
{
    protected LocationPing() { }

    private LocationPing(PingRequest request)
    {
        var now = DateTime.UtcNow;

        Id = Guid.NewGuid();
        DateCreated = now;
        DateModified = now;
        Device = request.Device;
        IpAddress = request.IpAddress;
        User = request.User;
        Coordinate = request.Coordinate;
        DateSentLocal = request.DateSentLocal;
        DateSentUtc = request.DateSentUtc;
        MetaData = request.MetaData;

        UnpublishedEvents.Add(new LocationPingedEvent(Id, request));
    }

    public static Result<LocationPing> Create(PingRequest request)
    {
        if (request.Device == null)
        {
            return Result.Failure<LocationPing>("The device details are missing.");
        }
        else if (request.IpAddress == null)
        {
            return Result.Failure<LocationPing>("The IP address is missing.");
        }
        else if (request.User == null)
        {
            return Result.Failure<LocationPing>("The user details are missing.");
        }
        else if (request.Coordinate == null)
        {
            return Result.Failure<LocationPing>("The location coordinate is missing.");
        }
        else
        {
            return new LocationPing(request);
        }
    }

    /// <summary>
    /// Gets the unique location ping identifier
    /// </summary>
    public Guid Id { get; protected set; }

    /// <summary>
    /// Gets the date and time the devices was created
    /// </summary>
    public DateTime DateCreated { get; protected set; }

    /// <summary>
    /// Gets the date and time the device was last modified
    /// </summary>
    public DateTime DateModified { get; protected set; }

    /// <summary>
    /// Gets a list of device related domain events that have not been published
    /// </summary>
    public List<IDomainEvent> UnpublishedEvents { get; } = new();

    /// <summary>
    /// Gets information about the device that sent the ping
    /// </summary>
    public DeviceInformation Device { get; protected set; } = default!;

    /// <summary>
    /// Gets the IP address the ping request was sent from
    /// </summary>
    public IPAddress IpAddress { get; protected set; } = default!;

    /// <summary>
    /// Gets information about the user of the device
    /// </summary>
    public UserInformation User { get; protected set; } = default!;

    /// <summary>
    /// Gets the geographical location where the ping was sent from
    /// </summary>
    public GeoCoordinate Coordinate { get; protected set; } = default!;

    /// <summary>
    /// Gets the device locations local date and time when the request was sent
    /// </summary>
    public DateTime DateSentLocal { get; protected set; }

    /// <summary>
    /// Gets the UTC date and time when the request was sent
    /// </summary>
    public DateTime DateSentUtc { get; protected set; }

    /// <summary>
    /// Gets any meta data set for the ping request
    /// </summary>
    public Dictionary<string, string> MetaData { get; protected set; } = new();

    /// <summary>
    /// Generates a custom description of the location ping
    /// </summary>
    /// <returns>A description of the ping</returns>
    public override string ToString()
    {
        return $"{User} pinged from {Device} using IP address {IpAddress} at coordinate {Coordinate}.";
    }
}
