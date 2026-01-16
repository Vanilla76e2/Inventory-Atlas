using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами передачи оборудования между сотрудниками.
    /// </summary>
    public class TransferDocumentRepository : DatabaseRepository<TransferDocument>, ITransferDocumentRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория документов передачи с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public TransferDocumentRepository(AppDbContext context, ILogger<TransferDocumentRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<TransferDocument?> GetWithItemsAsync(int documentId, CancellationToken ct = default)
        {
            return await _context.Set<TransferDocument>()
                .Include(d => d.FromEmployee)
                .Include(d => d.ToEmployee)
                .Include(d => d.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(d => d.Id == documentId, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransferDocument>> GetByFromEmployeeAsync(int employeeId, CancellationToken ct = default)
        {
            return await _context.Set<TransferDocument>()
                .Include(d => d.Items)
                .Where(d => d.FromEmployeeId == employeeId)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransferDocument>> GetByToEmployeeAsync(int employeeId, CancellationToken ct = default)
        {
            return await _context.Set<TransferDocument>()
                .Include(d => d.Items)
                .Where(d => d.ToEmployeeId == employeeId)
                .ToListAsync(ct);
        }
    }

    /// <summary>
    /// Репозиторий для работы с элементами документа передачи оборудования.
    /// </summary>
    public class TransferDocumentItemRepository : DatabaseRepository<TransferDocumentItem>, ITransferDocumentItemRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория элементов документа передачи с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public TransferDocumentItemRepository(AppDbContext context, ILogger<TransferDocumentItemRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransferDocumentItem>> GetByDocumentIdAsync(int documentId, CancellationToken ct = default)
        {
            return await _context.Set<TransferDocumentItem>()
                .Include(i => i.Item)
                .Where(i => i.DocumentId == documentId)
                .ToListAsync(ct);
        }
    }
}
