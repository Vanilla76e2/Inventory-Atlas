using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics
{
    /// <summary>
    /// Репозиторий для работы с телефонами
    /// </summary>
    public class PhoneRepository : DatabaseRepository<Phone>, IPhoneRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр репозитория телефонов
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных</param>
        /// <param name="logger">Логгер для записи событий</param>
        public PhoneRepository(IDatabaseContextProvider contextProvider, ILogger<PhoneRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Phone>> GetByPhoneNumberAsync(string phoneNumber)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Phone>()
                .Where(p => p.PhoneNumber != null && p.PhoneNumber.Contains(phoneNumber))
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Phone>> GetByModelAsync(string model)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<Phone>()
                .Where(p => p.Model != null && p.Model.ToLower().Contains(model.ToLower()))
                .ToListAsync();
        }
    }
}