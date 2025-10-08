using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Источник бесперебойного питания (UPS).
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит основные характеристики устройства.
    /// </summary>
    [Table("UPSs", Schema = "Technics")]
    public class UPS : Equipment
    {
        /// <summary>
        /// Модель UPS.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть <see langword="null"/>.
        /// </summary>
        [Column("model")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// Серийный номер UPS.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("serial_number")]
        public string? SerialNumber { get; set; }

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
