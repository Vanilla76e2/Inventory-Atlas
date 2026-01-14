using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с ноутбуками
    /// </summary>
    public class LaptopRepository : DatabaseRepository<Laptop>, ILaptopRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория ноутбуков.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public LaptopRepository(AppDbContext context, ILogger<LaptopRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Laptop?> GetByIpAddressAsync(string ipAddress, CancellationToken ct = default)
        {
            return await _context.Set<Laptop>()
                .FirstOrDefaultAsync(l => l.IpAddress != null && l.IpAddress.ToString() == ipAddress, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Laptop>> GetByProcessorAsync(string processor, CancellationToken ct = default)
        {
            return await _context.Set<Laptop>()
                .Where(l => l.Processor != null && l.Processor.Contains(processor))
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Laptop>> GetByRAMAsync(int ram, CancellationToken ct = default)
        {
            return await _context.Set<Laptop>()
                .Where(l => l.RAM == ram)
                .ToListAsync(ct);
        }
    }
}