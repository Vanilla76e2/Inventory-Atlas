using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Inventory
{
    /// <summary>
    /// Мебель в инвентаре компании.
    /// <para/>
    /// Содержит информацию о типе, габаритах, весе, ориентации и материалах мебели.
    /// </summary>
    [Table("Furniture", Schema = "Inventory")]
    public class Furniture : InventoryItem
    {
        /// <summary>
        /// Идентификатор типа мебели.
        /// <para/>
        /// Тип: <see cref="FurnitureType"/>.
        /// </summary>
        [Column("type")]
        public int FurnitureTypeId { get; set; }

        /// <summary>
        /// Навигационное свойство на тип мебели.
        /// <para/>
        /// Тип: <see cref="FurnitureType"/>.
        /// <para/>
        /// Позволяет получить подробную информацию о типе мебели.
        /// </summary>
        [ForeignKey(nameof(FurnitureTypeId))]
        public FurnitureType FurnitureType { get; set; } = new FurnitureType();

        /// <summary>
        /// Габариты мебели (например, "200x80x75 см").
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>, если размеры не указаны.
        /// </summary>
        [Column("dimensions")]
        public string? Dimensions { get; set; }

        /// <summary>
        /// Вес мебели в килограммах.
        /// <para/>
        /// Тип: <see langword="double"/>.
        /// </summary>
        [Column("weight")]
        public double? Weight { get; set; }

        /// <summary>
        /// Ориентация мебели (например, горизонтальная, вертикальная).
        /// <para/>
        /// Тип: <see cref="FurnitureOrientation"/>.
        /// <para/>
        /// По умолчанию <see cref="FurnitureOrientation.None"/>.
        /// </summary>
        [Column("orientation")]
        public FurnitureOrientation Orientation { get; set; } = FurnitureOrientation.None;

        /// <summary>
        /// Коллекция материалов, из которых изготовлена мебель.
        /// <para/>
        /// Тип: <see cref="ICollection{FurnitureMaterialAssignment}"/>.
        /// <para/>
        /// Навигационное свойство для получения всех материалов, связанных с мебелью.
        /// </summary>
        [InverseProperty(nameof(FurnitureMaterialAssignment.Furniture))]
        public virtual ICollection<FurnitureMaterialAssignment> Materials { get; set; } = new List<FurnitureMaterialAssignment>();
    }
}
