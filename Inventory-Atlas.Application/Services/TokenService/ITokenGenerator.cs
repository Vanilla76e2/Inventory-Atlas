using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Application.Services.TokenService
{
    /// <summary>
    /// Интерфейс сервиса предоставляющего токены для сессий пользователей.
    /// </summary>
    public interface ITokenGenerator
    {
        /// <summary>
        /// Метод генерации токенов.
        /// </summary>
        /// <returns>Токен в виде строки.</returns>
        string GenerateToken(UserProfile user);
    }
}
