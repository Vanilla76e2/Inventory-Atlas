using Inventory_Atlas.Infrastructure.Data;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
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
        public UserSessionRepository(AppDbContext context, ILogger<UserSessionRepository> logger)
            : base(context, logger)
        {
        }

        public async Task<UserSession?> GetSessionByToken(string token, CancellationToken ct = default)
        {
            return await FindAsync(us => us.Token == token, ct);
        }

        /// <inheritdoc/>
        public async Task<UserSession?> GetActiveSessionByUsernameAsync(string username, CancellationToken ct = default)
        {
            return await FindAsync(us => us.Username == username && us.IsActive, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserSession>> GetSessionsByUsernameAsync(string username, CancellationToken ct = default)
        {
            return await FindManyAsync(us => us.Username == username, ct);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserSession>> GetSessionsInRangeAsync(DateTime fromUtc, DateTime toUtc, CancellationToken ct = default)
        {
            return await FindManyAsync(us => us.StartTime >= fromUtc && (us.EndTime ?? DateTime.MaxValue) <= toUtc, ct);
        }
    }
}
