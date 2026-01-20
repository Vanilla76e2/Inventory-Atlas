using Microsoft.EntityFrameworkCore;

namespace Inventory_Atlas.Auditor
{
    public interface IAuditService
    {
        IAuditScope BeginScope(AuditContext context);

        void RegisterAudit(DbContext dbContext, AuditContext context);
    }
}
