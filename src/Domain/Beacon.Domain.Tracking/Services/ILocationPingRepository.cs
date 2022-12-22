namespace Beacon.Domain.Tracking.Services;

/// <summary>
/// Defines a repository that manages a collection of location pings
/// </summary>
public interface ILocationPingRepository : IDomainService
{
    /// <summary>
    /// Asynchronously adds a ping to the repository
    /// </summary>
    /// <param name="ping">The ping to add</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The result of the operation</returns>
    Task<Result> Add(LocationPing ping, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously gets a ping from the repository
    /// </summary>
    /// <param name="pingId">The ID of the ping to get</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>The matching device</returns>
    Task<Maybe<LocationPing>> Get(Guid pingId, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously gets all pings for a device
    /// </summary>
    /// <param name="devicerId">The device ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A collection of matching pings</returns>
    Task<IEnumerable<LocationPing>> GetAllForDevice(Guid devicerId, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously removes a ping from the repository
    /// </summary>
    /// <param name="pingId">The ID of the ping to remove</param>
    /// <param name="cancellationToken">he cancellation token</param>
    /// <returns>The result of the operation</returns>
    Task<Result> Remove(Guid pingId, CancellationToken cancellationToken);
}
