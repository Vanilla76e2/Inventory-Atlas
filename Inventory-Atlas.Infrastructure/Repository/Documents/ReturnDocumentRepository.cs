using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Documents;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами возврата.
    /// </summary>
    public class ReturnDocumentRepository : DatabaseRepository<ReturnDocument>, IReturnDocumentRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория возвратных документов с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public ReturnDocumentRepository(AppDbContext context, ILogger<ReturnDocumentRepository> logger)
            : base(context, logger)
        { }

        /// <inheritdoc/>
        public async Task<ReturnDocument?> GetWithItemsAsync(int documentId, CancellationToken ct = default)
        {
            return await _context.Set<ReturnDocument>()
                .Include(d => d.Employee)
                .Include(d => d.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(d => d.Id == documentId, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReturnDocument>> GetByEmployeeAsync(int employeeId, CancellationToken ct = default)
        {
            return await _context.Set<ReturnDocument>()
                .Include(d => d.Items)
                .Where(d => d.EmployeeId == employeeId)
                .ToListAsync(ct);
        }
    }

    /// <summary>
    /// Репозиторий для работы с элементами документа возврата.
    /// </summary>
    public class ReturnDocumentItemRepository : DatabaseRepository<ReturnDocumentItem>, IReturnDocumentItemRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория элементов документа возврата с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public ReturnDocumentItemRepository(AppDbContext context, ILogger<ReturnDocumentItemRepository> logger)
            : base(context, logger)
        { }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReturnDocumentItem>> GetByDocumentIdAsync(int documentId, CancellationToken ct = default)
        {
            return await _context.Set<ReturnDocumentItem>()
                .Include(i => i.Item)
                .Where(i => i.DocumentId == documentId)
                .ToListAsync(ct);
        }
    }
}
