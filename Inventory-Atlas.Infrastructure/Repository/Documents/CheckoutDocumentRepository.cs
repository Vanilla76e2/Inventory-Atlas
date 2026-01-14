using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Documents;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами выдачи оборудования.
    /// <para/>
    /// Наследует <see cref="DatabaseRepository{CheckoutDocument}"/> и реализует <see cref="ICheckoutDocumentRepository"/>.
    /// </summary>
    public class CheckoutDocumentRepository : DatabaseRepository<CheckoutDocument>, ICheckoutDocumentRepository
    {
        /// <inheritdoc/>
        public CheckoutDocumentRepository(AppDbContext context, ILogger<CheckoutDocumentRepository> logger)
            : base(context, logger)
        { }

        /// <inheritdoc/>
        public async Task<CheckoutDocument?> GetWithItemsAsync(int documentId, CancellationToken ct = default)
        {
            return await _context.Set<CheckoutDocument>()
                .Include(d => d.Employee)
                .Include(d => d.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(d => d.Id == documentId, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CheckoutDocument>> GetByEmployeeAsync(int employeeId, CancellationToken ct = default)
        {
            return await _context.Set<CheckoutDocument>()
                .Include(d => d.Items)
                .Where(d => d.EmployeeId == employeeId)
                .ToListAsync(ct);
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
        public CheckoutDocumentItemRepository(AppDbContext context, ILogger<CheckoutDocumentItemRepository> logger)
            : base(context, logger)
        { }

        /// <inheritdoc/>
        public async Task<IEnumerable<CheckoutDocumentItem>> GetByDocumentIdAsync(int documentId, CancellationToken ct = default)
        {
            return await _context.Set<CheckoutDocumentItem>()
                .Include(i => i.Item)
                .Where(i => i.DocumentId == documentId)
                .ToListAsync(ct);
        }
    }
}
