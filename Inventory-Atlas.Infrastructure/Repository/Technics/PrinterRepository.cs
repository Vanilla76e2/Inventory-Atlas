using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с принтерами
    /// </summary>
    public class PrinterRepository : DatabaseRepository<Printer>, IPrinterRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория принтеров
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public PrinterRepository(IDatabaseContextProvider contextProvider, ILogger<PrinterRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Printer>> GetByIpAddressAsync(string ipAddress)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Printer>()
                .Where(p => p.IpAddress != null && p.IpAddress.ToString() == ipAddress)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Printer>> GetByColorPrintingAsync(bool isColor)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Printer>()
                .Where(p => p.Color == isColor)
                .ToListAsync();
        }
    }
}