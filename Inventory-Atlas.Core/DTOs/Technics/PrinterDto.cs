using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для принтера как устройства.
    /// <para/>
    /// Тип: <see cref="PrinterDto"/>
    /// <para/>
    /// Наследуется от <see cref="DeviceDto"/> и содержит информацию о IP-адресе, картридже, цветности и наличии сканера.
    /// </summary>
    public class PrinterDto : DeviceDto
    {
        /// <summary>
        /// IP-адрес принтера.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// Модель картриджа, установленного в принтере.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? CartridgeModel { get; set; }

        /// <summary>
        /// Количество оставшегося картриджа в процентах или единицах.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public int? CartridgeLeft { get; set; }

        /// <summary>
        /// Признак цветной печати.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool Color { get; set; }

        /// <summary>
        /// Признак наличия сканера.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool HasScanner { get; set; }
    }
}
