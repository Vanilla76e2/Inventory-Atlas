using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class ScannerDto : DeviceDto
    {
        public string? IpAddress { get; set; }
        public int Dpi { get; set; }
        public bool Color { get; set; } 
    }
}
