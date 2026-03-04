using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Models;

namespace Inventory_Atlas.Core.DTOs.Users
{
    /// <summary>
    /// DTO роли пользователя.
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
    /// Тип: <see cref="RoleWithPermissionsDto"/>
    /// <para/>
    /// Наследуется от <see cref="RoleDto"/> и содержит JSON-строку с правами доступа.
    /// </summary>
    public class RoleWithPermissionsDto
    {
        /// <summary>
        /// Идентификатор роли.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование роли.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Объект представляющий права роли.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <see langword="null"/>. По умолчанию пустой объект.
        /// </summary>
        public RolePermissions Permission { get; set; } = new();
    }

    /// <summary>
    /// DTO для создания роли пользователя.
    /// </summary>
    public class RoleCreateDto
    {
        /// <summary>
        /// Имя роли.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание роли.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Объект представляющий права роли.
        /// </summary>
        public RolePermissions Permission { get; set; } = new();
    }

    /// <summary>
    /// DTO для обновления роли пользователя.
    /// </summary>
    public class RoleUpdateDto
    {
        /// <summary>
        /// Id изменяемой роли.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Новое имя роли.
        /// <para/>
        /// Если <see langword="null"/>, имя роли не изменяется.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Новое описание роли.
        /// <para/>
        /// Если <see langword="null"/>, описание роли не изменяется.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Новые права роли.
        /// <para/>
        /// Если <see langword="null"/>, права роли не изменяются.
        /// </summary>
        /// <remarks>
        /// Полностью заменяет существующие права роли.
        /// </remarks>
        public RolePermissions? Permissions { get; set; }
    }
}
