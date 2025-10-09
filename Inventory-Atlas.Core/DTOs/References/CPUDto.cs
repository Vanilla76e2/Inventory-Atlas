using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.References
{
    public class CPUDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string? Manufacturer { get; set; }
        public short? CoreCount { get; set; }
        public short? ThreadCount { get; set; }
        public double? Clock { get; set; } // GHz
        public string? Socket { get; set; }

        // Для DTO можно дать коллекцию Id компонентов, если нужно
        public List<int>? ComponentIds { get; set; }
    }
}
