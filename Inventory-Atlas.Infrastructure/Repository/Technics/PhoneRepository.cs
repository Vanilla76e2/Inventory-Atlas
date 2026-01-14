using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Technics;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с телефонами
    /// </summary>
    public class PhoneRepository : DatabaseRepository<Phone>, IPhoneRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория телефонов.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для записи событий.</param>
        public PhoneRepository(AppDbContext context, ILogger<PhoneRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Phone>> GetByPhoneNumberAsync(string phoneNumber, CancellationToken ct = default)
        {
            return await _context.Set<Phone>()
                .Where(p => p.PhoneNumber != null && p.PhoneNumber.Contains(phoneNumber))
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Phone>> GetByModelAsync(string model, CancellationToken ct = default)
        {
            return await _context.Set<Phone>()
                .Where(p => p.Model != null && p.Model.ToLower().Contains(model.ToLower()))
                .ToListAsync(ct);
        }
    }
}