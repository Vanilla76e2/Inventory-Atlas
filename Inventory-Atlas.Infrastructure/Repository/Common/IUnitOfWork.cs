
namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
