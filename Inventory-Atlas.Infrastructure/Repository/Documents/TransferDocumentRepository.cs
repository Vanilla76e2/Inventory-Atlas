using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public TransferDocumentRepository(IDatabaseContextProvider contextProvider, ILogger<TransferDocumentRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<TransferDocument?> GetWithItemsAsync(int documentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<TransferDocument>()
                .Include(d => d.FromEmployee)
                .Include(d => d.ToEmployee)
                .Include(d => d.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(d => d.Id == documentId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransferDocument>> GetByFromEmployeeAsync(int employeeId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<TransferDocument>()
                .Include(d => d.Items)
                .Where(d => d.FromEmployeeId == employeeId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransferDocument>> GetByToEmployeeAsync(int employeeId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<TransferDocument>()
                .Include(d => d.Items)
                .Where(d => d.ToEmployeeId == employeeId)
                .ToListAsync();
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
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public TransferDocumentItemRepository(IDatabaseContextProvider contextProvider, ILogger<TransferDocumentItemRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransferDocumentItem>> GetByDocumentIdAsync(int documentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<TransferDocumentItem>()
                .Include(i => i.Item)
                .Where(i => i.DocumentId == documentId)
                .ToListAsync();
        }
    }
}
