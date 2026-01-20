using Inventory_Atlas.Application.Services.DatabaseServices.Audit;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Core;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Core.Models.Http;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Inventory_Atlas.Application.Services.TokenService;
using Microsoft.Extensions.Logging;
using Inventory_Atlas.Auditor;

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
                           ITokenGenerator tokenGenerator,
                           IUnitOfWork uow)
        {
            _sessionService = sessionService;
            _logger = logger;
            _hasher = hasher;
            _userRepo = userRepo;
            _uow = uow;
        }

        /// <inheritdoc/>
        public async Task<LoginResponse> LoginAsync(string username, string password, ClientInfo clientInfo, CancellationToken ct = default)
        {
            _logger.LogDebug("Attempting to log in user {Username}", username);

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return LoginResponse.Fail(ErrorCodes.AuthMissingCredentials);

            var user = await _userRepo.GetWithRoleByUsername(username, ct);
            if (user == null)
            {
                _logger.LogDebug("User {Username} not found during login attempt", username);
                return LoginResponse.Fail(ErrorCodes.AuthInvalidCredentials);
            }

            if (!user.IsActive)
            {
                _logger.LogDebug($"User {username} is not active.");
                return LoginResponse.Fail(ErrorCodes.AuthUserInactive);
            }

            if (!_hasher.Verify(password, user.PasswordHash))
            {
                _logger.LogDebug("Invalid password for user {Username}", username);
                return LoginResponse.Fail(ErrorCodes.AuthInvalidCredentials);
            }

            _logger.LogDebug("{Username} authenticated successfuly from {IpAddress} {Useragent}", username, clientInfo.IpAddress, clientInfo.UserAgent);
            
            try
            {  
                var session = _sessionService.CreateSession(user, clientInfo.IpAddress, clientInfo.UserAgent);

                await _uow.SaveChangesAsync(ct, new AuditContext
                {
                    ActionType = Core.Enums.ActionType.Login,
                    SessionToken = session.Token,
                    UserId = user.Id,
                    UserAgent = clientInfo.UserAgent,
                    IpAddress = clientInfo.IpAddress
                });

                _logger.LogDebug("User {Username} logged in successfully with session token {Token}", username, session.Token);
                return LoginResponse.Ok(session.Token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating session for user {Username}", username);
                return LoginResponse.Fail(ErrorCodes.UnexpectedError);
            }
        }

        /// <inheritdoc/>
        public async Task<bool> LogoutAsync(ClientInfo clientInfo, CancellationToken ct = default)
        {
            _logger.LogDebug("Attempting to logout session with token {Token} from {IpAddress}", clientInfo.SessionToken, clientInfo.IpAddress);
            if (string.IsNullOrWhiteSpace(clientInfo.SessionToken))
            {
                _logger.LogWarning("Invalid token format: {Token}", clientInfo.SessionToken);
                return true;
            }

            try
            {
                await _sessionService.InvalidateSessionAsync(clientInfo.SessionToken, ct);

                var userId = await _sessionService.GetIdByTokenAsync(clientInfo.SessionToken);

                await _uow.SaveChangesAsync(ct, new AuditContext
                {
                    ActionType = Core.Enums.ActionType.Logout,
                    SessionToken = clientInfo.SessionToken,
                    UserId = userId,
                    UserAgent = clientInfo.UserAgent,
                    IpAddress = clientInfo.IpAddress
                });

                _logger.LogDebug("Session with token {Token} logged out successfully", clientInfo.SessionToken);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error invalidating session with token {Token}", clientInfo.SessionToken);
                return true;
            }
        }
    }
}
