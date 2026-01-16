using Inventory_Atlas.Infrastructure.Data;
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
        protected readonly AppDbContext _context;
        protected readonly ILogger<DatabaseRepository<T>> _logger;

        /// <summary>
        /// Конструктор репозитория.
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="logger">Логгер.</param>
        public DatabaseRepository(AppDbContext context, ILogger<DatabaseRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Асинхронно получает сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность или null, если не найдена.</returns>
        public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Set<T>().FindAsync(id, ct);
        }

        /// <summary>
        /// Асинхронно получает все сущности типа <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Список всех сущностей.</returns>
        public async Task<List<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Set<T>().ToListAsync(ct);
        }

        /// <summary>
        /// Асинхронно ищет первую сущность, удовлетворяющую условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Сущность или null, если не найдена.</returns>
        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate, ct);
        }

        /// <summary>
        /// Асинхронно ищет все сущности, удовлетворяющие условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>Список сущностей.</returns>
        public async Task<List<T>> FindManyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync(ct);
        }

        /// <summary>
        /// Добавляет сущность в контекст.
        /// </summary>
        /// <param name="entity">Добавляемая сущность.</param>
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Обновляет сущность в контексте.
        /// </summary>
        /// <param name="entity">Обновляемая сущность.</param>
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        /// <summary>
        /// Удаляет сущность из контекста.
        /// </summary>
        /// <param name="entity">Удаляемая сущность.</param>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
