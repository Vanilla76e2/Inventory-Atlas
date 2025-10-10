using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace Inventory_Atlas.Infrastructure.Entities.Dictionaries
{
    /// <summary>
    /// Материал, используемый для мебели.
    /// <para/>
    /// Содержит наименование материала и связь с мебелью через таблицу назначений.
    /// </summary>
    [Table("FurnitureMaterials", Schema = "Dictionaries")]
    public class FurnitureMaterial : BaseEntity
    {
        /// <summary>
        /// Наименование материала.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть <see langword="null"/>.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Коллекция назначений материала для мебели.
        /// <para/>
        /// Тип: <see cref="ICollection{FurnitureMaterialAssignment}"/>.
        /// <para/>
        /// Навигационное свойство, позволяющее получить все записи мебели, в которых используется данный материал.
        /// </summary>
        [InverseProperty(nameof(FurnitureMaterialAssignment.FurnitureMaterial))]
        public virtual ICollection<FurnitureMaterialAssignment> FurnitureMaterialAssignments { get; set; } = new List<FurnitureMaterialAssignment>();
    }
}
