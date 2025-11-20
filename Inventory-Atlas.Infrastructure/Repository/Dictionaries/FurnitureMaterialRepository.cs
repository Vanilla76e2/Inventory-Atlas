using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с материалами мебели.
    /// <para/>
    /// Наследуется от <see cref="DatabaseRepository{FurnitureMaterial}"/> и реализует <see cref="IFurnitureMaterialRepository"/>.
    /// </summary>
    public class FurnitureMaterialRepository : DatabaseRepository<FurnitureMaterial>, IFurnitureMaterialRepository
    {
        /// <summary>
        /// Создаёт экземпляр <see cref="FurnitureMaterialRepository"/> с указанным провайдером контекста БД и логгером.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public FurnitureMaterialRepository(
            AppDbContext context,
            ILogger<FurnitureMaterialRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FurnitureMaterial>> SearchAsync(string? name = null, CancellationToken ct = default)
        {
            var query = _context.Set<FurnitureMaterial>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(fm => EF.Functions.ILike(fm.Name, $"%{name}%"));

            return await query
                .Include(fm => fm.FurnitureMaterialAssignments)
                .ThenInclude(a => a.Furniture)
                .ToListAsync(ct);
        }
    }
}
