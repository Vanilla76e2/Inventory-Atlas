using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.References;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Dictionaries
{
    /// <summary>
    /// Репозиторий для работы с материнскими платами.
    /// <para/>
    /// Наследует <see cref="DatabaseRepository{MoBoDictionary}"/> и реализует <see cref="IMoBoRepository"/>.
    /// </summary>
    public class MoBoRepository : DatabaseRepository<MoBoDictionary>, IMoBoRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MoBoRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public MoBoRepository(AppDbContext context, ILogger<MoBoRepository> logger)
            : base(context, logger)
        { }

        /// <inheritdoc/>
        /// <param name="vendor">Производитель материнской платы (необязательный, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="model">Модель материнской платы (необязательный, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="socket">Тип сокета (необязательный, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="chipset">Чипсет (необязательный, поиск по подстроке, нечувствительно к регистру).</param>
        /// <param name="formFactor">Форм-фактор (необязательный, точное совпадение).</param>
        /// <param name="ramSlots">Количество слотов для RAM (необязательный, точное совпадение).</param>
        /// <param name="m2Slots">Количество M.2 слотов (необязательный, точное совпадение).</param>
        /// <returns>Список материнских плат, удовлетворяющих указанным фильтрам.</returns>
        public async Task<IEnumerable<MoBoDictionary>> SearchAsync(
            string? vendor = null,
            string? model = null,
            string? socket = null,
            string? chipset = null,
            MoBoFormFactor? formFactor = null,
            short? ramSlots = null,
            short? m2Slots = null,
            CancellationToken ct = default)
        {
            var query = _context.Set<MoBoDictionary>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(vendor))
                query = query.Where(e => e.Vendor != null && EF.Functions.ILike(e.Vendor, $"%{vendor}%"));

            if (!string.IsNullOrWhiteSpace(model))
                query = query.Where(e => e.Model != null && EF.Functions.ILike(e.Model, $"%{model}%"));

            if (!string.IsNullOrWhiteSpace(socket))
                query = query.Where(e => e.Socket != null && EF.Functions.ILike(e.Socket, $"%{socket}%"));

            if (!string.IsNullOrWhiteSpace(chipset))
                query = query.Where(e => e.Chipset != null && EF.Functions.ILike(e.Chipset, $"%{chipset}%"));

            if (formFactor.HasValue)
                query = query.Where(e => e.FormFactor == formFactor);

            if (ramSlots.HasValue)
                query = query.Where(e => e.RamSlots == ramSlots);

            if (m2Slots.HasValue)
                query = query.Where(e => e.M2Slots == m2Slots);

            return await query.ToListAsync(ct);
        }
    }
}
