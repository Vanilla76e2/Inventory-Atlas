using Inventory_Atlas.Application.Entities.Technics;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Base
{
    /// <summary>
    /// Представляет запись об устройстве в инвентаре.
    /// <para/>
    /// Наследует общие свойства инвентарного объекта из <see cref="Equipment"/>.
    /// </summary>
    public class DeviceEntity : Equipment
    {
        /// <summary>
        /// Модель устройства.
        /// <para/>
        /// Обязательное поле: не может быть <see langword="null"/>.
        /// </summary>
        [Column("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Серийный номер устройства.
        /// <para/>
        /// Может быть <see langword="null"/>, если серийный номер не указан.
        /// </summary>
        [Column("serial_number")]
        public string? SerialNumber { get; set; }

        /// <summary>
        /// Поставщик или производитель устройства.
        /// <para/>
        /// Может быть <see langword="null"/>, если информация о поставщике не указана.
        /// </summary>
        [Column("vendor")]
        public string? Vendor { get; set; }
    }
}
