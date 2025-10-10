using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Inventory;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с мебелью.
    /// </summary>
    public class FurnitureRepository : DatabaseRepository<Furniture>, IFurnitureRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FurnitureRepository"/>.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для ведения логов.</param>
        public FurnitureRepository(IDatabaseContextProvider contextProvider, ILogger<FurnitureRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Furniture>> SearchAsync(
            int? typeId = null,
            FurnitureOrientation? orientation = null,
            double? minWeight = null,
            double? maxWeight = null,
            string? dimensionsContains = null)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            var query = context.Set<Furniture>().AsQueryable();

            if (typeId.HasValue)
                query = query.Where(e => e.FurnitureTypeId == typeId);

            if (orientation.HasValue)
                query = query.Where(e => e.Orientation == orientation.Value);

            if (minWeight.HasValue)
                query = query.Where(e => e.Weight >= minWeight.Value);

            if (maxWeight.HasValue)
                query = query.Where(e => e.Weight <= maxWeight.Value);

            if (!string.IsNullOrWhiteSpace(dimensionsContains))
                query = query.Where(e => e.Dimensions != null && EF.Functions.ILike(e.Dimensions!, $"%{dimensionsContains}%"));

            return await query.ToListAsync();
        }
    }

    /// <summary>
    /// Репозиторий для работы с присвоением материалов мебели.
    /// </summary>
    public class FurnitureMaterialAssignmentRepository
        : DatabaseRepository<FurnitureMaterialAssignment>, IFurnitureMaterialAssignmentRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="FurnitureMaterialAssignmentRepository"/>.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для ведения логов.</param>
        public FurnitureMaterialAssignmentRepository(IDatabaseContextProvider contextProvider, ILogger<FurnitureMaterialAssignmentRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FurnitureMaterialAssignment>> GetByFurnitureIdAsync(int furnitureId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<FurnitureMaterialAssignment>()
                .Where(a => a.FurnitureId == furnitureId)
                .Include(a => a.Furniture)
                .Include(a => a.FurnitureMaterial)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FurnitureMaterialAssignment>> GetByMaterialIdAsync(int materialId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<FurnitureMaterialAssignment>()
                .Where(a => a.MaterialId == materialId)
                .Include(a => a.Furniture)
                .Include(a => a.FurnitureMaterial)
                .ToListAsync();
        }
    }
}
