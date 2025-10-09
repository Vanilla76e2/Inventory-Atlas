using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Dictionaries
{
    public class CPUComponentDto : ComputerComponentDto
    {
        public int CPUId { get; set; }
        public string CPUName { get; set; } = null!;
        public string? CPUManufacturer { get; set; }
        public short? CoreCount { get; set; }
        public short? ThreadCount { get; set; }
        public double? Clock { get; set; }
        public string? Socket { get; set; }
    }
}
