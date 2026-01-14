using Inventory_Atlas.Application.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Technics
{
    /// <summary>
    /// Источник бесперебойного питания (UPS).
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит основные характеристики устройства.
    /// </summary>
    [Table("UPSs", Schema = "Technics")]
    public class UPS : DeviceEntity
    {
        /// <summary>
        /// Мощность UPS в ваттах.
        /// <para/>
        /// Тип: <see cref="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("capacity_watts")]
        public int? CapacityWatts { get; set; }

        /// <summary>
        /// Время автономной работы в минутах.
        /// <para/>
        /// Тип: <see cref="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("autonomy_minutes")]
        public int? Autonomy { get; set; }

        /// <summary>
        /// Количество розеток.
        /// <para/>
        /// Тип: <see cref="short"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("socket_count")]
        public short? SocketCount { get; set; }
    }
}
