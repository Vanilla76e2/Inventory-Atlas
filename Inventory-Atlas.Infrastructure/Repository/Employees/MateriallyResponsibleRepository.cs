using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Employees;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Employees
{
    /// <summary>
    /// Репозиторий для работы с материально ответственными лицами.
    /// </summary>
    public class MateriallyResponsibleRepository : DatabaseRepository<MateriallyResponsible>, IMateriallyResponsibleRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MateriallyResponsibleRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для ведения логов.</param>
        public MateriallyResponsibleRepository(AppDbContext context, ILogger<MateriallyResponsibleRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MateriallyResponsible>> SearchAsync(
            int? employeeId = null,
            string? displayName = null,
            string? comment = null,
            CancellationToken ct = default)
        {
            var query = _context.Set<MateriallyResponsible>().AsQueryable();

            if (employeeId.HasValue)
                query = query.Where(e => e.EmployeeId == employeeId);

            if (!string.IsNullOrWhiteSpace(displayName))
                query = query.Where(e => EF.Functions.ILike(e.DisplayName, $"%{displayName}%"));

            if (!string.IsNullOrWhiteSpace(comment))
                query = query.Where(e => e.Comment != null && EF.Functions.ILike(e.Comment, $"%{comment}%"));

            return await query.ToListAsync(ct);
        }
    }
}
