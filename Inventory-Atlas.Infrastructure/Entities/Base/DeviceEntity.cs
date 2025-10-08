using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Base
{
    /// <summary>
    /// Абстрактная сущность устройства.
    /// <para/>
    /// Содержит общие свойства для всех типов устройств в системе, включая имя, инвентарный номер,
    /// ответственного сотрудника, местоположение и статус.
    /// </summary>
    public abstract class DeviceEntity : InventoryItem
    {
        /// <summary>
        /// Название устройства.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Комментарий по устройству.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может содержать дополнительные сведения, примечания или инструкции.
        /// </summary>
        [Column("comment")]
        public string? Comment { get; set; }
    }
}
