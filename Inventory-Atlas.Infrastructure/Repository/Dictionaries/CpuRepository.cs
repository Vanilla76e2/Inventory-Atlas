using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с процессорами (CPU).
    /// <para/>
    /// Наследуется от <see cref="DatabaseRepository{CpuDictionary}"/> и реализует <see cref="ICpuRepository"/>.
    /// </summary>
    public class CpuRepository : DatabaseRepository<CpuDictionary>, ICpuRepository
    {
        /// <summary>
        /// Создаёт экземпляр <see cref="CpuRepository"/> с указанным провайдером контекста БД и логгером.
        /// </summary>
        /// <param name="provider">Провайдер контекста базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public CpuRepository(AppDbContext context, ILogger<CpuRepository> logger)
            : base(context, logger)
        { }

        /// <inheritdoc/>
        public async Task<IEnumerable<CpuDictionary>> SearchAsync(
            string? name = null,
            string? vendor = null,
            int? cores = null,
            int? threads = null,
            double? clock = null,
            double tolerance = 0.01,
            string? socket = null,
            CancellationToken ct = default)
        {

            var query = _context.Set<CpuDictionary>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(e => EF.Functions.ILike(e.Model, $"%{name}%"));

            if (!string.IsNullOrWhiteSpace(vendor))
                query = query.Where(e => EF.Functions.ILike(e.Vendor, $"%{vendor}%"));

            if (cores.HasValue)
                query = query.Where(e => e.CoreCount == cores);

            if (threads.HasValue)
                query = query.Where(e => e.ThreadCount == threads);

            if (clock.HasValue)
            {
                query = query.Where(e => e.Clock >= clock.Value - tolerance && e.Clock <= clock.Value + tolerance);
            }

            if (!string.IsNullOrWhiteSpace(socket))
                query = query.Where(e => e.Socket != null && EF.Functions.ILike(e.Socket, $"%{socket}%"));

            return await query.ToListAsync(ct);
        }
    }
}
