namespace Beacon.Domain.Alerts
{
    using System.ComponentModel;

    /// <summary>
    /// Defines alert types (is it an emergency or just informative)
    /// </summary>
    public enum AlertType
    {
        [Description("Informative")]
        Informative = 0,

        [Description("Concern")]
        Concern = 1,

        [Description("Moderate Danger")]
        ModerateDanger = 2,

        [Description("Severe Danger")]
        SevereDanger = 4,

        [Description("Emergency")]
        Emergency = 8
    }
}
