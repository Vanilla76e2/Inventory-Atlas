using Inventory_Atlas.Core.DTOs.Inventory;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class NetworkDeviceDto : InventoryItemDto
    {
        public string? Model { get; set; }
        public string? Vendor { get; set; }
        public string? SerialNumber { get; set; }
        public string? IpAddress { get; set; }
        public string? MacAddress { get; set; }
        public string? DhcpRange { get; set; }
        public short? PortCount { get; set; }
        public int? NetworkBandwidth { get; set; }
        public bool HasWifi { get; set; }
        public string? WifiName { get; set; }
    }

    public class NetworkDeviceAdminDto : NetworkDeviceDto
    {
        public string? AdminLogin { get; set; }
        public string? AdminPassword { get; set; }
        public string? WifiPassword { get; set; }
    }
}
