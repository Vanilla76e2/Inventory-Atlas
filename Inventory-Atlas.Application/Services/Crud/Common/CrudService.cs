using AutoMapper;
using Inventory_Atlas.Core.Exceptions;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Inventory_Atlas.Application.Services.Crud.Common
{
    /// <summary>
    /// Базовый сервис для CRUD-операций над сущностями.
    /// Предоставляет стандартную логику получения, поиска, создания, обновления и удаления.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    public abstract class CrudService<TEntity, TDto> : ICrudService<TEntity, TDto>
        where TEntity : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected readonly IDatabaseRepository<TEntity> _repo;
        protected readonly ILogger _logger;

        /// <summary>
        /// Создаёт экземпляр базового CRUD-сервиса.
        /// </summary>
        /// <param name="repo">Репозиторий сущности.</param>
        /// <param name="mapper">Маппер для преобразования DTO ↔ Entity.</param>
        protected CrudService(IUnitOfWork uow, IMapper mapper, IDatabaseRepository<TEntity> repo, ILogger logger)
        {
            _uow = uow;
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает сущность по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность типа TDto.</returns>
        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Возвращает коллекцию сущностей типа TDto.
        /// </summary>
        public virtual async Task<List<TDto>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<List<TDto>>(entities);
        }

        /// <summary>
        /// Добавляет новую сущность в контекст базы данных.
        /// </summary>
        /// <param name="dto">DTO новой сущности.</param>
        /// <returns>Созданная сущность типа TDto</returns>
        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repo.AddAsync(entity);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Created entity {EntityType} with ID {EntityId}", typeof(TEntity).Name, GetEntityId(entity));
            return _mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Обновляет сущность в контексте базы данных.
        /// </summary>
        /// <param name="id">Идентификатор обновляемой сущности.</param>
        /// <param name="dto">Данные для обновления.</param>
        /// <returns>Обновлённая сущность.</returns>
        public virtual async Task<TDto> UpdateAsync(int id, TDto dto)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new NotFoundException(typeof(TEntity).Name, id); ;
            _mapper.Map(dto, entity);
            await _repo.UpdateAsync(entity);
            await _uow.SaveChangesAsync();
            _logger.LogInformation("Updated entity {EntityType} with ID {EntityId}", typeof(TEntity).Name, id);
            return _mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Удаляет сущность из контекста базы данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id)
                ?? throw new NotFoundException(typeof(TEntity).Name, id);
            await _repo.DeleteAsync(entity);
            _logger.LogInformation("Deleted entity {EntityType} with ID {EntityId}", typeof(TEntity).Name, id);
            await _uow.SaveChangesAsync();
        }

        /// <summary>
        /// Возвращает первую сущность, удовлетворяющую условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns>DTO сущности или null, если не найдено.</returns>
        public virtual async Task<TDto?> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _repo.FindAsync(predicate);
            _logger.LogDebug("FindAsync called on {EntityType} with predicate {Predicate}", typeof(TEntity).Name, predicate);
            return entity == null ? default : _mapper.Map<TDto>(entity);
        }

        /// <summary>
        /// Возвращает список сущностей, удовлетворяющих условию.
        /// </summary>
        /// <param name="predicate">Условие поиска.</param>
        public virtual async Task<List<TDto>> FindManyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var list = await _repo.FindManyAsync(predicate);
            _logger.LogDebug("FindManyAsync called on {EntityType} with predicate {Predicate}", typeof(TEntity).Name, predicate);
            return _mapper.Map<List<TDto>>(list);
        }

        /// <summary>
        /// Вспомогательный метод для получения идентификатора сущности.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string GetEntityId(TEntity entity)
        {
            var idProperty = typeof(TEntity).GetProperty("Id");
            return idProperty?.GetValue(entity)?.ToString() ?? "unknown";
        }
    }
}
