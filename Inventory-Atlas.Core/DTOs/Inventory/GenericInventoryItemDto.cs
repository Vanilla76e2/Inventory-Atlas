using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Inventory
{
    public class GenericInventoryItemDto : InventoryItemDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Properties { get; set; } = "{}";
    }

    public class InventoryCategoryDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CustomFields { get; set; } = "[]"; // JSON-строка

        /// <summary>
        /// Id элементов инвентаря, принадлежащих категории.
        /// </summary>
        public List<int>? ItemIds { get; set; }
    }
}
