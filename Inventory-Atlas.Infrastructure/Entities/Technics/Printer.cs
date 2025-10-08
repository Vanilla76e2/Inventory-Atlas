using Inventory_Atlas.Infrastructure.Entities.Base;
using Inventory_Atlas.Infrastructure.Entities.Сonsumables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Technics
{
    /// <summary>
    /// Сущность принтера.
    /// <para/>
    /// Наследуется от <see cref="Equipment"/> и содержит модель, серийный номер, IP-адрес,
    /// связанный картридж и характеристики устройства.
    /// </summary>
    [Table("Printers", Schema = "Technics")]
    public class Printer : Equipment, IHasIpAddress
    {
        /// <summary>
        /// Модель принтера.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Максимальная длина — 255 символов.
        /// </summary>
        [Column("model")]
        [StringLength(255)]
        public string? Model { get; set; }

        /// <summary>
        /// Серийный номер принтера.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Максимальная длина — 255 символов.
        /// </summary>
        [Column("serial_number")]
        [StringLength(255)]
        public string? SerialNumber { get; set; }

        /// <summary>
        /// IP-адрес принтера.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("ip_address")]
        public IPAddress? IP { get; set; }

        /// <summary>
        /// Идентификатор картриджа, установленного в принтере.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("cartridge_id")]
        public int CartridgeId{ get; set; }

        /// <summary>
        /// Навигационное свойство на картридж.
        /// <para/>
        /// Тип: <see cref="PrinterCartrige"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(CartridgeId))]
        public virtual PrinterCartrige? Cartridge { get; set; }

        /// <summary>
        /// Флаг цветной печати.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="false"/>.
        /// </summary>
        [Column("color")]
        public bool Color { get; set; } = false;

        /// <summary>
        /// Флаг наличия сканера.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="false"/>.
        /// </summary>
        [Column("has_scanner")]
        public bool HasScanner { get; set; } = false;
    }
}
