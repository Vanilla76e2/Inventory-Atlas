using Audit.Core;
using Inventory_Atlas.Application.Entities.Audit;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Inventory_Atlas.Application.Auditor.Service
{
    public class AuditService : IAuditService
    {
        private readonly AsyncLocal<Scope.IAuditScope?> _currentScope = new();

        public AuditService()
        {
        }

        public Scope.IAuditScope BeginScope(AuditContext context)
        {
            if (_currentScope.Value != null)
            {
                throw new InvalidOperationException(
                    "AuditScope is already active. Nested scopes are not supported.");
            }

            var scope = new Scope.AuditScope(context, onDispose: () => _currentScope.Value = null);

            _currentScope.Value = scope;
            return scope;
        }

        public async Task SaveAsync(DbContext dbContext, CancellationToken ct)
        {
            var scope = _currentScope.Value;
            if (scope == null)
                return;

            var changes = CollectChanges(dbContext);

            var auditLog = new AuditLog
            {
                OccurredAt = DateTime.UtcNow,
                UserId = scope.Context.UserId,
                SessionToken = scope.Context.SessionToken,
                ActionType = scope.Context.ActionType,
                TargetType = scope.Context.TargetType,
                TargetId = scope.Context.TargetId,
                Details = scope.Context.Details is null
                    ? null
                    : JsonConvert.SerializeObject(scope.Context.Details),
                Changes = changes
            };

            dbContext.Set<AuditLog>().Add(auditLog);
            await dbContext.SaveChangesAsync(ct);
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
