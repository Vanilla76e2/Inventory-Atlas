using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с принтерами
    /// </summary>
    public interface IPrinterRepository : IDatabaseRepository<Printer>
    {
        /// <summary>
        /// Получает принтеры по IP-адресу
        /// </summary>
        /// <param name="ipAddress">IP-адрес для поиска</param>
        /// <returns>Коллекция принтеров с указанным IP-адресом</returns>
        Task<IEnumerable<Printer>> GetByIpAddressAsync(string ipAddress);

        /// <summary>
        /// Получает принтеры по типу печати
        /// </summary>
        /// <param name="isColor">Признак цветной печати (true - цветные, false - черно-белые)</param>
        /// <returns>Коллекция принтеров с указанным типом печати</returns>
        Task<IEnumerable<Printer>> GetByColorPrintingAsync(bool isColor);
    }
}