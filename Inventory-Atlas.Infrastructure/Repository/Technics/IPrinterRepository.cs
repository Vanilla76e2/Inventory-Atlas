using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с принтерами
    /// </summary>
    public interface IPrinterRepository : IDatabaseRepository<Printer>
    {
        /// <summary>
        /// Получает принтеры по IpAddress-адресу
        /// </summary>
        /// <param name="ipAddress">IpAddress-адрес для поиска</param>
        /// <returns>Коллекция принтеров с указанным IpAddress-адресом</returns>
        Task<IEnumerable<Printer>> GetByIpAddressAsync(string ipAddress, CancellationToken ct = default);

        /// <summary>
        /// Получает принтеры по типу печати
        /// </summary>
        /// <param name="isColor">Признак цветной печати (true - цветные, false - черно-белые)</param>
        /// <returns>Коллекция принтеров с указанным типом печати</returns>
        Task<IEnumerable<Printer>> GetByColorPrintingAsync(bool isColor, CancellationToken ct = default);
    }
}