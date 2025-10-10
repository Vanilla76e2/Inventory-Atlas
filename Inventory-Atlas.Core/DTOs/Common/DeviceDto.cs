namespace Inventory_Atlas.Core.DTOs.Common
{
    /// <summary>
    /// Абстрактный DTO для устройств.
    /// <para/>
    /// Тип: <see cref="DeviceDto"/>
    /// <para/>
    /// Содержит общие свойства устройств: модель, серийный номер и производителя.
    /// </summary>
    public abstract class DeviceDto
    {
        /// <summary>
        /// Модель устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если модель не указана.
        /// </summary>
        public string? Model { get; set; }

        /// <summary>
        /// Серийный номер устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если серийный номер не известен.
        /// </summary>
        public string? SerialNumber { get; set; }

        /// <summary>
        /// Производитель устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если производитель не указан.
        /// </summary>
        public string? Vendor { get; set; }
    }
}
