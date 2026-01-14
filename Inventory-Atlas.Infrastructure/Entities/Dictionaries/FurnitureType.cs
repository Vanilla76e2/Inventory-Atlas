using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Dictionaries
{
    /// <summary>
    /// Тип мебели.
    /// <para/>
    /// Содержит наименование типа мебели и связь с объектами мебели.
    /// </summary>
    [Table("FurnitureTypes", Schema = "Dictionaries")]
    public class FurnitureType : AuditableEntity
    {
        /// <summary>
        /// Наименование типа мебели.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть <see langword="null"/>.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Коллекция мебели, относящейся к этому типу.
        /// <para/>
        /// Тип: <see cref="ICollection{Furniture}"/>.
        /// <para/>
        /// Навигационное свойство, позволяющее получить все объекты мебели данного типа.
        /// </summary>
        [InverseProperty(nameof(Furniture.FurnitureType))]
        public ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();
    }
}
