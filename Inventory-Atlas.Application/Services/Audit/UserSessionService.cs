using Inventory_Atlas.Core.DTOs.Users;
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
        public UserSessionService(IUserSessionRepository sessionRepo,
                                  IUnitOfWork uow)
        {
            _sessionRepo = sessionRepo;
            _uow = uow;
        }
        public async Task<UserSession> CreateSessionAsync(UserProfileDto user, IPAddress? ip, string? userAgent, CancellationToken ct = default)
        {
            var session = new UserSession
            {
                Token = Guid.NewGuid(),
                Username = user.Username,
                StartTime = DateTime.UtcNow,
                IsActive = true,
                IpAddress = ip,
                UserAgent = userAgent
            };
            _sessionRepo.Add(session);
            await _uow.SaveChangesAsync(ct);
            return session;
        }
        public async Task<UserSession?> ValidateTokenAsync(Guid token, CancellationToken ct = default)
        {
            return await _sessionRepo.FindAsync(
                s => s.Token == token && s.IsActive,
                ct);
        }
        public async Task InvalidateSessionAsync(Guid token, CancellationToken ct = default)
        {
            var session = await _sessionRepo.FindAsync(s => s.Token == token, ct);
            if (session == null)
                return;

            session.IsActive = false;
            session.EndTime = DateTime.UtcNow;

            _sessionRepo.Update(session);
            await _uow.SaveChangesAsync(ct);
        }
    }
}
