using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Inventory_Atlas.Infrastructure.Data;

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
        public async static Task InstallOrUpdateDatabase(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("DbInitializer");

            try
            {
                logger.LogInformation("Applying database migrations...");
                context.Database.Migrate();
                logger.LogInformation("Database is up to date.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Database migration failed.");
                throw;
            }

            await Seed(context, logger);
        }

        /// <summary>
        /// Асинхронно выполняет начальный сидинг базы данных.
        /// Создает системные роли и администратора.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <param name="logger">Логгер для вывода информации о процессе сидинга.</param>
        private async static Task Seed(AppDbContext context, ILogger logger)
        {
            logger.LogInformation("Running initial database seed...");

            // Роли
            if (!context.Roles.Any())
            {
                logger.LogInformation("Seeding roles...");

                var adminPerm = new RolePermission
                {
                    IsAdmin = true,
                };

                var adminRole = new Role
                {
                    Name = "Admin",
                    PermissionJson = JsonSerializer.Serialize(adminPerm),
                    IsSystem = true
                };

                var userRole = new Role
                {
                    Name = "None",
                    PermissionJson = JsonSerializer.Serialize(new RolePermission()),
                    IsSystem = true
                };

                context.Roles.AddRange(adminRole, userRole);
                await context.SaveChangesAsync();
                
                logger.LogInformation("Roles created.");
            }

            // Пользователь Admin
            if (!context.UserProfiles.Any())
            {
                logger.LogInformation("Seeding admin user");

                var adminRole = context.Roles.First(r => r.Name == "Admin");

                var adminUser = new UserProfile
                {
                    Username = "admin",
                    PasswordHash = HashPassword("admin"),
                    IsActive = true,
                    RoleId = adminRole.Id,
                    EmployeeId = null
                };

                context.UserProfiles.Add(adminUser);
                
                try
                {
                    await context.SaveChangesAsync();
                    logger.LogInformation("Admin user created (username: admin / password: admin).");
                }
                catch (Exception ex)
                {
                    logger.LogCritical(ex, "Database seeding failed.");
                    throw;
                }
            }

            logger.LogInformation("Database seed complete.");
        }

        /// <summary>
        /// Хеширует пароль с использованием BCrypt.
        /// </summary>
        /// <param name="plain">Пароль в открытом виде.</param>
        /// <returns>Хешированный пароль.</returns>
        private static string HashPassword(string plain)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(plain);
        }
    }
}
