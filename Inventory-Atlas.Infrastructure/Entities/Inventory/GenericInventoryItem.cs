using Inventory_Atlas.Infrastructure.Entities.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Inventory
{
    /// <summary>
    /// Универсальный инвентарный объект.
    /// <para/>
    /// Содержит ссылку на категорию, наименование и дополнительные свойства в формате JSON.
    /// </summary>
    [Table("GenericInventory", Schema = "Inventory")]
    public class GenericInventoryItem : InventoryItem
    {
        /// <summary>
        /// Идентификатор категории инвентарного объекта.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство на категорию инвентарного объекта.
        /// <para/>
        /// Тип: <see cref="InventoryCategory"/>.
        /// <para/>
        /// Позволяет получить информацию о категории, к которой относится объект.
        /// </summary>
        [ForeignKey(nameof(CategoryId))]
        public virtual InventoryCategory Category { get; set; } = null!;

        /// <summary>
        /// Наименование инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Дополнительные свойства объекта в формате JSON.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// По умолчанию пустой JSON: <c>"{}"</c>.
        /// </summary>
        [Column("properties", TypeName = "jsonb")]
        public string Properties { get; set; } = "{}";
    }
}
