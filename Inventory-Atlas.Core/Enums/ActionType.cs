using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Тип действия для логирования и аудита.
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Неизвентое действие.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Создание записи.
        /// </summary>
        Create = 1,

        /// <summary>
        /// Обновление записи.
        /// </summary>
        Update = 2,

        /// <summary>
        /// Удаление записи.
        /// </summary>
        Delete = 3,

        /// <summary>
        /// Мягкое удаление записи (soft delete).
        /// </summary>
        SoftDelete = 4,

        /// <summary>
        /// Восстановление записи после мягкого удаления.
        /// </summary>
        Restore = 5,

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        Login = 6,

        /// <summary>
        /// Выход пользователя.
        /// </summary>
        Logout = 7,

        /// <summary>
        /// Назначение оборудования или сотрудника.
        /// </summary>
        Assign = 8,

        /// <summary>
        /// Снятие назначения оборудования или сотрудника.
        /// </summary>
        Unassign = 9
    }
}
