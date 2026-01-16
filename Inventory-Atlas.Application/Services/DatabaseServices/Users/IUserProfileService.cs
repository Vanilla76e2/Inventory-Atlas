using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Application.Services.DatabaseServices.Users
{
    /// <summary>
    /// Сервис для работы с профилями пользователей.
    /// </summary>
    public interface IUserProfileService
    {
        /// <summary>
        /// Получает профиль пользователя по имени пользователя.
        /// </summary>
        /// <param name="username">Имя пользователя для поиска.</param>
        /// <param name="ct">Токен отмены операции.</param>
        /// <returns>Профиль пользователя или <see langword="null"/>, если пользователь не найден.</returns>
        Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken ct = default);

        /// <summary>
        /// Возвращает список пользователей, которые могут авторизоваться в системе.
        /// </summary>
        /// <param name="ct">Токен отмены операции.</param>
        /// <returns>Список профилей пользователей с активным статусом, допускающих вход в систему.</returns>
        Task<List<UserProfile>> GetActiveUsersAsync(CancellationToken ct = default);

        /// <summary>
        /// Создаёт пользователя и асинхронно сохраняет.
        /// </summary>
        /// <param name="newUser">DTO с данными для создания пользователя.</param>
        /// <param name="sessionToken">Токен сессии пользователя.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns><see cref="Response{T}"/> с <see cref="UserProfileDto"/>.</returns>
        Task<Response<UserProfileDto>> CreateUserProfileAsync(UserProfileCreateDto newUser, string sessionToken, CancellationToken ct = default);

        /// <summary>
        /// Изменяет пользователя и асинхронно сохраняет.
        /// </summary>
        /// <param name="newUserDto">DTO с данными для изменения пользователя.</param>
        /// <param name="sessionToken">Токен сесии пользователя.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns><see cref="Response{T}"/> с <see cref="UserProfileDto"/>.</returns>
        Task<Response<UserProfileDto>> UpdateUserProfileAsync(UserProfileUpdateDto newUserDto, string sessionToken, CancellationToken ct = default);

    }
}
