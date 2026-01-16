using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Dictionaries
{
    /// <summary>
    /// Значение пользовательских полей.
    /// <para/>
    /// Наследуется от <see cref="BaseEntity"/>.
    /// </summary>
    [Table("CustomFieldValue", Schema = "Dictionaries")]
    public class CustomFieldValue : BaseEntity
    {
        /// <summary>
        /// Идентификатор инвентарного объекта.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("inventory_item_id")]
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Объект представляющий инвентарный объект связанный с данной записью.
        /// <para/>
        /// Тип: <see cref="InventoryItem"/>.
        /// </summary>
        [ForeignKey(nameof(InventoryItemId))]
        public virtual InventoryItem Item { get; set; } = null!;

        /// <summary>
        /// Идентификатор свойств пользовательского поля.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        [Column("field_id")]
        public int FieldId { get; set; }

        /// <summary>
        /// Объект представляющий свойства пользовательского поля.
        /// <para/>
        /// Тип: <see cref="CustomFieldDefenition"/>.
        /// </summary>
        [ForeignKey(nameof(FieldId))]
        public virtual CustomFieldDefenition FieldDefenition { get; set; } = null!;

        /// <summary>
        /// Значение пользовательского поля.
        /// <para/>
        /// <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Предназначен для хранения любых типов данных с последующей конвертацией.
        /// </summary>
        [Column("value")]
        public string? Value { get; set; }
    }
}
