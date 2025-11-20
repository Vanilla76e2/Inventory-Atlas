using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    /// <summary>
    /// Реализация Unit of Work для работы с репозиториями.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger<UnitOfWork> _logger;
        private readonly IDatabaseContextProvider _contextProvider;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="loggerFactory">Фабрика логгеров.</param>
        public UnitOfWork(IDatabaseContextProvider contextProvider, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<UnitOfWork>();
            _contextProvider = contextProvider;
        }

        public async Task SaveChangesAsync(CancellationToken ct = default)
        {
            var dbContext = await _contextProvider.GetDbContextAsync();
            _logger.LogInformation("Saving changes to the database...");
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving changes to the database.");
                throw;
            }
            _logger.LogInformation("Changes saved successfully.");
            _logger.LogDebug("Number of entities being saved: {Count}", dbContext.ChangeTracker.Entries().Count());
        }
    }
}
