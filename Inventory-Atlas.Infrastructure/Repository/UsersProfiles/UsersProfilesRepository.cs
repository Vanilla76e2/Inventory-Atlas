using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.UsersProfiles
{
    /// <summary>
    /// Репозиторий для работы с профилями пользователей.
    /// </summary>
    public class UsersProfilesRepository : DatabaseRepository<UserProfile>, IUsersProfilesRepository
    {
        /// <summary>
        /// Конструктор репозитория профилей пользователей.
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="logger">Логгер.</param>
        public UsersProfilesRepository(IDatabaseContextProvider contextProvider, ILogger<UsersProfilesRepository> logger) 
            : base(contextProvider, logger)
        {
        }

        /// <summary>
        /// Асинхронно получает профиль пользователя по имени пользователя.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Профиль пользователя или null, если не найден.</returns>
        public async Task<UserProfile?> GetByUsernameAsync(string username)
        {
            return await FindAsync(x => x.Username == username);
        }

        // Сюда добавлять методы, специфичные для UsersProfile
    }
}
