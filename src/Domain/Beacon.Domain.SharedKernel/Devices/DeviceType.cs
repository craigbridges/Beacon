namespace Beacon.Domain.SharedKernel.Devices
{
    /// <summary>
    /// Defines possible device types
    /// </summary>
    public enum DeviceType
    {
        Unknown = 0,
        Phone = 1,
        Wearable = 2,
        Tablet = 4,
        Laptop = 8,
        Desktop = 16
    }
}
