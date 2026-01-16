using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с типами мебели.
    /// <para/>
    /// Наследуется от <see cref="DatabaseRepository{FurnitureType}"/> и реализует <see cref="IFurnitureTypeRepository"/>.
    /// </summary>
    public class FurnitureTypeRepository : DatabaseRepository<FurnitureType>, IFurnitureTypeRepository
    {
        /// <summary>
        /// Создаёт экземпляр <see cref="FurnitureTypeRepository"/> с указанным провайдером контекста БД и логгером.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public FurnitureTypeRepository(
            AppDbContext context,
            ILogger<FurnitureTypeRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FurnitureType>> SearchAsync(string? name = null, CancellationToken ct = default)
        {
            var query = _context.Set<FurnitureType>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(ft => EF.Functions.ILike(ft.Name, $"%{name}%"));

            return await query
                .Include(ft => ft.Furnitures)
                .ToListAsync(ct);
        }
    }
}
