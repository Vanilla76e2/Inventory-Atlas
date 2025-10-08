using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Inventory_Atlas.Infrastructure.Data
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Строим конфигурацию
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // путь к проекту Infrastructure
                .AddJsonFile("appsettings.Development.json", optional: false)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("Postgres"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
