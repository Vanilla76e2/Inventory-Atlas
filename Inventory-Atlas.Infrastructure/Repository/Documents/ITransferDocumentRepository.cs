using Inventory_Atlas.Infrastructure.Entities.Documents;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Documents
{
    /// <summary>
    /// Репозиторий для работы с документами передачи оборудования.
    /// </summary>
    public interface ITransferDocumentRepository : IDatabaseRepository<TransferDocument>
    {
        /// <summary>
        /// Получить документ передачи с вложенными элементами.
        /// </summary>
        /// <param name="documentId">Id документа.</param>
        /// <returns>Документ передачи с заполненными элементами, либо <c>null</c> если не найден.</returns>
        Task<TransferDocument?> GetWithItemsAsync(int documentId, CancellationToken ct = default);

        /// <summary>
        /// Получает документы передачи, отправленные указанным сотрудником.
        /// </summary>
        /// <param name="employeeId">Id сотрудника-отправителя.</param>
        /// <returns>Список документов передачи.</returns>
        Task<IEnumerable<TransferDocument>> GetByFromEmployeeAsync(int employeeId, CancellationToken ct = default);

        /// <summary>
        /// Получает документы передачи, полученные указанным сотрудником.
        /// </summary>
        /// <param name="employeeId">Id сотрудника-получателя.</param>
        /// <returns>Список документов передачи.</returns>
        Task<IEnumerable<TransferDocument>> GetByToEmployeeAsync(int employeeId, CancellationToken ct = default);
    }

    /// <summary>
    /// Репозиторий для работы с позициями документов передачи оборудования.
    /// </summary>
    public interface ITransferDocumentItemRepository : IDatabaseRepository<TransferDocumentItem>
    {
        /// <summary>
        /// Получает позиции документа передачи по Id документа.
        /// </summary>
        /// <param name="documentId">Id документа.</param>
        /// <returns>Список позиций документа.</returns>
        Task<IEnumerable<TransferDocumentItem>> GetByDocumentIdAsync(int documentId, CancellationToken ct = default);
    }
}
