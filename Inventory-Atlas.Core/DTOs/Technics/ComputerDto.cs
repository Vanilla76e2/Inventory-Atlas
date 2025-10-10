namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для компьютера как оборудования.
    /// <para/>
    /// Тип: <see cref="ComputerDto"/>
    /// <para/>
    /// Наследуется от <see cref="EquipmentDto"/> и содержит информацию о серверности, IP-адресе, операционной системе и компонентах.
    /// </summary>
    public class ComputerDto : EquipmentDto
    {
        /// <summary>
        /// Признак того, что компьютер является сервером.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsServer { get; set; }

        /// <summary>
        /// IP-адрес компьютера.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// Название и версия операционной системы.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? OperatingSystem { get; set; }

        /// <summary>
        /// Список компонентов компьютера.
        /// <para/>
        /// Тип: <see cref="List{ComputerComponentDto}"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public List<ComputerComponentDto>? Components { get; set; }
    }
}
