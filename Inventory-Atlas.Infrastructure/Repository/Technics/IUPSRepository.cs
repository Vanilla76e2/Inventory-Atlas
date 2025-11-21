using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с ИБП (источниками бесперебойного питания)
    /// </summary>
    public interface IUPSRepository : IDatabaseRepository<UPS>
    {
        /// <summary>
        /// Получает ИБП по диапазону мощности
        /// </summary>
        /// <param name="minWatts">Минимальная мощность (Вт)</param>
        /// <param name="maxWatts">Максимальная мощность (Вт)</param>
        /// <returns>Коллекция ИБП в указанном диапазоне мощности</returns>
        Task<IEnumerable<UPS>> GetByCapacityAsync(int minWatts, int maxWatts, CancellationToken ct = default);

        /// <summary>
        /// Получает ИБП по диапазону автономной работы
        /// </summary>
        /// <param name="minMinutes">Минимальное время автономной работы (минуты)</param>
        /// <param name="maxMinutes">Максимальное время автономной работы (минуты)</param>
        /// <returns>Коллекция ИБП в указанном диапазоне автономной работы</returns>
        Task<IEnumerable<UPS>> GetByAutonomyAsync(int minMinutes, int maxMinutes, CancellationToken ct = default);
    }
}