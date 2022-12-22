namespace Beacon.Domain.Devices.Services;

/// <summary>
/// Defines a repository that manages a collection of devices
/// </summary>
public interface IDeviceRepository : IDomainService
{
    /// <summary>
    /// Asynchronously adds a device to the repository
    /// </summary>
    /// <param name="device">The device to add</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The result of the operation</returns>
    Task<Result> Add(Device device, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously gets a device from the repository
    /// </summary>
    /// <param name="deviceId">The ID of the device to get</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The matching device</returns>
    Task<Maybe<Device>> Get(Guid deviceId, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously gets all devices for an owner
    /// </summary>
    /// <param name="ownerId">The owner ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A collection of matching devices</returns>
    Task<IEnumerable<Device>> GetAllForOwner(Guid ownerId, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously removes a device from the repository
    /// </summary>
    /// <param name="deviceId">The ID of the device to remove</param>
    /// <param name="cancellationToken">he cancellation token</param>
    /// <returns>The result of the operation</returns>
    Task<Result> Remove(Guid deviceId, CancellationToken cancellationToken);
}
