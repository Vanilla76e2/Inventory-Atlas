using System.Linq.Expressions;

namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями типа <typeparamref name="T"/> в базе данных.
    /// </summary>
    public interface IDatabaseRepository<T> where T : class
    {
        /// <summary>
        /// Асинхронно получает сущность по идентификатору.
        /// </summary>
        Task<T?> GetByIdAsync(int id, CancellationToken ct = default);

        /// <summary>
        /// Асинхронно получает все сущности типа <typeparamref name="T"/>.
        /// </summary>
        Task<List<T>> GetAllAsync(CancellationToken ct = default);

        /// <summary>
        /// Асинхронно ищет первую сущность, удовлетворяющую условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Сущность или null, если не найдена.</returns>
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);

        /// <summary>
        /// Асинхронно ищет все сущности, удовлетворяющие условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Список сущностей.</returns>
        Task<List<T>> FindManyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);

        /// <summary>
        /// Асинхронно добавляет сущность в базу данных.
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// Асинхронно обновляет сущность в базе данных.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        void Update(T entity);

        /// <summary>
        /// Асинхронно удаляет сущность из базы данных.
        /// </summary>
        /// <param name="entity">Обновляемая сущность.</param>
        void Delete(T entity);
    }
}
