using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Technics.Components
{
    /// <summary>
    /// Универсальный репозиторий для компонентов компьютеров.
    /// Поддерживает получение компонентов по компьютеру, типу и серийному номеру.
    /// </summary>
    /// <typeparam name="TComponent">Тип компонента, наследуемый от <see cref="ComputerComponent"/>.</typeparam>
    public class ComputerComponentRepository<TComponent>
        : DatabaseRepository<TComponent>, IComputerComponentRepository<TComponent>
        where TComponent : ComputerComponent
    {
        /// <summary>
        /// Создаёт экземпляр репозитория компонентов компьютера.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер репозитория.</param>
        public ComputerComponentRepository(AppDbContext context, ILogger<ComputerComponentRepository<TComponent>> logger)
            : base(context, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TComponent>> GetByComputerIdAsync(int computerId, CancellationToken ct = default)
        {
            return await _context.Set<TComponent>()
                .Where(c => c.ComputerId == computerId)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TComponent>> GetByTypeAsync(ComponentType type, CancellationToken ct = default)
        {
            return await _context.Set<TComponent>()
                .Where(c => c.ComponentType == type)
                .ToListAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<TComponent?> GetBySerialNumberAsync(string serialNumber, CancellationToken ct = default)
        {
            return await _context.Set<TComponent>()
                .FirstOrDefaultAsync(c => c.SerialNumber == serialNumber, ct);
        }
    }
}
