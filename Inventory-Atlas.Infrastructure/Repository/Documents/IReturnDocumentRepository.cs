using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами возврата оборудования.
    /// </summary>
    public interface IReturnDocumentRepository : IDatabaseRepository<ReturnDocument>
    {
        /// <summary>
        /// Получает документ возврата с вложенными позициями по Id документа.
        /// </summary>
        /// <param name="documentId">Id документа.</param>
        /// <returns>Документ с его позициями или null, если не найден.</returns>
        Task<ReturnDocument?> GetWithItemsAsync(int documentId);

        /// <summary>
        /// Получает все документы возврата для указанного сотрудника.
        /// </summary>
        /// <param name="employeeId">Id сотрудника.</param>
        /// <returns>Список документов.</returns>
        Task<IEnumerable<ReturnDocument>> GetByEmployeeAsync(int employeeId);
    }

    /// <summary>
    /// Репозиторий для работы с позициями документов возврата оборудования.
    /// </summary>
    public interface IReturnDocumentItemRepository : IDatabaseRepository<ReturnDocumentItem>
    {
        /// <summary>
        /// Получает все позиции документа возврата по Id документа.
        /// </summary>
        /// <param name="documentId">Id документа.</param>
        /// <returns>Список позиций документа.</returns>
        Task<IEnumerable<ReturnDocumentItem>> GetByDocumentIdAsync(int documentId);
    }
}
