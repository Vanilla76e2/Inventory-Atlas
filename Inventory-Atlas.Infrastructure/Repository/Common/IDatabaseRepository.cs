using System.Linq.Expressions;

namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    /// <summary>
    /// Интерфейс репозитория для работы с сущностями типа <typeparamref name="T"/> в базе данных.
    /// </summary>
    public interface IDatabaseRepository<T> where T : class
    {
        /// <summary>
        /// Асинхронно добавляет сущность в базу данных.
        /// </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        Task<T?> GetByIdAsync(params object[] id);

        /// <summary>
        /// Асинхронно удаляет сущность из базы данных.
        /// </summary>
        /// <param name="entity">Удаляемая сущность.</param>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Асинхронно ищет первую сущность, удовлетворяющую условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Сущность или null, если не найдена.</returns>
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Асинхронно ищет все сущности, удовлетворяющие условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Список сущностей.</returns>
        Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Асинхронно получает все сущности типа <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Асинхронно получает сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность или null, если не найдена.</returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Асинхронно обновляет сущность в базе данных.
        /// </summary>
        /// <param name="entity">Обновляемая сущность.</param>
        Task DeleteAsync(T entity);
    }
}
