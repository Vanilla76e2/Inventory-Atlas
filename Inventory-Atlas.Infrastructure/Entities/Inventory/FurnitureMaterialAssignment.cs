using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Dictionaries;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Inventory
{
    /// <summary>
    /// Назначение материала для конкретного предмета мебели.
    /// <para/>
    /// Связывает мебель с материалом, из которого она изготовлена.
    /// </summary>
    [Table("FurnitureMaterialAssignments", Schema = "Inventory")]
    public class FurnitureMaterialAssignment : BaseEntity
    {
        /// <summary>
        /// Идентификатор мебели.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("furniture_id")]
        public int FurnitureId { get; set; }

        /// <summary>
        /// Навигационное свойство на мебель.
        /// <para/>
        /// Тип: <see cref="Furniture"/>.
        /// <para/>
        /// Позволяет получить информацию о мебели, к которой относится материал.
        /// </summary>
        [ForeignKey(nameof(FurnitureId))]
        public Furniture Furniture { get; set; } = new Furniture();

        /// <summary>
        /// Идентификатор материала.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("material_id")]
        public int MaterialId { get; set; }

        /// <summary>
        /// Навигационное свойство на материал мебели.
        /// <para/>
        /// Тип: <see cref="FurnitureMaterial"/>.
        /// <para/>
        /// Позволяет получить информацию о материале, назначенном мебели.
        /// </summary>
        [ForeignKey(nameof(MaterialId))]
        public FurnitureMaterial FurnitureMaterial { get; set; } = new FurnitureMaterial();
    }
}
