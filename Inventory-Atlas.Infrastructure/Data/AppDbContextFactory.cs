using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Inventory_Atlas.Infrastructure.Data
{
    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            string currentDir = Directory.GetCurrentDirectory();
            string basePath = currentDir;

            // Если текущий проект Infrastructure, идём на уровень выше (корень решения)
            if (Path.GetFileName(currentDir)
                .Equals("Inventory-Atlas.Infrastructure", StringComparison.OrdinalIgnoreCase))
            {
                basePath = Path.GetFullPath(Path.Combine(currentDir, "..", "Inventory-Atlas"));
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true) // optional: true
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(config.GetConnectionString("Postgres"),
                o => o.MigrationsHistoryTable("__EFMigrationsHistory", "public"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
