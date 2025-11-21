using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
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
        /// Инициализирует новый экземпляр репозитория принтеров.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public PrinterRepository(AppDbContext context, ILogger<PrinterRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Printer>> GetByIpAddressAsync(string ipAddress, CancellationToken ct = default)
        {
            return await _context.Set<Printer>()
                .Where(p => p.IpAddress != null && p.IpAddress.ToString() == ipAddress)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Printer>> GetByColorPrintingAsync(bool isColor, CancellationToken ct = default)
        {
            return await _context.Set<Printer>()
                .Where(p => p.Color == isColor)
                .ToListAsync(ct);
        }
    }
}