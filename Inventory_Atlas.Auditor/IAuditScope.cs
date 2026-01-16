namespace Inventory_Atlas.Infrastructure.Auditor.Scope
{
    public interface IAuditScope : IDisposable
    {
        AuditContext Context { get; }
    }
}
