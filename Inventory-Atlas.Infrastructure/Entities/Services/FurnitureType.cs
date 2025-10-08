using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Services
{
    /// <summary>
    /// Тип мебели.
    /// <para/>
    /// Содержит наименование типа мебели и связь с объектами мебели.
    /// </summary>
    [Table("FurnitureTypes", Schema = "Services")]
    public class FurnitureType : BaseEntity
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
