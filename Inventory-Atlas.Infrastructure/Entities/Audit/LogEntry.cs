using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Threading.Channels;

namespace Inventory_Atlas.Infrastructure.Entities.Audit
{
    /// <summary>
    /// Запись журнала аудита действий пользователей.
    /// <para/>
    /// Содержит информацию о выполненном действии, связанной сущности
    /// и сессии пользователя, совершившей действие.
    /// </summary>
    [Table("LogEntries", Schema = "Audit")]
    public class LogEntry : BaseEntity
    {
        /// <summary>
        /// Время совершения действия.
        /// <para/>
        /// Тип: <see cref="DateTime"/> (UTC).
        /// <para/>
        /// По умолчанию устанавливается текущее время UTC.
        /// </summary>
        [Column("action_time")]
        public DateTime ActionTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Идентификатор сессии пользователя, совершившего действие.
        /// <para/>
        /// Тип: <see cref="Guid"/>.
        /// <para/>
        /// Используется для связи с сущностью <see cref="Audit.UserSession"/>.
        /// </summary>
        [Column("user_session")]
        public Guid UserSessionId { get; set; }

        /// <summary>
        /// Навигационное свойство на сессию пользователя, совершившего действие.
        /// <para/>
        /// Тип: <see cref="Audit.UserSession"/>.
        /// <para/>
        /// Используется для доступа к дополнительной информации о сессии.
        /// </summary>
        [ForeignKey(nameof(UserSessionId))]
        public virtual UserSession UserSession { get; set; } = null!;

        /// <summary>
        /// Действие, которое было совершено (например, Create, Update, Delete).
        /// <para/>
        /// Тип: <see cref="ActionType"/>.
        /// <para/>
        /// Обязательное поле, не может быть <see langword="null"/>.
        /// </summary>
        [Column("action")]
        public ActionType Action { get; set; }

        /// <summary>
        /// JSON со всеми деталями действия.
        /// Включает информацию о сущности (тип, ключ) и список изменений.
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// <para/>
        /// Может быть <see langword="null"/>, если действие не связано с изменением данных.
        /// </summary>
        [Column("details", TypeName = "jsonb")]
        public string? Details { get; set; } = "{}";
    }
}
