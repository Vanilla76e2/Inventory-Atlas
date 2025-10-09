using Inventory_Atlas.Core.DTOs.Common;
using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.DTOs.Audit
{
    public class LogEntryDto : BaseDto
    {
        public DateTime ActionTime { get; set; }
        public Guid UserSessionId { get; set; }
        public ActionType Action { get; set; }
        public string? EntityName { get; set; }
        public int? EntityId { get; set; }
        public string Changes { get; set; } = "{}";
    }

    /// <summary>
    /// DTO для пагинации логов.
    /// </summary>
    public class PagedLogEntryDto : BaseDto
    {
        public int TotalCount { get; set; }          // всего записей
        public int PageNumber { get; set; }          // текущая страница
        public int PageSize { get; set; }            // размер страницы
        public List<LogEntryDto> Items { get; set; } = new();
    }
}
