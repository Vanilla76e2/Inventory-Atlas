using Inventory_Atlas.Application.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Application.Entities.Users
{
    /// <summary>
    /// Роль пользователя.
    /// <para/>
    /// Содержит название роли и навигационное свойство на пользователей с этой ролью.
    /// </summary>
    [Table("Roles", Schema = "Users")]
    public class Role : AuditableEntity
    {
        /// <summary>
        /// Название роли.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>. Максимальная длина 100 символов.
        /// </summary>
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }
        /// <summary>
        /// Коллекция пользователей, связанных с этой ролью.
        /// <para/>
        /// Тип: <see cref="ICollection{UserProfile}"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [InverseProperty(nameof(UserProfile.Role))]
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

        /// Флаг, указывающий, является ли роль системной.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="false"/>.
        /// </summary>
        [Column("is_system")]
        public bool IsSystem { get; set; } = false;

        /// <summary>
        /// JSON-строка с правами доступа для роли.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>. По умолчанию пустой объект JSON.
        /// </summary>
        [Column("permissions", TypeName = "jsonb")]
        public string PermissionJson { get; set; } = "{}";
    }
}
