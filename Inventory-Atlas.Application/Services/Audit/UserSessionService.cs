using Inventory_Atlas.Application.Services.TokenService;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using System.Net;

namespace Inventory_Atlas.Application.Services.Audit
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserSessionRepository _sessionRepo;
        private readonly ITokenGenerator _tokenGenerator;

        public UserSessionService(IUserSessionRepository sessionRepo,
                                  ITokenGenerator tokenGenerator,
                                  IUnitOfWork uow)
        {
            _tokenGenerator = tokenGenerator;
            _sessionRepo = sessionRepo;
            _uow = uow;
        }

        /// <inheritdoc/>
        public async Task<UserSession> CreateSessionAsync(string username, string? ip, string? userAgent, CancellationToken ct = default)
        {
            var session = new UserSession
            {
                Token = _tokenGenerator.GenerateToken(username),
                Username = username,
                StartTime = DateTime.UtcNow,
                IsActive = true,
                IpAddress = ip,
                UserAgent = userAgent
            };

            // Устанавливаем текущий токен сессии для AuditContext, чтобы Audit.NET мог корректно связать действия с пользователем.
            // Это небольшое нарушение слоёв (инфраструктурный сервис влияет на кросс-срезовый контекст), но оправдано для корректного логирования. 
            AuditContext.SessionToken = session.Token;

            _sessionRepo.Add(session);
            await _uow.SaveChangesAsync(ct);
            return session;
        }

        /// <inheritdoc/>
        public async Task<UserSession?> ValidateTokenAsync(string token, CancellationToken ct = default)
        {
            return await _sessionRepo.FindAsync(
                s => s.Token == token && s.IsActive,
                ct);
        }

        /// <inheritdoc/>
        public async Task InvalidateSessionAsync(string token, CancellationToken ct = default)
        {
            var session = await _sessionRepo.FindAsync(s => s.Token == token, ct);
            if (session == null)
                return;

            session.IsActive = false;
            session.EndTime = DateTime.UtcNow;

            _sessionRepo.Update(session);
            await _uow.SaveChangesAsync(ct);
        }

        /// <inheritdoc/>
        public async Task<UserSession?> GetSessionByToken(string token, CancellationToken ct = default)
        {
            return await _sessionRepo.GetSessionByToken(token, ct);
        }
    }
}
