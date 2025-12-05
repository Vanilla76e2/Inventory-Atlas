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
        [Display(Name = "Unknown")]
        Unknown = 0,

        /// <summary>
        /// Создание записи.
        /// </summary>
        [Display(Name = "Создание записи")]
        Create = 1,

        /// <summary>
        /// Обновление записи.
        /// </summary>
        [Display(Name = "Обновление записи")]
        Update = 2,

        /// <summary>
        /// Удаление записи.
        /// </summary>
        [Display(Name = "Удаление записи")]
        Delete = 3,

        /// <summary>
        /// Мягкое удаление записи (soft delete).
        /// </summary>
        [Display(Name = "Мягкое удаление")]
        SoftDelete = 4,

        /// <summary>
        /// Восстановление записи после мягкого удаления.
        /// </summary>
        [Display(Name = "Восстановление записи")]
        Restore = 5,

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        [Display(Name = "Авторизация пользователя")]
        Login = 6,

        /// <summary>
        /// Выход пользователя.
        /// </summary>
        [Display(Name = "Выход пользователя")]
        Logout = 7,

        /// <summary>
        /// Назначение оборудования или сотрудника.
        /// </summary>
        [Display(Name = "Назначение оборудования/сотрудника")]
        Assign = 8,

        /// <summary>
        /// Снятие назначения оборудования или сотрудника.
        /// </summary>
        [Display(Name = "Снятие назначения")]
        Unassign = 9
    }
}
