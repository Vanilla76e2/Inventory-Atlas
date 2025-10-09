using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class PrinterDto : DeviceDto
    {
        public string? IpAddress { get; set; }
        public string? CartridgeModel { get; set; }
        public int? CartridgeLeft { get; set; }
        public bool Color { get; set; }
        public bool HasScanner { get; set; }

    }
}
