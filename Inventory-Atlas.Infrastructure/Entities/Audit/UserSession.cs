using Inventory_Atlas.Infrastructure.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Entities.Audit
{
    /// <summary>
    /// Сессия пользователя в системе.
    /// <para/>
    /// Содержит информацию о пользователе, времени начала и окончания сессии,
    /// активности и связанных действиях в журнале аудита.
    /// </summary>
    [Table("User_Sessions", Schema = "Audit")]
    public class UserSession
    {
        /// <summary>
        /// Идентификатор сессии.
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// <para/>
        /// Является первичным ключом таблицы.
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Уникальный токен сессии.
        /// <para/>
        /// Тип: <see cref="Guid"/>.
        /// </summary>
        [Column("token")]
        public Guid Token { get; set; }

        /// <summary>
        /// Имя пользователя, которому принадлежит сессия.
        /// <para/>
        /// Тип: <see cref="string"/>.
        /// <para/>
        /// Обязательное поле, не может быть null.
        /// </summary>
        [Column("username")]
        public string Username { get; set; } = null!;

        /// <summary>
        /// Идентификатор пользователя, которому принадлежит сессия.
        /// <para/>
        /// Тип: <see langword="int"/>?.
        /// <para/>
        /// Может быть null, если пользователь удалён.
        /// </summary>
        [Column("user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// Объект профиля пользователя, которому принадлежит сессия.
        /// <para/> 
        /// Тип: <see cref="UserProfile"/>?.
        /// <para/>
        /// Может быть null, если пользователь удалён.
        /// </summary>
        [ForeignKey("UserId")]
        public virtual UserProfile? UserProfile { get; set; }

        /// <summary>
        /// Время начала сессии.
        /// <para/>
        /// Тип: <see cref="DateTime"/>.
        /// <para/>
        /// Указывается в UTC.
        /// </summary>
        [Column("start_time")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Время окончания сессии.
        /// <para/>
        /// Тип: <see cref="DateTime"/>?.
        /// <para/>
        /// Может быть null, если сессия ещё активна.
        /// </summary>
        [Column("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Флаг активности сессии.
        /// <para/>
        /// Тип: <see cref="bool"/>.
        /// <para/>
        /// По умолчанию true.
        /// </summary>
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// IpAddress-адрес пользователя, с которого была создана сессия.
        /// <para/>
        /// Тип: <see cref="IPAddress"/>?.
        /// <para/>
        /// Может быть null, если IpAddress-адрес не определён.
        /// </summary>
        [Column("ip_address")]
        public IPAddress? IpAddress {  get; set; }

        /// <summary>
        /// Агент пользователя (User-Agent) при создании сессии.
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть null, если информация не предоставлена.
        /// </summary>
        [Column("user_agent")]
        public string? UserAgent { get; set; }

        /// <summary>
        /// Коллекция записей журнала аудита, связанных с данной сессией.
        /// <para/>
        /// Тип: <see cref="ICollection{LogEntry}"/>.
        /// <para/>
        /// Используется для навигации к действиям пользователя в системе.
        /// </summary>
        [InverseProperty(nameof(LogEntry.UserSession))]
        public virtual ICollection<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
    }
}
