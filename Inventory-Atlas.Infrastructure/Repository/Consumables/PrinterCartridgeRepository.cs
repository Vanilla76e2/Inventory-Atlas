using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Сonsumables;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Consumables
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
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public PrinterCartridgeRepository(AppDbContext context, ILogger<PrinterCartridgeRepository> logger)
            : base(context, logger)
        { }

        /// <inheritdoc/>
        public async Task<PrinterCartridge?> GetByModelAsync(string model, CancellationToken ct = default)
        {
            return await FindAsync(e => e.Model == model, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PrinterCartridge>> GetLowStockAsync(int threshold, CancellationToken ct = default)
        {
            return await FindManyAsync(e => e.Quantity <= threshold, ct);
        }
    }
}
