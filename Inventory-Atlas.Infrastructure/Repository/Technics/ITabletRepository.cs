using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Technics
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
        Task<IEnumerable<Tablet>> GetByOperatingSystemAsync(string operatingSystem, CancellationToken ct = default);

        /// <summary>
        /// Получает планшеты по диагонали экрана
        /// </summary>
        /// <param name="diagonal">Диагональ экрана в дюймах</param>
        /// <returns>Коллекция планшетов с указанной диагональю экрана</returns>
        Task<IEnumerable<Tablet>> GetByDiagonalAsync(float diagonal, CancellationToken ct = default);
    }
}