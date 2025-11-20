
using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Audit;

namespace Inventory_Atlas.Application.Services.Audit
{
    public interface ILogEntryService
    {
        Task LogAsync(ActionType action, string? details, CancellationToken ct = default);
        Task LogAndSaveAsync(ActionType action, string? details, CancellationToken ct = default);
        Task LogLoginAsync(ActionType action, int UserSessionId, CancellationToken ct = default);
        Task<IReadOnlyList<LogEntry>> GetAllAsync(CancellationToken ct = default);
        Task<IReadOnlyList<LogEntry>> GetByUserAsync(int userSessionId, CancellationToken ct = default);
        Task<IReadOnlyList<LogEntry>> GetByActionAsync(ActionType action, CancellationToken ct = default);
        Task<IReadOnlyList<LogEntry>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default);
    }
}
