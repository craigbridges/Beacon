namespace Beacon.Domain.SharedKernel.Risk
{
    using System.ComponentModel;

    /// <summary>
    /// Defines danger levels for risk assessment
    /// </summary>
    public enum RiskLevel
    {
        [Description("Low")]
        Low = 0,

        [Description("Medium")]
        Medium = 1,

        [Description("High")]
        High = 2,

        [Description("Extremely High")]
        ExtremelyHigh = 4
    }
}
