using Inventory_Atlas.Core.DTOs.Audit;

namespace Inventory_Atlas.Infrastructure.Repository.Audit
{
    public interface IAuditLogRepository
    {
        Task<List<AuditLogDto>> GetLogsAsync(CancellationToken ct = default);

        Task <List<AuditLogDto>> GetLogsByTableAsync(string table, CancellationToken ct = default);

        Task<List<AuditLogDto>> GetLogsByAction(string table, CancellationToken ct = default);
    }
}
