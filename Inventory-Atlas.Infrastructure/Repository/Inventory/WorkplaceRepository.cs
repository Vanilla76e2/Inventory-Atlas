using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с рабочими местами сотрудников.
    /// </summary>
    public class WorkplaceRepository : DatabaseRepository<Workplace>, IWorkplaceRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="WorkplaceRepository"/>.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для ведения логов.</param>
        public WorkplaceRepository(IDatabaseContextProvider contextProvider, ILogger<WorkplaceRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Workplace>> SearchAsync(
            int? employeeId = null,
            string? name = null,
            string? comment = null)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            var query = context.Set<Workplace>().AsQueryable();

            if (employeeId.HasValue)
                query = query.Where(e => e.EmployeeId == employeeId);

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(e => EF.Functions.ILike(e.Name, $"%{name}%"));

            if (!string.IsNullOrWhiteSpace(comment))
                query = query.Where(e => e.Comment != null && EF.Functions.ILike(e.Comment, $"%{comment}%"));

            return await query.ToListAsync();
        }
    }
}
