using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Technics
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
        Task<IEnumerable<Phone>> GetByPhoneNumberAsync(string phoneNumber, CancellationToken ct = default);

        /// <summary>
        /// Получает телефоны по модели
        /// </summary>
        /// <param name="model">Модель телефона для поиска</param>
        /// <returns>Коллекция телефонов указанной модели</returns>
        Task<IEnumerable<Phone>> GetByModelAsync(string model, CancellationToken ct = default);
    }
}