using Audit.Core;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Atlas.Application.Auditor.Service
{
    public interface IAuditService
    {
        Scope.IAuditScope BeginScope(AuditContext context);

        Task SaveAsync(DbContext dbContext, CancellationToken ct);
    }
}
