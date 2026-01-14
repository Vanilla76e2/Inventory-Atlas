using Inventory_Atlas.Application.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Application.Entities.Technics
{
    /// <summary>
    /// Сущность сканера.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит модель, серийный номер, IpAddress-адрес и характеристики устройства.
    /// </summary>
    [Table("Scanners", Schema = "Technics")]
    public class Scanner : DeviceEntity, IHasIpAddress
    {
        /// <summary>
        /// IpAddress-адрес сканера.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("ip_address")]
        public IPAddress? IpAddress { get; set; }

        /// <summary>
        /// Разрешение сканирования в DPI.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("dpi")]
        public int? Dpi { get; set; }

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
