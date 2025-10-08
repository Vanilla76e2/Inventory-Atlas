using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Atlas.Infrastructure.Entities.Users
{
    /// <summary>
    /// Профиль пользователя.
    /// <para/>
    /// Содержит данные для авторизации, контактную информацию, дату рождения, 
    /// статус активности, роль пользователя, связь с сотрудником и коллекцию избранных элементов.
    /// </summary>
    [Table("UserProfiles", Schema = "Users")]
    public class UserProfile : AuditableEntity
    {
        /// <summary>
        /// Имя пользователя (логин).
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>. Максимальная длина 100 символов.
        /// </summary>
        [Column("username")]
        [StringLength(100)]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Электронная почта пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Максимальная длина 255 символов.
        /// </summary>
        [Column("email")]
        [StringLength(255)]
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>. Максимальная длина 18 символов.
        /// </summary>
        [Column("phone_number")]
        [StringLength(18)]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// <para/>
        /// Тип: <see cref="DateTime"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Хэш пароля пользователя.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [Column("password_hash")]
        public string PasswordHash { get; set; } = null!;

        /// <summary>
        /// Флаг активности пользователя.
        /// <para/>
        /// Тип: <see langword="bool"/>.
        /// <para/>
        /// По умолчанию <see langword="true"/>.
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Идентификатор роли пользователя.
        /// <para/>
        /// Тип: <see cref="int"/>.
        /// </summary>
        [Column("role_id")]
        public int RoleId { get; set; }

        /// <summary>
        /// Навигационное свойство на роль пользователя.
        /// <para/>
        /// Тип: <see cref="Role"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; } = null!;

        /// <summary>
        /// Идентификатор сотрудника, связанного с пользователем.
        /// <para/>
        /// Тип: <see cref="int"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [Column("employee_id")]
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Навигационное свойство на сотрудника.
        /// <para/>
        /// Тип: <see cref="Employees.Employee"/>?.
        /// <para/>
        /// Может быть <see langword="null"/>.
        /// </summary>
        [ForeignKey(nameof(EmployeeId))]
        public Employees.Employee? Employee { get; set; }

        /// <summary>
        /// Коллекция избранных элементов пользователя.
        /// <para/>
        /// Тип: <see cref="ICollection{Favourite}"/>.
        /// <para/>
        /// Не может быть <see langword="null"/>.
        /// </summary>
        [InverseProperty(nameof(Favourite.User))]
        public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}
