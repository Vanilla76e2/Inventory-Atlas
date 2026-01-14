using Inventory_Atlas.Application.Entities.Users;

namespace Inventory_Atlas.Application.Services.Users
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
    }
}
