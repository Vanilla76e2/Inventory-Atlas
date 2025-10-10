
using Inventory_Atlas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Services.DbInstaller
{
    /// <summary>
    /// Инициализатор базы данных
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// Развёртывает или обновляет базу данных с помощью миграций.
        /// Вызывается один раз при старте приложения.
        /// </summary>
        /// <param name="serviceProvider">Провайдер служб приложения</param>
        /// <exception cref="Exception">Исключение при ошибке применения миграций</exception>
        public static void InstallOrUpdateDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var provider = scope.ServiceProvider.GetRequiredService<IDatabaseContextProvider>();
            var context = provider.GetDbContextAsync().Result;
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();

            try
            {
                logger.LogInformation("Starting migration application...");
                context.Database.Migrate();
                logger.LogInformation("Database successfully deployed/updated.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error during database deployment/update.");
                throw; // можно обработать или завершить запуск приложения
            }
        }
    }
}
