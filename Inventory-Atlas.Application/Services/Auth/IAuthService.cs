using Inventory_Atlas.Core.Models;
using System.Net;

namespace Inventory_Atlas.Application.Services.Auth
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
        Task<LoginResponse?> LoginAsync(string username, string password, string? userAgent = null, string? ip = null);

        /// <summary>
        /// Метод для выхода пользователя из системы по токену сессии.
        /// </summary>
        /// <param name="token">Токен пользователя.</param>
        Task<bool> LogoutAsync(string token);
    }
}
