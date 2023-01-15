namespace Beacon.Domain.Alerts;

using Beacon.Domain.Alerts.Events;
using Beacon.Domain.SharedKernel.Location;
using System.Net;

/// <summary>
/// Aggregate root that represents an alert raised by a user
/// </summary>
public class Alert : IAggregateRoot
{
    protected Alert() { }

    protected Alert(AlertRequest request)
    {
        var now = DateTime.UtcNow;

        Id = Guid.NewGuid();
        DateCreated = now;
        DateModified = now;
        UserId = request.UserId;
        DeviceId = request.DeviceId;
        DateSentLocal = request.DateSentLocal;
        DateSentUtc = request.DateSentUtc;
        DateReceived = now;
        IpAddress = request.IpAddress;
        Coordinate = request.Coordinate;
        AlertType = request.AlertType;
        Message = request.Message;

        UnpublishedEvents.Add
        (
            new AlertCreatedEvent()
            {
                AlertId = Id,
                Request = request,
                DateCreated = now
            }
        );
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
    /// Gets the identifier of the user who sent the alert (usually a person ID)
    /// </summary>
    public Guid UserId { get; protected set; }

    /// <summary>
    /// Gets the ID of the device that sent the alert
    /// </summary>
    public Guid DeviceId { get; protected set; }
    
    /// <summary>
    /// Gets the local (to the alerter) date and time the alert was sent
    /// </summary>
    public DateTime DateSentLocal { get; protected set; }

    /// <summary>
    /// Gets the UTC date and time the alert was sent
    /// </summary>
    public DateTime DateSentUtc { get; protected set; }

    /// <summary>
    /// Gets the date and time the alert message was received
    /// </summary>
    public DateTime DateReceived { get; protected set; }

    /// <summary>
    /// Gets the IP address the alert was sent from
    /// </summary>
    public IPAddress IpAddress { get; protected set; } = default!;

    /// <summary>
    /// Gets the geographical location where the alert was sent from (if known)
    /// </summary>
    public GeoCoordinate? Coordinate { get; protected set; }

    /// <summary>
    /// Gets the alert type
    /// </summary>
    public AlertType AlertType { get; protected set; }

    /// <summary>
    /// Gets the message added to the alert by the alerter (optional)
    /// </summary>
    public string? Message { get; protected set; }

    // TODO: delay before alerting contacts/police?
    // TODO: track who has been contacted about alert (i.e. contacts/police, etc)
    // TODO: cancel alert (i.e. false alarm - require some sort of 2-factor confirmation from user)
}
