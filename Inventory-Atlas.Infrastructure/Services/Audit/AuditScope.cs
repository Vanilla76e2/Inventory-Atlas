namespace Inventory_Atlas.Infrastructure.Auditor.Scope
{
    public class AuditScope : IAuditScope
    {
        private readonly Action _onDispose;

        public AuditContext Context { get; }
        
        public AuditScope(AuditContext context, Action onDispose)
        {
            Context = context;
            _onDispose = onDispose;
        }
        
        public void Dispose() 
        {
            _onDispose();
        }
    }
}
