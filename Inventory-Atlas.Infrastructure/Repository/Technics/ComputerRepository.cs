using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с компьютерами
    /// </summary>
    public class ComputerRepository : DatabaseRepository<Computer>, IComputerRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория компьютеров
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public ComputerRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<ComputerRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Computer?> GetWithComponentsAsync(int computerId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Computer>()
                .Include(c => c.ComputerComponents)
                .Include(c => c.WorkplaceEquipments)
                .FirstOrDefaultAsync(c => c.Id == computerId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Computer>> GetServersAsync()
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Computer>()
                .Where(c => c.IsServer)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Computer>> GetByIpAsync(IPAddress ipAddress)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Computer>()
                .Where(c => c.IpAddress != null && c.IpAddress.Equals(ipAddress))
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Computer?> GetByComponentIdAsync(int componentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<Computer>()
                .Include(c => c.ComputerComponents)
                .FirstOrDefaultAsync(c => c.ComputerComponents.Any(comp => comp.Id == componentId));
        }

        /// <inheritdoc/>
        public async Task<Computer?> GetByComponentAsync(int componentId, ComponentType type)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<Computer>()
                .Include(c => c.ComputerComponents)
                .FirstOrDefaultAsync(c => c.ComputerComponents
                    .Any(comp => comp.Id == componentId && comp.ComponentType == type));
        }
    }
}
