using Microsoft.EntityFrameworkCore;

namespace Inventory_Atlas.Infrastructure.Auditor.Service
{
    public interface IAuditService
    {
        Scope.IAuditScope BeginScope(AuditContext context);

        void RegisterAudit(DbContext dbContext, AuditContext context);
    }
}
