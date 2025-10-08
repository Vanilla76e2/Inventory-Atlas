using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    /// <summary>
    /// Реализация Unit of Work для работы с репозиториями.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="loggerFactory">Фабрика логгеров.</param>
        public UnitOfWork(IDatabaseContextProvider contextProvider, ILoggerFactory loggerFactory)
        {
            // Репозиторий профилей пользователей
            UsersProfiles = new DatabaseRepository<UserProfile>(contextProvider, loggerFactory.CreateLogger<DatabaseRepository<UserProfile>>());
            // Репозиторий компьютеров
            Computers = new DatabaseRepository<Computer>(contextProvider, loggerFactory.CreateLogger<DatabaseRepository<Computer>>());
        }

        /// <summary>
        /// Репозиторий профилей пользователей.
        /// </summary>
        public IDatabaseRepository<UserProfile> UsersProfiles { get; }

        /// <summary>
        /// Репозиторий компьютеров.
        /// </summary>
        public IDatabaseRepository<Computer> Computers { get; }
    }
}
