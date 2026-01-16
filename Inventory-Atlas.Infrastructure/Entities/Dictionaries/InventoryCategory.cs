using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Dictionaries
{
    /// <summary>
    /// Категория инвентарных объектов.
    /// <para/>
    /// Содержит наименование категории и описание.
    /// </summary>
    [Table("InventoryCtegories", Schema = "Services")]
    public class InventoryCategory : AuditableEntity
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
        /// Коллекция пользовательских полей.
        /// <para/>
        /// Тип: Коллекция <see cref="CustomFieldDefenition"/>.
        /// </summary>
        [InverseProperty(nameof(CustomFieldDefenition.Category))]
        public virtual ICollection<CustomFieldDefenition> CustomFields { get; set; } = new List<CustomFieldDefenition>();
    }
}
