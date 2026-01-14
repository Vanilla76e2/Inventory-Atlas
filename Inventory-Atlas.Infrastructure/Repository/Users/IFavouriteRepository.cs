using Inventory_Atlas.Application.Entities.Users;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Users
{
    /// <summary>
    /// Репозиторий для работы с избранными элементами пользователей
    /// </summary>
    public interface IFavouriteRepository : IDatabaseRepository<Favourite>
    {
        /// <summary>
        /// Получает избранные элементы пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Коллекция избранных элементов пользователя</returns>
        Task<IEnumerable<Favourite>> GetByUserIdAsync(int userId, CancellationToken ct = default);

        /// <summary>
        /// Получает избранный элемент по пользователю и элементу
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="itemId">Идентификатор элемента</param>
        /// <returns>Избранный элемент или null если не найден</returns>
        Task<Favourite?> GetByUserAndItemAsync(int userId, int itemId, CancellationToken ct = default);

        /// <summary>
        /// Проверяет, является ли элемент избранным для пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="itemId">Идентификатор элемента</param>
        /// <returns>True если элемент является избранным, иначе false</returns>
        Task<bool> IsFavouriteAsync(int userId, int itemId, CancellationToken ct = default);
    }
}