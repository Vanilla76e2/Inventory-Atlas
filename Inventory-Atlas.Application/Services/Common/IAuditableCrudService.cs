using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Application.Services.Common
{
    public interface IAuditableCrudService<TEntity, TDto> : ICrudService<TEntity, TDto>
    {
        Task LogChangesAsync(TDto? oldValue, TDto? newValue, ActionType action);
    }
}
