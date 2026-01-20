using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Inventory_Atlas.Core.Models.Http;
using Inventory_Atlas.Application.Services.Auth;

namespace Inventory_Atlas.Server.Controllers
{
    /// <summary>
    /// Контроллер для аутентификации пользователей.
    /// </summary>
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        /// <summary>
        /// Создаёт новый экземпляр <see cref="AuthController"/>.
        /// </summary>
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// Метод для аутентификации пользователя и получения токена доступа.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <returns><see cref="IActionResult"/>.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequests request, CancellationToken ct)
        {
            _logger.LogInformation("Login attempt for user: {Username}", request.Username);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clientInfo = HttpContext.GetClientInfo(); 

            var result = await _authService.LoginAsync(request.Username, request.Password, clientInfo, ct);

            if (!result.Success)
            {
                _logger.LogWarning("Failed login attempt for user: {Username} from IP: {IP} with agent: {UserAgent}", request.Username, clientInfo.IpAddress, clientInfo.UserAgent);
                return Unauthorized(Core.ErrorCodes.AuthInvalidCredentials);
            }

            _logger.LogInformation("User {Username} logged in successfully from IP: {IP} with agent: {UserAgent}", request.Username, clientInfo.IpAddress, clientInfo.UserAgent);
            return Ok(result);
        }

        /// <summary>
        /// Метод для выхода пользователя из системы по токену сессии.
        /// </summary>
        /// <returns><see cref="IActionResult"/>.</returns>
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation($"Attempt to logout user ...");
         
            var clientInfo = HttpContext.GetClientInfo();

            if (clientInfo == null || string.IsNullOrWhiteSpace(clientInfo.SessionToken))
            {
                _logger.LogWarning(
                    "Invalid session. Client is null or SessionToken is empty. IP: {Ip}, Path: {Path}",
                    HttpContext.Connection.RemoteIpAddress?.ToString(),
                    HttpContext.Request.Path
                );
                return Ok();
            }   
            
            var result = await _authService.LogoutAsync(clientInfo);

            _logger.LogInformation("Logout processed successfully from IP {IP} with User-Agent {UserAgent}", clientInfo.IpAddress, clientInfo.UserAgent);

            return Ok();
        }
    }
}