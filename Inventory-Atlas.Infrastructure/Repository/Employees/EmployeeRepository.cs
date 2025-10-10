using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Employees
{
    /// <summary>
    /// Репозиторий для работы с сотрудниками.
    /// </summary>
    public class EmployeeRepository : DatabaseRepository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория сотрудников с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public EmployeeRepository(IDatabaseContextProvider contextProvider, ILogger<EmployeeRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Employee>> SearchAsync(
            string? surname = null,
            string? firstname = null,
            string? patronymic = null,
            int? departmentId = null,
            string? position = null,
            bool? isResponsible = null)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            var query = context.Set<Employee>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(surname))
                query = query.Where(e => EF.Functions.ILike(e.Surname, $"%{surname}%"));

            if (!string.IsNullOrWhiteSpace(firstname))
                query = query.Where(e => EF.Functions.ILike(e.Firstname, $"%{firstname}%"));

            if (!string.IsNullOrWhiteSpace(patronymic))
                query = query.Where(e => e.Patronymic != null && EF.Functions.ILike(e.Patronymic, $"%{patronymic}%"));

            if (departmentId.HasValue)
                query = query.Where(e => e.DepartmentId == departmentId);

            if (!string.IsNullOrWhiteSpace(position))
                query = query.Where(e => e.Position != null && EF.Functions.ILike(e.Position, $"%{position}%"));

            if (isResponsible.HasValue)
                query = query.Where(e => e.IsResponsible == isResponsible);

            return await query.ToListAsync();
        }
    }
}
