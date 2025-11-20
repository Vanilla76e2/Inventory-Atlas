using System.Net;

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
        /// Тип: <see langword="int"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Уникальный токен сессии.
        /// <para/>
        /// Тип: <see langword="string"/>
        /// </summary>
        public string Token { get; set; } = null!;

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
        /// Агент пользователя (браузер, устройство и т.д.).
        /// <para/>
        /// Тип: <see langword="string"/>
        /// <para/>
        /// Может быть <see langword="null"/> если информация недоступна.  
        /// </summary>
        public string? UserAgent { get; set; }

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

    /// <summary>
    /// DTO для сервиса сессий пользователя.
    /// </summary>
    public class UserSeesionServiceDto
    {
        /// <summary>
        /// Идентификатор сессии (для внутреннего использования)
        /// <para/>
        /// Тип: <see langword="int"/>.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Токен сессии (Guid)
        /// <para/>
        /// Тип: <see cref="Guid"/>.
        /// </summary>
        public Guid Token { get; set; }

        /// <summary>
        /// Имя пользователя
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Время начала сессии (UTC)
        /// <para/>
        /// Тип: <see cref="DateTime"/>.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Время окончания сессии (UTC), null если активна
        /// <para/>
        /// Тип: <see cref="DateTime"/>?.
        /// <para/>
        /// Может быть <see langword="null"/> если сессия ещё активна.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Активна ли сессия
        /// <para/>
        /// Тип: <see langword="bool"/>
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// IP-адрес пользователя
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/> если IP неизвестен.
        /// </summary>
        public IPAddress? IpAddress { get; set; }

        /// <summary>
        /// Агент пользователя (браузер, устройство и т.д.).
        /// <para/>
        /// Тип: <see langword="string"/>?.
        /// <para/>
        /// Может быть <see langword="null"/> если информация недоступна.
        /// </summary>
        public string? UserAgent { get; set; }

        /// <summary>
        /// Название роли пользователя
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// </summary>
        public string RoleName { get; set; } = null!;

        /// <summary>
        /// Права пользователя (можно десериализовать в объект)
        /// <para/>
        /// Тип: <see langword="string"/>.
        /// </summary>
        public string PermissionJson { get; set; } = "{}";

        /// <summary>
        /// Id пользователя в системе (связь с UserProfile)
        /// <para/>
        /// Тип: <see langword="int"/>
        /// </summary>
        public int UserId { get; set; }
    }
}
