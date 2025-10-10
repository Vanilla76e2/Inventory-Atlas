using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для телефона как устройства.
    /// <para/>
    /// Тип: <see cref="PhoneDto"/>
    /// <para/>
    /// Наследуется от <see cref="DeviceDto"/> и содержит номер телефона.
    /// </summary>
    public class PhoneDto : DeviceDto
    {
        /// <summary>
        /// Номер телефона устройства.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}
