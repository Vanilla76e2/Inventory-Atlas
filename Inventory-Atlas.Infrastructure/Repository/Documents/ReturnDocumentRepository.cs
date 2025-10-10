using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами возврата.
    /// </summary>
    public class ReturnDocumentRepository : DatabaseRepository<ReturnDocument>, IReturnDocumentRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория возвратных документов с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public ReturnDocumentRepository(IDatabaseContextProvider contextProvider, ILogger<ReturnDocumentRepository> logger)
            : base(contextProvider, logger)
        { }

        /// <inheritdoc/>
        public async Task<ReturnDocument?> GetWithItemsAsync(int documentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<ReturnDocument>()
                .Include(d => d.Employee)
                .Include(d => d.Items)
                    .ThenInclude(i => i.Item)
                .FirstOrDefaultAsync(d => d.Id == documentId);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReturnDocument>> GetByEmployeeAsync(int employeeId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<ReturnDocument>()
                .Include(d => d.Items)
                .Where(d => d.EmployeeId == employeeId)
                .ToListAsync();
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
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public ReturnDocumentItemRepository(IDatabaseContextProvider contextProvider, ILogger<ReturnDocumentItemRepository> logger)
            : base(contextProvider, logger)
        { }

        /// <inheritdoc/>
        public async Task<IEnumerable<ReturnDocumentItem>> GetByDocumentIdAsync(int documentId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<ReturnDocumentItem>()
                .Include(i => i.Item)
                .Where(i => i.DocumentId == documentId)
                .ToListAsync();
        }
    }
}
