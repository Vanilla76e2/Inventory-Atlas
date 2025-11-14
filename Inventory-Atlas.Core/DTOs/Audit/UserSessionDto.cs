namespace Inventory_Atlas.Core.DTOs.Audit
{
    /// <summary>
    /// DTO сессии пользователя.
    /// <para/>
    /// Тип: <see cref="UserSessionDto"/>
    /// <para/>
    /// <see cref="LogEntries"/> Для UI: список действий в сессии.
    /// </summary>
    public class UserSessionDto
    {
        /// <summary>
        /// Идентификатор сессии пользователя.
        /// <para/>
        /// Тип: <see langword="Guid"/>
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// Имя пользователя, которому принадлежит сессия.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Время начала сессии.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Время окончания сессии.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// <para/>
        /// Может быть <c>null</c> если сессия ещё активна.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Признак того, что сессия активна.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// IP-адрес пользователя в сессии.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если IP неизвестен.
        /// </summary>
        public string? IpAddress { get; set; }

        /// <summary>
        /// Список действий пользователя в рамках сессии.
        /// <para/>
        /// Тип: <see cref="List{LogEntryDto}"/>
        /// <para/>
        /// Может быть <c>null</c> если логов нет.
        /// </summary>
        public List<LogEntryDto>? LogEntries { get; set; }
    }

    /// <summary>
    /// DTO для упрощённого отображения UserSession без логов.
    /// <para/>
    /// Тип: <see cref="UserSessionSummaryDto"/>
    /// </summary>
    public class UserSessionListDto
    {
        /// <summary>
        /// Идентификатор сессии пользователя.
        /// <para/>
        /// Тип: <see langword="Guid"/>
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// Имя пользователя, которому принадлежит сессия.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Не может быть <c>null</c>.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Время начала сессии.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Время окончания сессии.
        /// <para/>
        /// Тип: <see langword="DateTime"/>
        /// <para/>
        /// Может быть <c>null</c> если сессия ещё активна.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Признак того, что сессия активна.
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// IP-адрес пользователя в сессии.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <c>null</c> если IP неизвестен.
        /// </summary>
        public string? IpAddress { get; set; }
    }
}
