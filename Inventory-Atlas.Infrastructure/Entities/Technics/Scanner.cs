using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность сканера.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит модель, серийный номер, IP-адрес и характеристики устройства.
    /// </summary>
    [Table("Scanners", Schema = "Technics")]
    public class Scanner : Equipment, IHasIpAddress
    {
        /// <summary>
        /// Модель сканера.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Максимальная длина — 255 символов.
        /// </summary>
        [Column("model")]
        [StringLength(255)]
        public string? Model { get; set; }


        /// <summary>
        /// Серийный номер сканера.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Максимальная длина — 255 символов.
        /// </summary>
        [Column("serial_number")]
        [StringLength(255)]
        public string? SerialNumber { get; set; }

        /// <summary>
        /// IP-адрес сканера.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("ip_address")]
        public IPAddress? IP { get; set; }

        /// <summary>
        /// Разрешение сканирования в DPI.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("dpi")]
        public int? DPI { get; set; }

        /// <summary>
        /// Флаг цветного сканирования.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="false"/>.
        /// </summary>
        [Column("color")]
        public bool Color { get; set; } = false;
    }
}
