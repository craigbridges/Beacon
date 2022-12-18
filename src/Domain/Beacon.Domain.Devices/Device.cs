namespace Beacon.Domain.Devices;

/// <summary>
/// An aggregate root that represents a single physical device
/// </summary>
public class Device : IAggregateRoot
{
    protected Device() { }

    private Device(Guid ownerId, string name, DeviceInformation information)
    {
        Id = Guid.NewGuid();
        DateCreated = DateTime.UtcNow;
        DateModified= DateTime.UtcNow;
        OwnerId = ownerId;
        Name = name;
        Information = information;

        UnpublishedEvents.Add
        (
            new DeviceCreatedEvent()
            {
                DeviceId = Id,
                OwnerId = OwnerId,
                DateCreated = DateCreated,
                DeviceName = Name,
                DeviceInformation = Information
            }
        );
    }

    public static Result<Device> Create(Guid ownerId, string name, DeviceInformation information)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Device>("The device name must contain a value.");
        }

        return new Device(ownerId, name, information);
    }

    /// <summary>
    /// Gets the unique device identifier
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
    /// Gets the identifier of the devices owner (usually a person ID)
    /// </summary>
    public Guid OwnerId { get; protected set; }

    /// <summary>
    /// Gets the device name
    /// </summary>
    public string Name { get; protected set; } = default!;

    /// <summary>
    /// Gets the devices information (such as serial number, operating system, etc)
    /// </summary>
    public DeviceInformation Information { get; protected set; } = default!;
}
