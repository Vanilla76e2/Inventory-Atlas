using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Employees;

namespace Inventory_Atlas.Core.DTOs.Technics
{
    /// <summary>
    /// DTO для записи журнала технического обслуживания оборудования.
    /// <para/>
    /// Тип: <see cref="MaintenanceLogDto"/>
    /// </summary>
    public class MaintenanceLogDto : BaseDto
    {
        /// <summary>
        /// Идентификатор обслуживаемого устройства.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// Дата проведения обслуживания.
        /// <para/>
        /// Тип: <see cref="DateTime"/>
        /// </summary>
        public DateTime MaintenanceDate { get; set; }

        /// <summary>
        /// Тип обслуживания.
        /// <para/>
        /// Тип: <see cref="Core.Enums.MaintenanceType"/>
        /// </summary>
        public Core.Enums.MaintenanceType MaintenanceType { get; set; }

        /// <summary>
        /// Идентификатор сотрудника, выполнившего обслуживание.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int PerformedBy { get; set; }

        /// <summary>
        /// Комментарий к обслуживанию.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Обслуживаемое устройство.
        /// <para/>
        /// Тип: <see cref="EquipmentDto"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public EquipmentDto? Device { get; set; }

        /// <summary>
        /// Сотрудник, выполнивший обслуживание.
        /// <para/>
        /// Тип: <see cref="EmployeeDto"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public EmployeeDto? Employee { get; set; }
    }
}
