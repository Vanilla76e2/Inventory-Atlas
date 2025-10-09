using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Consumables
{
    public class PrinterCartridgeDto : AuditableDto
    {
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
