using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.Models
{
    /// <summary>
    /// Модель прав роли пользователя.
    /// </summary>
    public class RolePermission
    {
        /// <summary>
        /// Глобальные права администратора.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Список прав на объекты инвентаризации.
        /// <para/>
        /// Тип: List <see cref="ObjectPermission"/>.
        /// </summary>
        public List<ObjectPermission> InventoryItemsPermissions { get; set; } = new();

        /// <summary>
        /// Список прав на документы.
        /// <para/>
        /// Тип: List <see cref="ObjectPermission"/>.
        /// </summary>
        public List<ObjectPermission> DocumentsPermissions { get; set; } = new();

        /// <summary>
        /// Список прав на словари.
        /// <para/>
        /// Тип: Dictionary с ключом <see langword="string"/> и значением <see cref="RolePermissionEnum"/>.
        /// </summary>
        public Dictionary<DictionariesEnum, RolePermissionEnum> DictionaryPermissions { get; set; } = new();

        /// <summary>
        /// Права на управление рабочими местами пользователей.
        /// <para/>
        /// Тип: <see cref="RolePermissionEnum"/>.
        /// </summary>
        public RolePermissionEnum Workplaces { get; set; } = RolePermissionEnum.None;
    }

    /// <summary>
    /// Объект прав на конкретный тип сущности.
    /// </summary>
    public class ObjectPermission
    {
        /// <summary>
        /// Уровень прав на объект.
        /// <para/>
        /// Тип: <see cref="RolePermissionEnum"/>.
        /// </summary>
        public RolePermissionEnum Level { get; set; }

        /// <summary>
        /// Список идентификаторов ответственных пользователей для объекта.
        /// <para/>
        /// Тип: List <see langword="int"/>.
        /// </summary>
        public List<int> ResponsibleIds { get; set; } = new();
    }
}
