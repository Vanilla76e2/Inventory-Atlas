
namespace Inventory_Atlas.Application.Repository.Common
{
    /// <summary>
    /// Представляет единицу работы для атомарного сохранения изменений в базе данных.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Асинхронно фиксирует все накопленные изменения в контексте данных.
        /// Вызывает сохранение всех изменений, сделанных через репозитории,
        /// входящие в текущий Unit of Work.
        /// </summary>
        /// <param name="ct">Токен отмены операции.</param>
        Task SaveChangesAsync(CancellationToken ct = default);

        /// <summary>
        /// Асинхронно начинает новую транзакцию базы данных.
        /// Все последующие изменения через репозитории будут находиться в рамках этой транзакции.
        /// </summary>
        /// <param name="ct">Токен отмены для асинхронной операции.</param>
        /// <returns>Задача, представляющая асинхронное начало транзакции.</returns>
        /// <exception cref="InvalidOperationException">Если транзакция уже была начата.</exception>
        Task BeginTransactionAsync(CancellationToken ct = default);

        /// <summary>
        /// Асинхронно фиксирует (commit) все изменения текущей транзакции в базе данных.
        /// </summary>
        /// <param name="ct">Токен отмены для асинхронной операции.</param>
        /// <returns>Задача, представляющая асинхронный коммит транзакции.</returns>
        /// <exception cref="InvalidOperationException">Если нет активной транзакции для коммита.</exception>
        Task CommitAsync(CancellationToken ct = default);

        /// <summary>
        /// Асинхронно откатывает (rollback) все изменения текущей транзакции.
        /// Используется при возникновении ошибок, чтобы база данных осталась в согласованном состоянии.
        /// </summary>
        /// <param name="ct">Токен отмены для асинхронной операции.</param>
        /// <returns>Задача, представляющая асинхронный откат транзакции.</returns>
        Task RollbackAsync(CancellationToken ct = default);
    }
}
