using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Users
{
    /// <summary>
    /// DTO для роли пользователя.
    /// <para/>
    /// Тип: <see cref="RoleDto"/>
    /// <para/>
    /// Наследуется от <see cref="BaseDto"/> и содержит информацию о наименовании роли, описании, системности и количестве пользователей.
    /// </summary>
    public class RoleDto : BaseDto
    {
        /// <summary>
        /// Наименование роли.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание роли.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c>.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Признак системной роли.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Количество пользователей, которым назначена роль.
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int UserCount { get; set; }
    }

    /// <summary>
    /// DTO для роли пользователя с набором прав.
    /// <para/>
    /// Тип: <see cref="RolePermissionsDto"/>
    /// <para/>
    /// Наследуется от <see cref="RoleDto"/> и содержит JSON-строку с правами доступа.
    /// </summary>
    public class RolePermissionsDto : RoleDto
    {
        /// <summary>
        /// JSON-строка с правами роли.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Значение по умолчанию: <c>"[]"</c>.
        /// </summary>
        public string PermissionJson { get; set; } = "[]";
    }
}
