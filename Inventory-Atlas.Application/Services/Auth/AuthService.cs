using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Application.Services.TokenService;
using Inventory_Atlas.Core;
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
        private readonly IUserSessionService _sessionService;
        private readonly IUserProfileRepository _userRepo;
        private readonly IPasswordHasher _hasher;
        private readonly IUnitOfWork _uow;

        /// <summary>
        /// Создаёт новый экземпляр <see cref="AuthService"/>.
        /// </summary>
        /// <param name="logger">Сервис логирования событий в программе.</param>
        /// <param name="sessionService">Репозиторий сессий пользователей.</param>
        /// <param name="userRepo">Репозиторий профилей пользователей.</param>
        /// <param name="hasher">Сервис хэширования паролей.</param>
        /// <param name="logService">Сервис логирования действий пользователей.</param>
        /// <param name="uow">Единица работы.</param>
        public AuthService(ILogger<AuthService> logger, 
                           IUserProfileRepository userRepo, 
                           IUserSessionService sessionService,
                           IPasswordHasher hasher,
                           IUnitOfWork uow,
                           ITokenGenerator tokenGenerator)
        {
            _sessionService = sessionService;
            _userRepo = userRepo;
            _logger = logger;
            _hasher = hasher;
            _uow = uow;
        }

        /// <inheritdoc/>
        public async Task<LoginResponse> LoginAsync(string username, string password, string? userAgent, 
                                                     string? ip, CancellationToken ct = default)
        {
            _logger.LogDebug("Attempting to log in user {Username}", username);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return new LoginResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.AuthMissingCredentials
                };

            var user = await _userRepo.GetByUsernameAsync(username, ct);
            if (user == null)
            {
                _logger.LogDebug("User {Username} not found during login attempt", username);
                return new LoginResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.AuthInvalidCredentials
                };
            }

            if (!user.IsActive)
            {
                _logger.LogDebug($"User {username} is not active.");
                return new LoginResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.AuthUserInactive
                };
            }

            if (!_hasher.Verify(password, user.PasswordHash))
            {
                _logger.LogDebug("Invalid password for user {Username}", username);
                return new LoginResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.AuthInvalidCredentials
                };
            }

            _logger.LogDebug("{Username} authenticated successfuly from {IpAddress} {Useragent}", username, ip, userAgent);
            var session = await _sessionService.CreateSessionAsync(username, 
                                                                   ip, 
                                                                   userAgent);

            _logger.LogDebug("User {Username} logged in successfully with session token {Token}", username, session.Token);
            return new LoginResponse
            {
                Success = true,
                Token = session.Token
            };
            
        }

        /// <inheritdoc/>
        public async Task<bool> LogoutAsync(string token, CancellationToken ct = default)
        {
            _logger.LogDebug("Attempting to logout session with token {Token}", token);
            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.LogWarning("Invalid token format: {Token}", token);
                return true;
            }

            var session = await _sessionService.GetSessionByToken(token);

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
                await _uow.SaveChangesAsync(ct);
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
