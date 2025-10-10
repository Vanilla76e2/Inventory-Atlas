using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Employees
{
    /// <summary>
    /// Репозиторий для работы с материально ответственными лицами.
    /// </summary>
    public class MateriallyResponsibleRepository : DatabaseRepository<MateriallyResponsible>, IMateriallyResponsibleRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="MateriallyResponsibleRepository"/>.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для ведения логов.</param>
        public MateriallyResponsibleRepository(IDatabaseContextProvider contextProvider, ILogger<MateriallyResponsibleRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MateriallyResponsible>> SearchAsync(
            int? employeeId = null,
            string? displayName = null,
            string? comment = null)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            var query = context.Set<MateriallyResponsible>().AsQueryable();

            if (employeeId.HasValue)
                query = query.Where(e => e.EmployeeId == employeeId);

            if (!string.IsNullOrWhiteSpace(displayName))
                query = query.Where(e => EF.Functions.ILike(e.DisplayName, $"%{displayName}%"));

            if (!string.IsNullOrWhiteSpace(comment))
                query = query.Where(e => e.Comment != null && EF.Functions.ILike(e.Comment, $"%{comment}%"));

            return await query.ToListAsync();
        }
    }
}
