using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Employees
{
    /// <summary>
    /// DTO для сотрудника компании с поддержкой мягкого удаления.
    /// <para/>
    /// Тип: <see cref="EmployeeDto"/>
    /// <para/>
    /// Наследуется от <see cref="SoftDeletableDto"/> и содержит персональные данные, принадлежность к отделу, должность и статус ответственности.
    /// </summary>
    public class EmployeeDto : SoftDeletableDto
    {
        /// <summary>
        /// Фамилия сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Surname { get; set; } = null!;

        /// <summary>
        /// Имя сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Firstname { get; set; } = null!;

        /// <summary>
        /// Отчество сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Электронная почта сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Идентификатор отдела, к которому принадлежит сотрудник.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// <para/>
        /// Может быть <c>null</c> если отдел не указан.
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Название отдела сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Должность сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Position { get; set; }

        /// <summary>
        /// Комментарий к сотруднику.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// Признак того, что сотрудник является ответственным.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsResponsible { get; set; }

        /// <summary>
        /// Полное имя сотрудника, составленное из фамилии, имени и отчества (если указано).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Рассчитывается автоматически.
        /// </summary>
        public string Fullname => string.IsNullOrWhiteSpace(Patronymic)
            ? $"{Surname} {Firstname}"
            : $"{Surname} {Firstname} {Patronymic}";
    }

    /// <summary>
    /// DTO для упрощённого отображения сотрудника (summary).
    /// <para/>
    /// Тип: <see cref="EmployeeSummaryDto"/>
    /// </summary>
    public class EmployeeSummaryDto
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Полное имя сотрудника.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Fullname { get; set; } = null!;
    }
}
