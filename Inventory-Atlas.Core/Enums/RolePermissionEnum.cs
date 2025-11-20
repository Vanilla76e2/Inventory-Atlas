using System.ComponentModel.DataAnnotations;

namespace Inventory_Atlas.Core.Enums
{
    /// <summary>
    /// Права роли или пользователя относительно ресурса.
    /// </summary>
    public enum RolePermissionEnum
    {
        /// <summary>
        /// Нет доступа — пользователь не может просматривать или изменять ресурс.
        /// </summary>
        [Display(Name = "Нет доступа")]
        None = 0,

        /// <summary>
        /// Только чтение — пользователь может просматривать ресурс, но не изменять его.
        /// </summary>
        [Display(Name = "Только чтение")]
        Read = 1,

        /// <summary>
        /// Чтение и запись — пользователь может просматривать и изменять ресурс.
        /// </summary>
        [Display(Name = "Чтение и запись")]
        ReadWrite = 2
    }
}
