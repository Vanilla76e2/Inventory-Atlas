using Audit.Core;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Core.Models.Http;
using Inventory_Atlas.Infrastructure.Auditor;

namespace Inventory_Atlas.Infrastructure.Services.Auth
{
    /// <summary>
    /// Сервис для аутентификации пользователей.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Метод для аутентификации пользователя и получения токена доступа.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="userAgent">Агент пользователя.</param>
        /// <param name="ip">IP пользователя.</param>
        /// <returns>Ответ в виде <see cref="LoginResponse"/> с токеном сессии. Если не удалось создать сессию то <see langword="null"/>.</returns>
        Task<LoginResponse> LoginAsync(
            string username, 
            string password, 
            ClientInfo clientInfo,
            CancellationToken ct = default);

        /// <summary>
        /// Метод для выхода пользователя из системы по токену сессии.
        /// </summary>
        /// <param name="token">Токен пользователя.</param>
        Task<bool> LogoutAsync(
            ClientInfo clientInfo, 
            CancellationToken ct = default);
    }
}
