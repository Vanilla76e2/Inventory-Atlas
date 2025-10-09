using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Services;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Inventory
{
    public class InventoryItemDto : SoftDeletableDto
    {
        public long? InventoryNumber { get; set; }
        public string? RegistryId { get; set; }
        public int? ResponsibleId { get; set; }
        public string? ResponsibleName { get; set; }
        public string? Location { get; set; }
        public InventoryStatus StatusId { get; set; }
        public string Name { get; set; } = null!;
        public string? Comment { get; set; }

        public List<InventoryPhotoDto>? Photos { get; set; }
    }

}
