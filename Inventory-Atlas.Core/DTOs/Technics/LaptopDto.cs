using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class LaptopDto : DeviceDto
    {
        public string? IpAddress { get; set; }
        public double? Diagonal {  get; set; }
        public string? Resolution { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Processor { get; set; }
        public int? RAM { get; set; }
        public int? Drive {  get; set; }
        public int? GPU { get; set; }
    }
}
