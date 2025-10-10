using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с планшетами
    /// </summary>
    public interface ITabletRepository : IDatabaseRepository<Tablet>
    {
        /// <summary>
        /// Получает планшеты по операционной системе
        /// </summary>
        /// <param name="operatingSystem">Операционная система для поиска</param>
        /// <returns>Коллекция планшетов с указанной операционной системой</returns>
        Task<IEnumerable<Tablet>> GetByOperatingSystemAsync(string operatingSystem);

        /// <summary>
        /// Получает планшеты по диагонали экрана
        /// </summary>
        /// <param name="diagonal">Диагональ экрана в дюймах</param>
        /// <returns>Коллекция планшетов с указанной диагональю экрана</returns>
        Task<IEnumerable<Tablet>> GetByDiagonalAsync(float diagonal);
    }
}