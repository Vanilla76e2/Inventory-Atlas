using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Services
{
    /// <summary>
    /// Категория инвентарных объектов.
    /// <para/>
    /// Содержит наименование категории и описание.
    /// </summary>
    [Table("InventoryCtegories", Schema = "Services")]
    public class InventoryCategory : BaseEntity
    {
        /// <summary>
        /// Наименование категории.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть <see langword="null"/>.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание категории.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть <see langword="null"/>.
        /// </summary>
        [Column("description")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Список пользовательских полей для категории в формате JSON.
        /// Пример: [{"Name":"Материал","Type":"string"},{"Name":"Вес","Type":"decimal"}]
        /// </summary>
        [Column("custom_fields", TypeName = "jsonb")]
        public string CustomFields { get; set; } = "[]";

        /// <summary>
        /// Коллекция элементов инвентаря, принадлежащих данной категории.
        /// <para/>
        /// Тип: <see cref="ICollection{GenericInventoryItem}"/>.
        /// <para/>
        /// Навигационное свойство для связи категории с её элементами.
        /// </summary>
        [InverseProperty(nameof(GenericInventoryItem.Category))]
        public virtual ICollection<GenericInventoryItem> Items { get; set; } = new List<GenericInventoryItem>();
    }
}
