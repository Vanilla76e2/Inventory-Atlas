using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с видеокартами (GPU).
    /// <para/>
    /// Наследуется от <see cref="DatabaseRepository{GpuDictionary}"/> и реализует <see cref="IGpuRepository"/>.
    /// </summary>
    public class GpuRepository : DatabaseRepository<GpuDictionary>, IGpuRepository
    {
        /// <summary>
        /// Создаёт экземпляр <see cref="GpuRepository"/> с указанным провайдером контекста БД и логгером.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public GpuRepository(AppDbContext context, ILogger<GpuRepository> logger)
            : base(context, logger)
        { }

        /// <inheritdoc/>
        public async Task<IEnumerable<GpuDictionary>> SearchAsync(
            string? vendor = null,
            string? model = null,
            int? memorySize = null,
            GpuMemoryType? memoryType = null,
            short? vga = null,
            short? hdmi = null,
            short? displayPort = null,
            short? dvi = null,
            CancellationToken ct = default)
        {
            var query = _context.Set<GpuDictionary>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(vendor))
                query = query.Where(e => EF.Functions.ILike(e.Vendor, $"%{vendor}%"));

            if (!string.IsNullOrWhiteSpace(model))
                query = query.Where(e => EF.Functions.ILike(e.Model, $"%{model}%"));

            if (memorySize.HasValue)
                query = query.Where(e => e.MemorySize == memorySize);

            if (memoryType.HasValue)
                query = query.Where(e => e.MemoryType == memoryType);

            if (vga.HasValue)
                query = query.Where(e => e.Vga == vga);

            if (hdmi.HasValue)
                query = query.Where(e => e.Hdmi == hdmi);

            if (displayPort.HasValue)
                query = query.Where(e => e.DisplayPort == displayPort);

            if (dvi.HasValue)
                query = query.Where(e => e.Dvi == dvi);

            return await query.ToListAsync(ct);
        }
    }
}
