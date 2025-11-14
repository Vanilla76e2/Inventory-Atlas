using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Employees
{
    /// <summary>
    /// DTO для подразделения компании.
    /// <para/>
    /// Тип: <see cref="DepartmentDto"/>
    /// <para/>
    /// Наследуется от <see cref="AuditableDto"/> и содержит название, комментарий и список сотрудников (опционально для UI).
    /// </summary>
    public class DepartmentDto : BaseDto
    {
        /// <summary>
        /// Название подразделения.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Комментарий к подразделению.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Список сотрудников подразделения.
        /// <para/>
        /// Тип: <see cref="List{EmployeeSummaryDto}"/>
        /// <para/>
        /// Может быть <c>null</c>, используется опционально для UI.
        /// </summary>
        public List<EmployeeListDto>? Employees { get; set; }
    }
}
