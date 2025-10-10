using Microsoft.EntityFrameworkCore;
using Inventory_Atlas.Infrastructure.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider
{
    /// <summary>
    /// Провайдер для создания экземпляров контекста базы данных.
    /// </summary>
    public class DatabaseContextProvider : IDatabaseContextProvider
    {
        /// <summary>
        /// Строка подключения к базе данных.
        /// </summary>
        private IConfiguration _config;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public DatabaseContextProvider(IConfiguration config)
        {
            _config = config;
        }

        /// <inheritdoc/>
        public Task<AppDbContext> GetDbContextAsync()
        {
            var optiononsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optiononsBuilder.UseNpgsql(_config.GetConnectionString("Postgres"));
            var context = new AppDbContext(optiononsBuilder.Options);
            return Task.FromResult(context);
        }

        /// <inheritdoc/>
        public AppDbContext GetDbContext(string connectionString)
        {
            var optiononsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optiononsBuilder.UseNpgsql(connectionString);
            var context = new AppDbContext(optiononsBuilder.Options);
            return context;
        }
    }
}
