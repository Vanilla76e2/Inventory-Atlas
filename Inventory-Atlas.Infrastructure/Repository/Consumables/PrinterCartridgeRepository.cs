using Inventory_Atlas.Infrastructure.Entities.Сonsumables;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Consumables
{
    /// <summary>
    /// Репозиторий для работы с картриджами принтеров.
    /// <para/>
    /// Наследуется от <see cref="DatabaseRepository{PrinterCartridge}"/> и реализует <see cref="IPrinterCartridgeRepository"/>.
    /// </summary>
    public class PrinterCartridgeRepository : DatabaseRepository<PrinterCartridge>, IPrinterCartridgeRepository
    {
        /// <summary>
        /// Создаёт экземпляр <see cref="PrinterCartridgeRepository"/> с указанным провайдером контекста БД и логгером.
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public PrinterCartridgeRepository(IDatabaseContextProvider contextProvider, ILogger<PrinterCartridgeRepository> logger)
            : base(contextProvider, logger)
        { }

        /// <inheritdoc/>
        public async Task<PrinterCartridge?> GetByModelAsync(string model)
        {
            return await FindAsync(e => e.Model == model);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PrinterCartridge>> GetLowStockAsync(int threshold)
        {
            return await FindManyAsync(e => e.Quantity <= threshold);
        }
    }
}
