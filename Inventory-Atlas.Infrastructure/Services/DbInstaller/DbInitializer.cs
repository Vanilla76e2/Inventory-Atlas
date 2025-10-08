
using Inventory_Atlas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Services.DbInstaller
{
    public static class DbInitializer
    {
        /// <summary>
        /// Развёртывает или обновляет базу данных с помощью миграций.
        /// Вызывается один раз при старте приложения.
        /// </summary>
        public static void InstallOrUpdateDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();

            try
            {
                logger.LogInformation("Начало применения миграций...");
                context.Database.Migrate();
                logger.LogInformation("База данных успешно развернута/обновлена.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ошибка при развертывании/обновлении базы данных.");
                throw; // можно обработать или завершить запуск приложения
            }
        }
    }
}
