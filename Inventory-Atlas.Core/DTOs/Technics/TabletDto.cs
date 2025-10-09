using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    public class TabletDto : DeviceDto
    {
        public string? OperatingSystem { get; set; }
        public float? Diagonal { get; set; }
        public int? RAM { get; set; }
        public int? Drive { get; set; }
    }
}
