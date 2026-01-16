using Audit.Core;
using Audit.EntityFramework;
using Inventory_Atlas.Application.Services.DatabaseServices.Audit;
using Inventory_Atlas.Application.Services.DatabaseServices.Users;
using Inventory_Atlas.Core;
using Inventory_Atlas.Core.Models.Http;
using Inventory_Atlas.Infrastructure.Auditor;
using Inventory_Atlas.Infrastructure.Auditor.Service;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Services.PasswordHasher;
using Inventory_Atlas.Infrastructure.Services.TokenService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Infrastructure.Services.Auth
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
                           IUserProfileService userService,
                           IUserSessionService sessionService,
                           IPasswordHasher hasher,
                           ITokenGenerator tokenGenerator,
                           IAuditService audit,
                           IUnitOfWork uow)
        {
            _sessionService = sessionService;
            _logger = logger;
            _hasher = hasher;
            _userService = userService;
            _audit = audit;
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

            _logger.LogDebug("{Username} authenticated successfuly from {IpAddress} {Useragent}", username, ip, userAgent);
            try
            {
                var session = _sessionService.CreateSession(username, user.Id, ip, userAgent);

                await _uow.SaveChangesAsync(ct, new AuditContext
                {
                    ActionType = Core.Enums.ActionType.Login,
                    SessionToken = session.Token,
                    UserId = user.Id
                });

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
        public async Task<bool> LogoutAsync(string token, CancellationToken ct = default)
        {
            _logger.LogDebug("Attempting to logout session with token {Token}", token);
            if (string.IsNullOrWhiteSpace(token))
            {
                _logger.LogWarning("Invalid token format: {Token}", token);
                return true;
            }

            try
            {
                await _sessionService.InvalidateSessionAsync(token, ct);

                await _uow.SaveChangesAsync(ct, new AuditContext
                {
                    ActionType = Core.Enums.ActionType.Logout,
                    SessionToken = token,
                    UserId = await _sessionService.GetUserIdByTokenAsync(token)
                });

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
