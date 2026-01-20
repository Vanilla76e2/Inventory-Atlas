using Inventory_Atlas.Auditor;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Inventory_Atlas.Infrastructure.Services.Audit
{
    public class AuditService : IAuditService
    {
        private readonly AsyncLocal<IAuditScope?> _currentScope = new();

        public AuditService()
        {
        }

        public IAuditScope BeginScope(AuditContext context)
        {
            if (_currentScope.Value != null)
            {
                throw new InvalidOperationException(
                    "AuditScope is already active. Nested scopes are not supported.");
            }

            var scope = new AuditScope(context, onDispose: () => _currentScope.Value = null);

            _currentScope.Value = scope;
            return scope;
        }

        public void RegisterAudit(DbContext dbContext, AuditContext context)
        {
            if (context == null)
                return;

            var changes = CollectChanges(dbContext);

            var auditLog = new AuditLog
            {
                OccurredAt = DateTime.UtcNow,
                UserId = context.UserId,
                SessionToken = context.SessionToken,
                ActionType = context.ActionType,
                TargetType = context.TargetType,
                TargetId = context.TargetId,
                Details = context.Details is null
                    ? null
                    : JsonConvert.SerializeObject(context.Details),
                Changes = changes
            };

            dbContext.Set<AuditLog>().Add(auditLog);
        }

        private List<AuditChange> CollectChanges(DbContext context)
        {
            var result = new List<AuditChange>();

            foreach (var entry in context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified))
            {
                var entityName = entry.Metadata.ClrType.Name;
                var entityId = entry.Properties
                    .First(p => p.Metadata.IsPrimaryKey())
                    .CurrentValue?.ToString() ?? "UNKNOWN";

                foreach (var prop in entry.Properties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                        continue;

                    if (Equals(prop.OriginalValue, prop.CurrentValue))
                        continue;

                    result.Add(new AuditChange
                    {
                        EntityName = entityName,
                        EntityId = entityId,
                        PropertyName = prop.Metadata.Name,
                        OldValue = prop.OriginalValue?.ToString(),
                        NewValue = prop.CurrentValue?.ToString()
                    });
                }
            }

            return result;
        }
    }
}
