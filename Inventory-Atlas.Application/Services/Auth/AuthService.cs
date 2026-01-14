using Audit.Core;
using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Application.Services.TokenService;
using Inventory_Atlas.Application.Services.Users;
using Inventory_Atlas.Core;
using Inventory_Atlas.Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Inventory_Atlas.Application.Auditor.Service;

namespace Inventory_Atlas.Application.Services.Auth
{
    /// <summary>
    /// Сервис для аутентификации пользователей.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly ILogger _logger;
        private readonly IUserSessionService _sessionService;
        private readonly IUserProfileService _userService;
        private readonly IPasswordHasher _hasher;
        private readonly IAuditService _audit;

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
                           IUserProfileService userService,
                           IUserSessionService sessionService,
                           IPasswordHasher hasher,
                           ITokenGenerator tokenGenerator,
                           IAuditService audit)
        {
            _sessionService = sessionService;
            _logger = logger;
            _hasher = hasher;
            _userService = userService;
            _audit = audit;
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

            var user = await _userService.GetByUsernameAsync(username, ct);
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

            using var scope = _audit.BeginScope(new Auditor.AuditContext{});

            _logger.LogDebug("{Username} authenticated successfuly from {IpAddress} {Useragent}", username, ip, userAgent);
            try
            {
                var session = await _sessionService.CreateSession(username, user.Id, ip, userAgent, ct);

                _logger.LogDebug("User {Username} logged in successfully with session token {Token}", username, session.Token);
                return new LoginResponse
                {
                    Success = true,
                    Token = session.Token
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating session for user {Username}", username);
                return new LoginResponse
                {
                    Success = false,
                    ErrorCode = ErrorCodes.UnexpectedError
                };
            }
        }

        /// <inheritdoc/>
        public async Task<bool> LogoutAsync(string token, CancellationToken ct = default, IAuditScope? parentScope = null)
        {
            _logger.LogDebug("Attempting to logout session with token {Token}", token);
            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.LogWarning("Invalid token format: {Token}", token);
                return true;
            }

            try
            {
                await _sessionService.InvalidateSessionAsync(token, ct, scope);
                _logger.LogDebug("Session with token {Token} logged out successfully", token);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating session with token {Token}", token);
                return true;
            }
        }
    }
}
