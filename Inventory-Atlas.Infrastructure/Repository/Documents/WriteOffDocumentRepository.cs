using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Documents;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами списания.
    /// </summary>
    public class WriteOffDocumentRepository : DatabaseRepository<WriteOffDocument>, IWriteOffDocumentRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория документов списания с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public WriteOffDocumentRepository(AppDbContext context, ILogger<WriteOffDocumentRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<WriteOffDocument?> GetWithItemsAsync(int documentId, CancellationToken ct = default)
        {
            return await _context.Set<WriteOffDocument>()
                .Include(d => d.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(d => d.Id == documentId, ct);
        }
    }

    /// <summary>
    /// Репозиторий для работы с элементами документов списания.
    /// </summary>
    public class WriteOffDocumentItemRepository : DatabaseRepository<WriteOffDocumentItem>, IWriteOffDocumentItemRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория элементов документов списания с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public WriteOffDocumentItemRepository(AppDbContext context, ILogger<WriteOffDocumentItemRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WriteOffDocumentItem>> GetByDocumentIdAsync(int documentId, CancellationToken ct = default)
        {
            return await _context.Set<WriteOffDocumentItem>()
                .Include(i => i.Item)
                .Where(i => i.DocumentId == documentId)
                .ToListAsync(ct);
        }
    }
}
