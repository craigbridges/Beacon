namespace Beacon.Domain.Tracking.Commands
{
    public record class TrackLocationCommand(PingRequest Ping) : ICommand { }
}
