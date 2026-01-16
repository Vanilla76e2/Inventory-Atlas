using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Services.TokenService;

namespace Inventory_Atlas.Application.Services.DatabaseServices.Audit
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IUserSessionRepository _sessionRepo;
        private readonly ITokenGenerator _tokenGenerator;

        public UserSessionService(IUserSessionRepository sessionRepo,
                                  ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
            _sessionRepo = sessionRepo;
        }

        /// <inheritdoc/>
        public UserSession CreateSession(string username, 
            int userId, 
            string? ip, 
            string? userAgent)
        {
            var session = new UserSession(
                token: _tokenGenerator.GenerateToken(username),
                username: username,
                userId: userId,
                ipAddress: ip,
                userAgent: userAgent
            );

            _sessionRepo.Add(session);
            return session;
        }

        /// <inheritdoc/>
        public async Task<bool> ValidateTokenAsync(string token, CancellationToken ct = default)
        {
            var session = await _sessionRepo.GetActiveSessionByTokenAsync(token, ct);
            return session != null;
        }

        /// <inheritdoc/>
        public async Task InvalidateSessionAsync(string token, CancellationToken ct = default)
        {
            var session = await _sessionRepo.GetSessionByTokenAsync(token, ct);
            if (session == null)
                return;

            session.Invalidate();
        }

        /// <inheritdoc/>
        public async Task<UserSession?> GetSessionByTokenAsync(string token, CancellationToken ct = default)
        {
            return await _sessionRepo.GetSessionByTokenAsync(token, ct);
        }

        /// <inheritedoc/>
        public async Task InvalidateAllSessionsForUser(string username, CancellationToken ct = default)
        {
            var sessions = await _sessionRepo.GetActiveSessionsByUsernameAsync(username, ct);

            foreach (var session in sessions)
            {
                session.Invalidate();
            }
        }

        public async Task<int?> GetUserIdByTokenAsync(string token, CancellationToken ct = default)
        {
            var session = await _sessionRepo.GetSessionByTokenAsync(token, ct);

            if (session == null)
                return null;

            return session.UserId;
        }
    }
}
