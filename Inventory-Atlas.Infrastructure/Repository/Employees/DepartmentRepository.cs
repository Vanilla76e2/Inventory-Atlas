using Inventory_Atlas.Application.Data;
using Inventory_Atlas.Application.Entities.Employees;
using Inventory_Atlas.Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Repository.Employees
{
    /// <summary>
    /// Репозиторий для работы с отделами.
    /// </summary>
    public class DepartmentRepository : DatabaseRepository<Department>, IDepartmentRepository
    {
        /// <summary>
        /// Создаёт экземпляр репозитория отделов с использованием поставщика контекста базы данных и логгера.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для репозитория.</param>
        public DepartmentRepository(AppDbContext context, ILogger<DepartmentRepository> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Department>> SearchByNameAsync(string name, CancellationToken ct = default)
        {
            return await _context.Set<Department>()
                .Where(d => EF.Functions.ILike(d.Name, $"%{name}%"))
                .ToListAsync(ct);
        }
    }
}
