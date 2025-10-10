using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами выдачи оборудования.
    /// <para/>
    /// Наследует <see cref="DatabaseRepository{CheckoutDocument}"/> и реализует <see cref="ICheckoutDocumentRepository"/>.
    /// </summary>
    public class CheckoutDocumentRepository : DatabaseRepository<CheckoutDocument>, ICheckoutDocumentRepository
    {
        /// <inheritdoc/>
        public CheckoutDocumentRepository(IDatabaseContextProvider contextProvider, ILogger<CheckoutDocumentRepository> logger)
            : base(contextProvider, logger)
        { }

        /// <inheritdoc/>
        public async Task<CheckoutDocument?> GetWithItemsAsync(int documentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<CheckoutDocument>()
                .Include(d => d.Employee)
                .Include(d => d.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(d => d.Id == documentId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CheckoutDocument>> GetByEmployeeAsync(int employeeId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<CheckoutDocument>()
                .Include(d => d.Items)
                .Where(d => d.EmployeeId == employeeId)
                .ToListAsync();
        }
    }

    /// <summary>
    /// Репозиторий для работы с позициями документов выдачи оборудования.
    /// <para/>
    /// Наследует <see cref="DatabaseRepository{CheckoutDocumentItem}"/> и реализует <see cref="ICheckoutDocumentItemRepository"/>.
    /// </summary>
    public class CheckoutDocumentItemRepository : DatabaseRepository<CheckoutDocumentItem>, ICheckoutDocumentItemRepository
    {
        /// <inheritdoc/>
        public CheckoutDocumentItemRepository(IDatabaseContextProvider contextProvider, ILogger<CheckoutDocumentItemRepository> logger)
            : base(contextProvider, logger)
        { }

        /// <inheritdoc/>
        public async Task<IEnumerable<CheckoutDocumentItem>> GetByDocumentIdAsync(int documentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<CheckoutDocumentItem>()
                .Include(i => i.Item)
                .Where(i => i.DocumentId == documentId)
                .ToListAsync();
        }
    }
}
