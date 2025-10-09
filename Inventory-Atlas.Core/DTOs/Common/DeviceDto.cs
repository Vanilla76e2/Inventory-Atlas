namespace Inventory_Atlas.Core.DTOs.Common
{
    public abstract class DeviceDto
    {
        public string? Model { get; set; }
        public string? SerialNumber { get; set; }
        public string? Vendor { get; set; }
    }
}
