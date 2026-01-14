using Inventory_Atlas.Application.Entities.Сonsumables;
using Inventory_Atlas.Application.Repository.Common;

namespace Inventory_Atlas.Application.Repository.Consumables
{
    /// <summary>
    /// Репозиторий для работы с картриджами принтеров.
    /// <para/>
    /// Тип: <see cref="IPrinterCartridgeRepository"/>
    /// <para/>
    /// Наследуется от <see cref="IDatabaseRepository{PrinterCartridge}"/> для базовых операций CRUD.
    /// </summary>
    public interface IPrinterCartridgeRepository : IDatabaseRepository<PrinterCartridge>
    {
        /// <summary>
        /// Получить все картриджи с количеством ниже указанного порога.
        /// <para/>
        /// Тип возвращаемого значения: <see cref="IEnumerable{PrinterCartridge}"/>
        /// </summary>
        /// <param name="threshold">Порог минимального количества картриджей.</param>
        Task<IEnumerable<PrinterCartridge>> GetLowStockAsync(int threshold, CancellationToken ct = default);

        /// <summary>
        /// Получить картридж по модели.
        /// <para/>
        /// Тип возвращаемого значения: <see cref="PrinterCartridge"/>
        /// <para/>
        /// Может быть <c>null</c>, если картридж с указанной моделью не найден.
        /// </summary>
        /// <param name="model">Модель картриджа.</param>
        Task<PrinterCartridge?> GetByModelAsync(string model, CancellationToken ct = default);
    }
}
