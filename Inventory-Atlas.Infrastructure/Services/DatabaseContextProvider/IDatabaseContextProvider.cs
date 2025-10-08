using Inventory_Atlas.Infrastructure.Data;

namespace Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider
{
    public interface IDatabaseContextProvider
    {
        Task<AppDbContext> GetDbContextAsync();

        AppDbContext GetDbContext(string connectionString);
    }
}
