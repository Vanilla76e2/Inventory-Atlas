using Inventory_Atlas.Application.Entities.Base;
using Inventory_Atlas.Application.Entities.Сonsumables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Application.Entities.Technics
{
    /// <summary>
    /// Сущность принтера.
    /// <para/>
    /// Наследуется от <see cref="DeviceEntity"/> и содержит модель, серийный номер, IpAddress-адрес,
    /// связанный картридж и характеристики устройства.
    /// </summary>
    [Table("Printers", Schema = "Technics")]
    public class Printer : DeviceEntity, IHasIpAddress
    {
        /// <summary>
        /// IpAddress-адрес принтера.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("ip_address")]
        public IPAddress? IpAddress { get; set; }

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
        /// Тип: <see cref="PrinterCartridge"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(CartridgeId))]
        public virtual PrinterCartridge? Cartridge { get; set; }

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
