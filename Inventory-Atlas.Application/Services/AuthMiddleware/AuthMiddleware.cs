using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Services.Users;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Microsoft.AspNetCore.Http;

namespace Inventory_Atlas.Application.Services.AuthMiddleware
{
    /// <summary>
    /// Middleware для аутентификации пользователей по токену сессии.
    /// <para/>
    /// Извлекает токен из заголовка Authorization, проверяет сессию и загружает пользователя и права.
    /// Все данные прокидываются в <see cref="HttpContext.Items"/> под ключами:
    /// <para/><c>"Session"</c> — <see cref="UserSession"/> или null,
    /// <para/><c>"User"</c> — <see cref="UserProfile"/> или null,
    /// <para/><c>"Permissions"</c> — JSON-строка прав пользователя или "{}".
    /// </summary>
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUserSessionService _sessionService;
        private readonly IUserProfileService _userService;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="AuthMiddleware"/>.
        /// </summary>
        /// <param name="next">Следующий middleware в конвейере.</param>
        /// <param name="sessionService">Сервис работы с сессиями пользователей.</param>
        /// <param name="userService">Сервис работы с пользователями.</param>
        public AuthMiddleware(
        RequestDelegate next,
        IUserSessionService sessionService,
        IUserProfileService userService)
        {
            _next = next;
            _sessionService = sessionService;
            _userService = userService;
        }

        /// <summary>
        /// Основной метод middleware, вызываемый для каждого HTTP-запроса.
        /// <para/>
        /// Извлекает токен из заголовка, проверяет активную сессию, подгружает пользователя и права.
        /// Результаты сохраняются в <see cref="HttpContext.Items"/> и запрос передаётся дальше.
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса.</param>
        /// <returns>Задача <see cref="Task"/>.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var token = ExtractToken(context);
            UserSession? session = null;
            UserProfile? user = null;
            string permissions = "{}";

            if (token != null)
            {
                session = await _sessionService.ValidateTokenAsync(token.Value);
                if (session != null)
                {
                    user = await _userService.GetByUsernameAsync(session.Username);
                    if (user?.Role != null)
                    {
                        permissions = user.Role.PermissionJson ?? "{}";
                    }
                    else
                    {
                        session = null;
                        user = null;
                    }
                }
            }

            context.Items["Session"] = session;
            context.Items["User"] = user;
            context.Items["Permissions"] = permissions;

            await _next(context);
        }

        /// <summary>
        /// Извлекает токен из заголовка Authorization.
        /// <para/>
        /// Ожидается формат: <c>Authorization: Bearer &lt;token&gt;</c>.
        /// </summary>
        /// <param name="context">Контекст HTTP-запроса.</param>
        /// <returns>Guid токена сессии или null, если токен отсутствует или некорректен.</returns>
        private static Guid? ExtractToken(HttpContext context)
        {
            var header = context.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(header))
                return null;

            const string bearerPrefix = "Bearer ";

            if (!header.StartsWith(bearerPrefix, StringComparison.OrdinalIgnoreCase))
                return null;

            var tokenPart = header[bearerPrefix.Length..].Trim();

            if (Guid.TryParse(tokenPart, out var token))
                return token;

            return null;
        }
    }
}
