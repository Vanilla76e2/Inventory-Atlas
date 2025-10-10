using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    /// <summary>
    /// Репозиторий для работы с сущностями типа <typeparamref name="T"/> в базе данных.
    /// </summary>
    public class DatabaseRepository<T> : IDatabaseRepository<T> where T : class
    {
        protected readonly IDatabaseContextProvider _contextProvider;
        protected readonly ILogger<DatabaseRepository<T>> _logger;

        /// <summary>
        /// Конструктор репозитория.
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="logger">Логгер.</param>
        public DatabaseRepository(IDatabaseContextProvider contextProvider, ILogger<DatabaseRepository<T>> logger)
        {
            _contextProvider = contextProvider;
            _logger = logger;
        }

        /// <summary>
        /// Асинхронно добавляет сущность в базу данных.
        /// </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        public async Task AddAsync(T entity)
        {
            try
            {
                await using var context = await _contextProvider.GetDbContextAsync();
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                _logger.LogDebug("Entity of type {EntityType} added successfully.", typeof(T).Name);
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Database update error adding entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error adding entity of type {EntityType}.", typeof(T).Name);
                throw;
            };
        }

        /// <summary>
        /// Асинхронно удаляет сущность из базы данных.
        /// </summary>
        /// <param name="entity">Удаляемая сущность.</param>
        public async Task DeleteAsync(T entity)
        {
            try
            {
                await using var context = await _contextProvider.GetDbContextAsync();
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
                _logger.LogInformation("Entity of type {EntityType} deleted successfully.", typeof(T).Name);
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Database update error deleting entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error deleting entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        /// <summary>
        /// Асинхронно ищет первую сущность, удовлетворяющую условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Сущность или null, если не найдена.</returns>
        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                await using var context = await _contextProvider.GetDbContextAsync();
                return await context.Set<T>().FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error finding entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        /// <summary>
        /// Асинхронно ищет все сущности, удовлетворяющие условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Список сущностей.</returns>
        public async Task<IEnumerable<T>> FindManyAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                await using var context = await _contextProvider.GetDbContextAsync();
                return await context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error finding multiple entities of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        /// <summary>
        /// Асинхронно получает все сущности типа <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                await using var context = await _contextProvider.GetDbContextAsync();
                return await context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error retrieving all entities of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }

        /// <summary>
        /// Асинхронно получает сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность или null, если не найдена.</returns>
        public async Task<T?> GetByIdAsync(params object[] id)
        {
            try
            {
                await using var context = await _contextProvider.GetDbContextAsync();
                return await context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error retrieving entity of type {EntityType} by id {Id}.", typeof(T).Name, id);
                throw;
            }
        }

        /// <summary>
        /// Асинхронно обновляет сущность в базе данных.
        /// </summary>
        /// <param name="entity">Обновляемая сущность.</param>
        public async Task UpdateAsync(T entity)
        {
            try
            {
                await using var context = await _contextProvider.GetDbContextAsync();
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();
                _logger.LogInformation("Entity of type {EntityType} updated successfully.", typeof(T).Name);
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Database update error updating entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error updating entity of type {EntityType}.", typeof(T).Name);
                throw;
            }
        }
    }
}
