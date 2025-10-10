using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами списания.
    /// </summary>
    public class WriteOffDocumentRepository : DatabaseRepository<WriteOffDocument>, IWriteOffDocumentRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория документов списания с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public WriteOffDocumentRepository(IDatabaseContextProvider contextProvider, ILogger<WriteOffDocumentRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<WriteOffDocument?> GetWithItemsAsync(int documentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<WriteOffDocument>()
                .Include(d => d.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(d => d.Id == documentId);
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
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public WriteOffDocumentItemRepository(IDatabaseContextProvider contextProvider, ILogger<WriteOffDocumentItemRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<WriteOffDocumentItem>> GetByDocumentIdAsync(int documentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<WriteOffDocumentItem>()
                .Include(i => i.Item)
                .Where(i => i.DocumentId == documentId)
                .ToListAsync();
        }
    }
}
