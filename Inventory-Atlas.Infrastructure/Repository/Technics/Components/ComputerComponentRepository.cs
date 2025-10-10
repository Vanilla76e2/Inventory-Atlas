using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
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
        /// <param name="contextProvider">Провайдер DbContext.</param>
        /// <param name="logger">Логгер репозитория.</param>
        public ComputerComponentRepository(
            IDatabaseContextProvider contextProvider,
            ILogger<ComputerComponentRepository<TComponent>> logger)
            : base(contextProvider, logger)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TComponent>> GetByComputerIdAsync(int computerId)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<TComponent>()
                .Where(c => c.ComputerId == computerId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TComponent>> GetByTypeAsync(ComponentType type)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<TComponent>()
                .Where(c => c.ComponentType == type)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<TComponent?> GetBySerialNumberAsync(string serialNumber)
        {
            await using var context = await _contextProvider.GetDbContextAsync();
            return await context.Set<TComponent>()
                .FirstOrDefaultAsync(c => c.SerialNumber == serialNumber);
        }
    }
}
