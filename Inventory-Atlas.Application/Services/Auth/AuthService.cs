using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Inventory_Atlas.Application.Services.Auth
{
    /// <summary>
    /// Сервис для аутентификации пользователей.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly ILogger _logger;
        private readonly IUserSessionRepository _sessionRepo;
        private readonly IUserProfileRepository _userRepo;
        private readonly IPasswordHasher _hasher;
        private readonly ILogEntryService _logService;
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Создаёт новый экземпляр <see cref="AuthService"/>.
        /// </summary>
        /// <param name="logger">Сервис логирования событий в программе.</param>
        /// <param name="sessionRepo">Репозиторий сессий пользователей.</param>
        /// <param name="userRepo">Репозиторий профилей пользователей.</param>
        /// <param name="hasher">Сервис хэширования паролей.</param>
        /// <param name="logService">Сервис логирования действий пользователей.</param>
        /// <param name="uow">Единица работы.</param>
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

        /// <inheritdoc/>
        public async Task<LoginResponse?> LoginAsync(string username, string password, string? userAgent, string? ip)
        {
            _logger.LogDebug("Attempting to log in user {Username}", username);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = await _userRepo.GetByUsernameAsync(username);
            if (user == null)
            {
                _logger.LogDebug("User {Username} not found during login attempt", username);
                return null;
            }

            if (!_hasher.Verify(password, user.PasswordHash))
            {
                _logger.LogDebug("Invalid password for user {Username}", username);
                return null;
            }

            var token = Guid.NewGuid();

            _logger.LogDebug("{Username} authenticated successfuly from {IpAddress} {Useragent}", username, ip, userAgent);
            var session = new UserSession
            {
                Token = token,
                Username = user.Username,
                UserId = user.Id,
                IsActive = true,
                StartTime = DateTime.UtcNow,
                UserAgent = userAgent,
                IpAddress = IPAddress.TryParse(ip, out var ipAddress) ? ipAddress : null
            };

            try
            {
                await _sessionRepo.AddAsync(session);
                await _uow.SaveChangesAsync();

                await _logService.LogAndSaveAsync(ActionType.Login, session.Id);

                _logger.LogDebug("User {Username} logged in successfully with session token {Token}", username, token);
                return new LoginResponse { Token = token.ToString() };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating user session for {Username}", username);
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> LogoutAsync(string token)
        {
            _logger.LogDebug("Attempting to logout session with token {Token}", token);
            if (!Guid.TryParse(token, out var tokenGuid))
            {
                _logger.LogWarning("Invalid token format: {Token}", token);
                return true;
            }

            var session = await _sessionRepo.GetSessionByToken(tokenGuid);

            if (session == null)
            {
                _logger.LogWarning("No session found for token {Token}", token);
                return true;
            }

            if (!session.IsActive)
            {
                _logger.LogWarning("Session with token {Token} is already inactive", token);
                return true;
            }

            session.IsActive = false;
            session.EndTime = DateTime.UtcNow;
            try
            {
                await _uow.SaveChangesAsync();
                await _logService.LogAndSaveAsync(ActionType.Logout, session.Id);
                _logger.LogDebug("Successfully logged out session with token {Token}", token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while logging out session with token {Token}", token);
            }
            
            return true;
        }
    }
}
