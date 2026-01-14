namespace Inventory_Atlas.Application.Auditor.Scope
{
    public interface IAuditScope : IDisposable
    {
        AuditContext Context { get; }
    }
}
