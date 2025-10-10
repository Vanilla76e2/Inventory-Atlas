using Inventory_Atlas.Infrastructure.Entities.Dictionaries;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public FurnitureMaterialRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<FurnitureMaterialRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FurnitureMaterial>> SearchAsync(string? name = null)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            var query = context.Set<FurnitureMaterial>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(fm => EF.Functions.ILike(fm.Name, $"%{name}%"));

            return await query
                .Include(fm => fm.FurnitureMaterialAssignments)
                .ThenInclude(a => a.Furniture)
                .ToListAsync();
        }
    }
}
