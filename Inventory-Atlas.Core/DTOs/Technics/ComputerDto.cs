using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Inventory;

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

    public class ComputerDetailDto : ComputerDto
    {
        /// <summary>
        /// Список привязок оборудования к рабочим местам.
        /// <para/>
        /// Тип: <see cref="List{WorkplaceEquipmentDto}"/>
        /// <para/>
        /// Инициализируется пустым списком по умолчанию.
        /// </summary>
        public List<WorkplaceEquipmentDto> WorkplaceEquipments { get; set; } = new();

        /// <summary>
        /// Журналы технического обслуживания оборудования.
        /// <para/>
        /// Тип: <see cref="List{MaintenanceLogDto}"/>
        /// <para/>
        /// Инициализируется пустым списком по умолчанию.
        /// </summary>
        public List<MaintenanceLogDto> MaintenanceLogs { get; set; } = new();
    }

    /// <summary>
    /// DTO для компонента компьютера.
    /// <para/>
    /// Тип: <see cref="ComputerComponentDto"/>
    /// <para/>
    /// Содержит общие свойства для всех компонентов, включая идентификаторы, тип компонента, количество и серийный номер.
    /// </summary>
    public class ComputerComponentDto : BaseDto
    {
        /// <summary>
        /// Идентификатор компьютера, к которому принадлежит компонент.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int ComputerId { get; set; }

        /// <summary>
        /// Тип компонента.
        /// <para/>
        /// Тип: <see cref="Enums.ComponentType"/>
        /// </summary>
        public Core.Enums.ComponentType ComponentType { get; set; }

        /// <summary>
        /// Количество данного компонента.
        /// <para/>
        /// Тип: <see langword="short"/>
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// Серийный номер компонента.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? SerialNumber { get; set; }
    }
}
