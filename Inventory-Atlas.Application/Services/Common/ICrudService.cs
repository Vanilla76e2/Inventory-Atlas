using System.Linq.Expressions;

namespace Inventory_Atlas.Application.Services.Common
{
    /// <summary>
    /// Базовый интерфейс CRUD-сервиса для работы с DTO.
    /// </summary>
    /// <typeparam name="TDto">Тип DTO, используемый сервисом.</typeparam>
    public interface ICrudService<TEntity, TDto>
    {
        /// <summary>
        /// Получает DTO по идентификатору.
        /// </summary>
        Task<TDto> GetByIdAsync(int id);

        /// <summary>
        /// Получает все DTO.
        /// </summary>
        Task<List<TDto>> GetAllAsync();

        /// <summary>
        /// Создаёт новую сущность.
        /// </summary>
        Task<TDto> CreateAsync(TDto dto);

        /// <summary>
        /// Обновляет существующую сущность.
        /// </summary>
        Task<TDto> UpdateAsync(int id, TDto dto);

        /// <summary>
        /// Удаляет сущность по идентификатору.
        /// </summary>
        Task DeleteAsync(int id);

        /// <summary>
        /// Ищет первую сущность, удовлетворяющую условию.
        /// </summary>
        Task<TDto?> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Ищет список сущностей по условию.
        /// </summary>
        Task<List<TDto>> FindManyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
