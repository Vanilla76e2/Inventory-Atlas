using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с ноутбуками
    /// </summary>
    public class LaptopRepository : DatabaseRepository<Laptop>, ILaptopRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория ноутбуков
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public LaptopRepository(IDatabaseContextProvider contextProvider, ILogger<LaptopRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Laptop?> GetByIpAddressAsync(string ipAddress)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Laptop>()
                .FirstOrDefaultAsync(l => l.IpAddress != null && l.IpAddress.ToString() == ipAddress);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Laptop>> GetByProcessorAsync(string processor)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Laptop>()
                .Where(l => l.Processor != null && l.Processor.Contains(processor))
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Laptop>> GetByRAMAsync(int ram)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Laptop>()
                .Where(l => l.RAM == ram)
                .ToListAsync();
        }
    }
}