using Inventory_Atlas.Application.Services.Auth;
using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Server.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Login attempt for user: {Username}", request.Username);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userAgent = Request.Headers["User-Agent"].ToString();
            var ipAddress = Request.Headers["X-Forwarded-For"].FirstOrDefault() 
                ?? HttpContext.Connection.RemoteIpAddress?.ToString();

            var result = await _authService.LoginAsync(request.Username, request.Password, userAgent, ipAddress);

            if (result == null)
            {
                _logger.LogWarning("Failed login attempt for user: {Username} from IP: {IP} with agent: {UserAgent}", request.Username, ipAddress, userAgent);
                return Unauthorized("Неверный логин или пароль.");
            }

            _logger.LogInformation("User {Username} logged in successfully from IP: {IP} with agent: {UserAgent}", request.Username, ipAddress, userAgent);
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
            var userAgent = Request.Headers["User-Agent"].ToString();
            var ipAddress = Request.Headers["X-Forwarded-For"].FirstOrDefault()
                ?? HttpContext.Connection.RemoteIpAddress?.ToString();

            _logger.LogInformation("Logout attempt received.");
         
            var tokenStr = Request.Headers["Authorization"].ToString();
            if(!tokenStr.StartsWith("Bearer "))
            {
                _logger.LogWarning("Logout attempt without Bearer token.");
                return Unauthorized("Токен не предоставлен.");
            }

            var token = tokenStr.Substring("Bearer ".Length).Trim();

            var success = await _authService.LogoutAsync(token);

            _logger.LogInformation("Logout processed successfully from IP {IP} with User-Agent {UserAgent}", ipAddress, userAgent);

            return Ok();
        }
    }
}