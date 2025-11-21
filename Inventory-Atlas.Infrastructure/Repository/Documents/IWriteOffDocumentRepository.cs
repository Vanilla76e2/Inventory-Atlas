using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами списания оборудования.
    /// </summary>
    public interface IWriteOffDocumentRepository : IDatabaseRepository<WriteOffDocument>
    {
        /// <summary>
        /// Получить документ списания с вложенными элементами.
        /// </summary>
        /// <param name="documentId">Id документа.</param>
        /// <returns>Документ списания с элементами, либо <c>null</c> если не найден.</returns>
        Task<WriteOffDocument?> GetWithItemsAsync(int documentId, CancellationToken ct = default);
    }

    /// <summary>
    /// Репозиторий для работы с элементами документов списания.
    /// </summary>
    public interface IWriteOffDocumentItemRepository : IDatabaseRepository<WriteOffDocumentItem>
    {
        /// <summary>
        /// Получить все элементы документа списания по Id документа.
        /// </summary>
        /// <param name="documentId">Id документа.</param>
        /// <returns>Список элементов документа.</returns>
        Task<IEnumerable<WriteOffDocumentItem>> GetByDocumentIdAsync(int documentId, CancellationToken ct = default);
    }
}
