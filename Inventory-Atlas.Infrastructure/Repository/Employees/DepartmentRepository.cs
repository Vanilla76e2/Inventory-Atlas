using Inventory_Atlas.Infrastructure.Entities.Employees;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Employees
{
    /// <summary>
    /// Репозиторий для работы с отделами.
    /// </summary>
    public class DepartmentRepository : DatabaseRepository<Department>, IDepartmentRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория отделов с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="contextProvider">Поставщик контекста базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public DepartmentRepository(IDatabaseContextProvider contextProvider, ILogger<DepartmentRepository> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Department>> SearchByNameAsync(string name)
        {
            await using var context = await _contextProvider.GetDbContextAsync();

            return await context.Set<Department>()
                .Where(d => EF.Functions.ILike(d.Name, $"%{name}%"))
                .ToListAsync();
        }
    }
}
