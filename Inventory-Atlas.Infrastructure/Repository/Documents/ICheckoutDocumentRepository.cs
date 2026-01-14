using Inventory_Atlas.Application.Entities.Documents;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами выдачи оборудования.
    /// </summary>
    public interface ICheckoutDocumentRepository : IDatabaseRepository<CheckoutDocument>
    {
        /// <summary>
        /// Получает документ выдачи оборудования с вложенными позициями по Id документа.
        /// </summary>
        /// <param name="documentId">Id документа.</param>
        /// <returns>Документ с его позициями или null, если не найден.</returns>
        Task<CheckoutDocument?> GetWithItemsAsync(int documentId, CancellationToken ct = default);

        /// <summary>
        /// Получает все документы выдачи оборудования для указанного сотрудника.
        /// </summary>
        /// <param name="employeeId">Id сотрудника.</param>
        /// <returns>Список документов.</returns>
        Task<IEnumerable<CheckoutDocument>> GetByEmployeeAsync(int employeeId, CancellationToken ct = default);
    }

    /// <summary>
    /// Репозиторий для работы с позициями документов выдачи оборудования.
    /// </summary>
    public interface ICheckoutDocumentItemRepository : IDatabaseRepository<CheckoutDocumentItem>
    {
        /// <summary>
        /// Получает все позиции документа по Id документа.
        /// </summary>
        /// <param name="documentId">Id документа.</param>
        /// <returns>Список позиций документа.</returns>
        Task<IEnumerable<CheckoutDocumentItem>> GetByDocumentIdAsync(int documentId, CancellationToken ct = default);
    }
}
