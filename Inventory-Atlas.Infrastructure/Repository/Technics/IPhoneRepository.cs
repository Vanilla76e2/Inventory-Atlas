using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с телефонами
    /// </summary>
    public interface IPhoneRepository : IDatabaseRepository<Phone>
    {
        /// <summary>
        /// Получает телефоны по номеру телефона
        /// </summary>
        /// <param name="phoneNumber">Номер телефона для поиска</param>
        /// <returns>Коллекция телефонов с указанным номером</returns>
        Task<IEnumerable<Phone>> GetByPhoneNumberAsync(string phoneNumber);

        /// <summary>
        /// Получает телефоны по модели
        /// </summary>
        /// <param name="model">Модель телефона для поиска</param>
        /// <returns>Коллекция телефонов указанной модели</returns>
        Task<IEnumerable<Phone>> GetByModelAsync(string model);
    }
}