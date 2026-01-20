namespace Inventory_Atlas.Auditor
{
    public interface IAuditScope : IDisposable
    {
        AuditContext Context { get; }
    }
}
