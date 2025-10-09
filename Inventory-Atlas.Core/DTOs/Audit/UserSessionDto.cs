using System.Net;

namespace Inventory_Atlas.Core.DTOs.Audit
{
    /// <summary>
    /// DTO сессии пользователя.
    /// <para/>
    /// <see cref="LogEntries"/> Для UI: список действий в сессии.
    /// </summary>
    public class UserSessionDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsActive { get; set; }
        public string? IP { get; set; }

        public List<LogEntryDto>? LogEntries { get; set; }
    }

    /// <summary>
    /// DTO для упрощённого отображения UserSession без логов.
    /// </summary>
    public class UserSessionSummaryDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsActive { get; set; }
        public string? IP { get; set; }
    }
}
