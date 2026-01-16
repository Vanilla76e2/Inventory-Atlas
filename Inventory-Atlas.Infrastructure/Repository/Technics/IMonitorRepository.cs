using Inventory_Atlas.Infrastructure.Repository.Common;
using Entity = Inventory_Atlas.Infrastructure.Entities.Technics;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с мониторами
    /// </summary>
    public interface IMonitorRepository : IDatabaseRepository<Entities.Technics.Monitor>
    {
        /// <summary>
        /// Получает мониторы по разрешению экрана
        /// </summary>
        /// <param name="resolution">Разрешение экрана (например, "1920x1080")</param>
        /// <returns>Коллекция мониторов с указанным разрешением</returns>
        Task<IEnumerable<Entities.Technics.Monitor>> GetByResolutionAsync(string resolution, CancellationToken ct = default);

        /// <summary>
        /// Получает мониторы по типу матрицы
        /// </summary>
        /// <param name="panelType">Тип матрицы дисплея</param>
        /// <returns>Коллекция мониторов с указанным типом матрицы</returns>
        Task<IEnumerable<Entities.Technics.Monitor>> GetByPanelTypeAsync(DisplayType panelType, CancellationToken ct = default);

        /// <summary>
        /// Получает мониторы по диапазону частоты обновления
        /// </summary>
        /// <param name="min">Минимальная частота обновления (Гц)</param>
        /// <param name="max">Максимальная частота обновления (Гц)</param>
        /// <returns>Коллекция мониторов в указанном диапазоне частот</returns>
        Task<IEnumerable<Entities.Technics.Monitor>> GetByRefreshRateRangeAsync(int min, int max, CancellationToken ct = default);
    }
}