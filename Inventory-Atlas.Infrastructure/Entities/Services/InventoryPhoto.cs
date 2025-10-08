using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Services
{
    /// <summary>
    /// Фотография оборудования.
    /// <para/>
    /// Содержит информацию о пути к файлу фотографии, принадлежности к конкретному оборудованию
    /// и флаг первичной фотографии.
    /// </summary>
    [Table("EquipmentPhotos", Schema = "Technics")]
    public class InventoryPhoto : BaseEntity
    {
        /// <summary>
        /// Идентификатор объекта, к которому относится фотография.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("inventory_item_id")]
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Навигационное свойство на объект.
        /// <para/>
        /// Тип: <see cref="InventoryItem"/>.
        /// <para/>
        /// Обеспечивает доступ к объекту, которому принадлежит фотография.
        /// </summary>
        [ForeignKey(nameof(InventoryItemId))]
        public virtual InventoryItem InventoryItem { get; set; } = null!;

        /// <summary>
        /// Путь к файлу фотографии.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("photo_path")]
        public string PhotoPath { get; set; } = null!;

        /// <summary>
        /// Флаг, указывающий, является ли фотография основной для оборудования.
        /// <para/>
        /// Тип: <see cref="bool"/>.
        /// <para/>
        /// По умолчанию false.
        /// </summary>
        [Column("is_primary")]
        public bool IsPrimary { get; set; } = false;
    }
}
