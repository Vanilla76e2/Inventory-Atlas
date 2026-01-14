using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Employees;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Inventory
{
    /// <summary>
    /// Репозиторий для работы с рабочими местами сотрудников.
    /// </summary>
    public class WorkplaceRepository : DatabaseRepository<Workplace>, IWorkplaceRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="WorkplaceRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для ведения логов.</param>
        public WorkplaceRepository(AppDbContext context, ILogger<WorkplaceRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Workplace>> SearchAsync(
            int? employeeId = null,
            string? name = null,
            string? comment = null,
            CancellationToken ct = default)
        {
            var query = _context.Set<Workplace>().AsQueryable();

            if (employeeId.HasValue)
                query = query.Where(e => e.EmployeeId == employeeId);

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(e => EF.Functions.ILike(e.Name, $"%{name}%"));

            if (!string.IsNullOrWhiteSpace(comment))
                query = query.Where(e => e.Comment != null && EF.Functions.ILike(e.Comment, $"%{comment}%"));

            return await query.ToListAsync(ct);
        }
    }
}
