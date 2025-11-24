using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Users
{
    /// <summary>
    /// DTO профиля пользователя.
    /// <para/>
    /// Тип: <see cref="UserProfileDto"/>
    /// <para/>
    /// Наследуется от <see cref="AuditableDto"/> и содержит информацию о пользователе, контактах, статусе активности и роли.
    /// </summary>
    public class UserProfileDto : BaseDto
    {
        /// <summary>
        /// Имя пользователя (логин).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Признак активности пользователя.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Связанное сотрудник (отображаемое имя или идентификатор).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// <para/>
        /// Тип: <see cref="RoleDto"/>
        /// </summary>
        public string RoleName { get; set; } = null!;
    }

    /// <summary>
    /// DTO для создания профиля пользователя.
    /// <para/>
    /// Содержит основные данные для регистрации нового пользователя, включая имя, пароль, роль и связь с сотрудником.
    /// </summary>
    public class UserProfileCreateDto
    {
        /// <summary>
        /// Имя пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Идентификатор связанного сотрудника.
        /// <para/>
        /// Тип: <see cref="int"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор роли пользователя.
        /// <para/>
        /// Тип: <see cref="int"/>
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Password { get; set; } = null!;
    }


    /// <summary>
    /// DTO для обновления профиля пользователя.
    /// <para/>
    /// Позволяет изменять отдельные свойства пользователя, включая имя, пароль, роль, активность и связь с сотрудником.
    /// Все свойства являются опциональными.
    /// </summary>
    public class UserProfileUpdateDto : BaseDto
    {
        /// <summary>
        /// Имя пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Идентификатор связанного сотрудника.
        /// <para/>
        /// Тип: <see cref="int"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Идентификатор роли пользователя.
        /// <para/>
        /// Тип: <see cref="int"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// Флаг активности пользователя.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        public string? Password { get; set; }
    }

}
