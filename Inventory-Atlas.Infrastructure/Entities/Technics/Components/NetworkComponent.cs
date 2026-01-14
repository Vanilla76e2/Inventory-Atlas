using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Technics.Components
{
    /// <summary>
    /// Компонент компьютера, представляющий сетевую карту.
    /// <para/>
    /// Наследуется от <see cref="ComputerComponent"/> и содержит информацию о модели, MAC-адресе, оптическом интерфейсе и скорости соединения.
    /// </summary>
    [Table("ComputerComponents_NetworkCard", Schema = "Technics")]
    public class NetworkComponent : ComputerComponent
    {
        /// <summary>
        /// Модель сетевой карты.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("model")]
        public string Model { get; set; } = null!;

        /// <summary>
        /// MAC-адрес сетевой карты.
        /// <para/>
        /// Тип: <see cref="string"/>?.
        /// <para/>
        /// Может быть null, если MAC-адрес не указан.
        /// </summary>
        [Column("mac_address")]
        public string? MACAddress { get; set; }

        /// <summary>
        /// Флаг, указывающий, поддерживает ли сетевой компонент оптический интерфейс.
        /// <para/>
        /// Тип: <see cref="bool"/>.
        /// <para/>
        /// По умолчанию false.
        /// </summary>
        [Column("optical")]
        public bool Optical { get; set; } = false;

        /// <summary>
        /// Скорость сетевого соединения в Мбит/с.
        /// <para/>
        /// Тип: <see cref="int"/>?.
        /// <para/>
        /// Может быть null, если информация о скорости не указана.
        /// </summary>
        [Column("speed")]
        public int? Speed { get; set; } // in Mbps
    }
}
