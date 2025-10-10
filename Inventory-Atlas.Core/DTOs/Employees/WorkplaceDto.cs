using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Technics;

namespace Inventory_Atlas.Core.DTOs.Employees
{
    /// <summary>
    /// DTO для рабочего места сотрудника.
    /// <para/>
    /// Тип: <see cref="WorkplaceDto"/>
    /// <para/>
    /// Наследуется от <see cref="AuditableDto"/> и содержит название, комментарий, информацию о сотруднике и список оборудования.
    /// </summary>
    public class WorkplaceDto : AuditableDto
    {
        /// <summary>
        /// Название рабочего места.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Комментарий к рабочему месту.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Идентификатор сотрудника, которому закреплено рабочее место.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c> если рабочее место не закреплено.
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Имя сотрудника, которому закреплено рабочее место.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Список оборудования на рабочем месте.
        /// <para/>
        /// Тип: <see cref="List{WorkplaceEquipmentDto}"/>
        /// <para/>
        /// Может быть <c>null</c> если оборудование не указано.
        /// </summary>
        public List<WorkplaceEquipmentDto>? Equipments { get; set; }
    }

    /// <summary>
    /// DTO для связи оборудования с рабочим местом.
    /// <para/>
    /// Тип: <see cref="WorkplaceEquipmentDto"/>
    /// </summary>
    public class WorkplaceEquipmentDto : BaseDto
    {
        /// <summary>
        /// Идентификатор рабочего места.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int WorkplaceId { get; set; }

        /// <summary>
        /// Идентификатор оборудования.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int EquipmentId { get; set; }

        /// <summary>
        /// Навигационное свойство рабочего места.
        /// <para/>
        /// Тип: <see cref="WorkplaceDto"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public WorkplaceDto? Workplace { get; set; }

        /// <summary>
        /// Навигационное свойство оборудования.
        /// <para/>
        /// Тип: <see cref="EquipmentDto"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public EquipmentDto? Equipment { get; set; }
    }
}
