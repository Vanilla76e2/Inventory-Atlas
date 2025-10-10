using Inventory_Atlas.Infrastructure.Entities.Services;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public FurnitureTypeRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<FurnitureTypeRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FurnitureType>> SearchAsync(string? name = null)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            var query = context.Set<FurnitureType>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(ft => EF.Functions.ILike(ft.Name, $"%{name}%"));

            return await query
                .Include(ft => ft.Furnitures)
                .ToListAsync();
        }
    }
}
