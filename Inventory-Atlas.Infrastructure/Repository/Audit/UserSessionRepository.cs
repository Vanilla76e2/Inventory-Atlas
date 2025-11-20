using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.DatabaseContextProvider;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Repository.Audit
{
    /// <summary>
    /// Репозиторий для работы с сессиями пользователей.
    /// <para/>
    /// Наследуется от <see cref="DatabaseRepository{UserSession}"/> и реализует <see cref="IUserSessionRepository"/>.
    /// </summary>
    public class UserSessionRepository : DatabaseRepository<UserSession>, IUserSessionRepository
    {
        /// <summary>
        /// Создаёт экземпляр <see cref="UserSessionRepository"/> с указанным провайдером контекста БД и логгером.
        /// </summary>
        /// <param name="contextProvider">Провайдер контекста базы данных.</param>
        /// <param name="logger">Логгер для записи действий репозитория.</param>
        public UserSessionRepository(IDatabaseContextProvider contextProvider, ILogger<UserSessionRepository> logger)
            : base(contextProvider, logger)
        {
        }

        public async Task<UserSession?> GetSessionByToken(Guid token)
        {
            return await FindAsync(us => us.Token == token);
        }

        /// <inheritdoc/>
        public async Task<UserSession?> GetActiveSessionByUsernameAsync(string username)
        {
            return await FindAsync(us => us.Username == username && us.IsActive);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserSession>> GetSessionsByUsernameAsync(string username)
        {
            return await FindManyAsync(us => us.Username == username);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserSession>> GetSessionsInRangeAsync(DateTime fromUtc, DateTime toUtc)
        {
            return await FindManyAsync(us => us.StartTime >= fromUtc && (us.EndTime ?? DateTime.MaxValue) <= toUtc);
        }
    }
}
