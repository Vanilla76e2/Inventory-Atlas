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
        /// Может быть <c>null</c>.
        /// </summary>
        public string? EmployeeName { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// <para/>
        /// Тип: <see cref="RoleDto"/>
        /// </summary>
        public string RoleName { get; set; } = null!;
    }
}
