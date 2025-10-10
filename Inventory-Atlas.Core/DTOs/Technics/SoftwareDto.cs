namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для программного обеспечения.
    /// <para/>
    /// Тип: <see cref="SoftwareDto"/>
    /// <para/>
    /// Наследуется от <see cref="EquipmentDto"/> и содержит информацию о вендоре ПО.
    /// </summary>
    public class SoftwareDto : EquipmentDto
    {
        /// <summary>
        /// Вендор/разработчик программного обеспечения.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Vendor { get; set; }
    }

    /// <summary>
    /// DTO для программного обеспечения с административными данными.
    /// <para/>
    /// Тип: <see cref="SoftwareAdminDto"/>
    /// <para/>
    /// Наследуется от <see cref="SoftwareDto"/> и содержит лицензионный ключ.
    /// </summary>
    public class SoftwareAdminDto : SoftwareDto
    {
        /// <summary>
        /// Лицензионный ключ программного обеспечения.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? LicenceKey { get; set; }
    }
}
