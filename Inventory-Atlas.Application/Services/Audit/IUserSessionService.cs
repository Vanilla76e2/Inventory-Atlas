using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Audit;
using Inventory_Atlas.Infrastructure.Entities.Users;
using System.Net;

namespace Inventory_Atlas.Application.Services.Audit
{
    /// <summary>
    /// Сервис для управления сессиями пользователей.
    /// </summary>
    public interface IUserSessionService
    {
        /// <summary>
        /// Создаёт новую сессию для пользователя при авторизации.
        /// </summary>
        /// <param name="user">Профиль пользователя, для которого создаётся сессия.</param>
        /// <param name="ip">IP-адрес клиента, с которого авторизуется пользователь. Может быть null.</param>
        /// <param name="userAgent">User-Agent клиента. Может быть null.</param>
        /// <param name="ct">Токен отмены операции.</param>
        /// <returns>Созданная сессия с уникальным токеном.</returns>
        Task<UserSession> CreateSessionAsync(string username, string? ip, string? userAgent, CancellationToken ct = default);

        /// <summary>
        /// Проверяет токен сессии и возвращает сессию, если она действительна.
        /// </summary>
        /// <param name="token">Токен сессии, переданный клиентом.</param>
        /// <param name="ct">Токен отмены операции.</param>
        /// <returns>
        /// Сессию пользователя, если токен найден и сессия активна/не истекла; 
        /// иначе <see langword="null"/>.
        /// </returns>
        Task<UserSession?> ValidateTokenAsync(string token, CancellationToken ct = default);

        /// <summary>
        /// Аннулирует (удаляет или помечает неактивной) сессию по токену.
        /// Используется для выхода пользователя или отмены токена.
        /// </summary>
        /// <param name="token">Токен сессии, которая должна быть завершена.</param>
        /// <param name="ct">Токен отмены операции.</param>
        Task InvalidateSessionAsync(string token, CancellationToken ct = default);

        /// <summary>
        /// Ищет сессию по токену сессии.
        /// </summary>
        /// <param name="token">Токен сессии.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns><see cref="UserSession"/> с заданным токеном или <see langword="null"/> если такой сессии нет.</returns>
        Task<UserSession?> GetSessionByToken(string token, CancellationToken ct = default);
    }
}
