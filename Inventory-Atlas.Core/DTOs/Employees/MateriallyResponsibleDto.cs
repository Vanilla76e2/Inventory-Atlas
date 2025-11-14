using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.DTOs.Inventory;

namespace Inventory_Atlas.Core.DTOs.Employees
{
    /// <summary>
    /// DTO для материально ответственного сотрудника.
    /// <para/>
    /// Тип: <see cref="MateriallyResponsibleDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/> и содержит информацию о сотруднике, комментарий и список закреплённых за ним элементов инвентаря.
    /// </summary>
    public class MateriallyResponsibleDto : BaseDto
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Полное имя сотрудника сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string EmployeeName { get; set; } = null!;

        /// <summary>
        /// Отображаемое имя сотрудника (например, фамилия и имя).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string DisplayName { get; set; } = null!;

        /// <summary>
        /// Комментарий к материально ответственному сотруднику.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Список инвентарных элементов, закреплённых за сотрудником.
        /// <para/>
        /// Тип: <see cref="List{InventoryItemDto}"/>
        /// <para/>
        /// Может быть <c>null</c> если элементы не указаны.
        /// </summary>
        public List<InventoryItemDto>? Items { get; set; }
    }

    public class MateriallyResponsibleListDto : BaseDto
    {
        /// <summary>
        /// Полное имя сотрудника сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public int EmployeeName { get; set; }

        /// <summary>
        /// Отображаемое имя сотрудника (например, фамилия и имя).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string DisplayName { get; set; } = null!;

        /// <summary>
        /// Комментарий к материально ответственному сотруднику.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Comment { get; set; }
    }
}
