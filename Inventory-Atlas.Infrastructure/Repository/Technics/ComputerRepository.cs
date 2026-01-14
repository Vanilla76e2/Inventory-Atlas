using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с компьютерами
    /// </summary>
    public class ComputerRepository : DatabaseRepository<Computer>, IComputerRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория компьютеров.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public ComputerRepository(AppDbContext context, ILogger<ComputerRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<Computer?> GetWithComponentsAsync(int computerId, CancellationToken ct = default)
        {
            return await _context.Set<Computer>()
                .Include(c => c.ComputerComponents)
                .Include(c => c.WorkplaceEquipments)
                .FirstOrDefaultAsync(c => c.Id == computerId, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Computer>> GetServersAsync(CancellationToken ct = default)
        {
            return await _context.Set<Computer>()
                .Where(c => c.IsServer)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Computer>> GetByIpAsync(IPAddress ipAddress, CancellationToken ct = default)
        {
            return await _context.Set<Computer>()
                .Where(c => c.IpAddress != null && c.IpAddress.Equals(ipAddress))
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<Computer?> GetByComponentIdAsync(int componentId, CancellationToken ct = default)
        {
            return await _context.Set<Computer>()
                .Include(c => c.ComputerComponents)
                .FirstOrDefaultAsync(c => c.ComputerComponents.Any(comp => comp.Id == componentId), ct);
        }

        /// <inheritdoc/>
        public async Task<Computer?> GetByComponentAsync(int componentId, ComponentType type, CancellationToken ct = default)
        {
            return await _context.Set<Computer>()
                .Include(c => c.ComputerComponents)
                .FirstOrDefaultAsync(c => c.ComputerComponents
                    .Any(comp => comp.Id == componentId && comp.ComponentType == type), ct);
        }
    }
}
