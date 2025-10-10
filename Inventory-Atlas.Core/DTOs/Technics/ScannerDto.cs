using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для сканера как устройства.
    /// <para/>
    /// Тип: <see cref="ScannerDto"/>
    /// <para/>
    /// Наследуется от <see cref="DeviceDto"/> и содержит информацию о IP-адресе, разрешении и цветности сканирования.
    /// </summary>
    public class ScannerDto : DeviceDto
    {
        /// <summary>
        /// IP-адрес сканера.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// Разрешение сканирования в dpi.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Dpi { get; set; }

        /// <summary>
        /// Признак цветного сканирования.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool Color { get; set; }
    }
}
