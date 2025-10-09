using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Services
{
    public class InventoryPhotoDto : BaseDto
    {
        public int InventoryItemId { get; set; }
        public string PhotoPath { get; set; } = null!;
        public bool IsPrimary { get; set; } = false;
    }
}
