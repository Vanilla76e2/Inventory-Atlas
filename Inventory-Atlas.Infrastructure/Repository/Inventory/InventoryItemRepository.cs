using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Inventory;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с элементами инвентаря.
    /// </summary>
    public class InventoryItemRepository : DatabaseRepository<InventoryItem>, IInventoryItemRepository
    {
        /// <summary>
        /// Создаёт новый экземпляр репозитория элементов инвентаря.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер репозитория.</param>
        public InventoryItemRepository(AppDbContext context, ILogger<InventoryItemRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<InventoryItem>> SearchAsync(
            string? name = null,
            string? inventoryNumber = null,
            string? registryNumber = null,
            int? responsibleId = null,
            InventoryStatus? status = null,
            string? location = null,
            CancellationToken ct = default)
        {
            var query = _context.Set<InventoryItem>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(i => EF.Functions.ILike(i.Name, $"%{name}%"));

            if (!string.IsNullOrWhiteSpace(inventoryNumber))
                query = query.Where(i => i.InventoryNumber == $"%{inventoryNumber}%");

            if (!string.IsNullOrWhiteSpace(registryNumber))
                query = query.Where(i => EF.Functions.ILike(i.RegistryNumber!, $"%{registryNumber}%"));

            if (responsibleId.HasValue)
                query = query.Where(i => i.ResponsibleId == responsibleId.Value);

            if (status.HasValue)
                query = query.Where(i => i.Status == status.Value);

            if (!string.IsNullOrWhiteSpace(location))
                query = query.Where(i => EF.Functions.ILike(i.Location!, $"%{location}%"));

            return await query
                .Include(i => i.Responsible)
                .ToListAsync(ct);
        }
    }
}
