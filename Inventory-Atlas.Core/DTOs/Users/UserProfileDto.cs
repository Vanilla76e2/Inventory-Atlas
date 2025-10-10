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
    public class UserProfileDto : AuditableDto
    {
        /// <summary>
        /// Имя пользователя (логин).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Электронная почта пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public DateTime? BirthDate { get; set; }

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
        public string? Employee { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// <para/>
        /// Тип: <see cref="RoleDto"/>
        /// </summary>
        public RoleDto Role { get; set; } = null!;
    }
}
