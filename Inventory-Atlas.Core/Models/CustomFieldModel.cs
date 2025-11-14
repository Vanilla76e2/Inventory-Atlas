using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.Models
{
    public class CustomFieldModel
    {
        public string Name { get; set; } = null!;
        public DataTypeEnum Type { get; set; }
    }
}
