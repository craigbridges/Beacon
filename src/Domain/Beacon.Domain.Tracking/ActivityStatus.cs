namespace Beacon.Domain.Tracking
{
    using System.ComponentModel;

    /// <summary>
    /// Defines possible status for an activity
    /// </summary>
    public enum ActivityStatus
    {
        [Description("Not Started")]
        NotStarted = 0,

        [Description("In Progress")]
        InProgress = 1,

        [Description("Overrun")]
        Overrun = 2,

        [Description("Concluded")]
        Concluded = 4
    }
}
