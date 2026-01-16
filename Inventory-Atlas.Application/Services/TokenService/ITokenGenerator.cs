namespace Inventory_Atlas.Infrastructure.Services.TokenService
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
        string GenerateToken(string username);
    }
}
