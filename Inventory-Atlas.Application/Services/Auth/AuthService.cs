using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ILogger _logger;
        private readonly IUserSessionRepository _sessionRepo;
        private readonly IUserProfileRepository _userRepo;
        private readonly IPasswordHasher _hasher;
        private readonly ILogEntryService _logService;
        private readonly IUnitOfWork _uow;

        public AuthService(ILogger<AuthService> logger, 
                           IUserSessionRepository sessionRepo, 
                           IUserProfileRepository userRepo, 
                           IPasswordHasher hasher,
                           ILogEntryService logService,
                           IUnitOfWork uow)
        {
            _logger = logger;
            _sessionRepo = sessionRepo;
            _userRepo = userRepo;
            _hasher = hasher;
            _logService = logService;
            _uow = uow;
        }

        public async Task<LoginResponse?> LoginAsync(string username, string password, string? userAgent)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = await _userRepo.GetByUsernameAsync(username);
            if (user == null)
                return null;

            if (!_hasher.Verify(password, user.PasswordHash))
                return null;

            var token = Guid.NewGuid();

            var session = new UserSession
            {
                Token = token,
                Username = user.Username,
                UserId = user.Id,
                IsActive = true,
                StartTime = DateTime.UtcNow,
                UserAgent = userAgent
            };

            try
            {
                await _sessionRepo.AddAsync(session);
                await _uow.SaveChangesAsync();

                await _logService.LogLoginAsync(ActionType.Login, session.Id);

                return new LoginResponse { Token = token.ToString() };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user session for {Username}", username);
                return null;
            }
        }

        public Task LogoutAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
