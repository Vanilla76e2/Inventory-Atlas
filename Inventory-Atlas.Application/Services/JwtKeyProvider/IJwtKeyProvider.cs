namespace Inventory_Atlas.Infrastructure.Services.JwtKeyProvider
{
    /// <summary>
    /// Интерфейс предоставляющий приватный ключ для создания JWT токенов.
    /// </summary>
    public interface IJwtKeyProvider
    {
        /// <summary>
        /// Метод генерирующий приватный ключ для создания JWT токенов.
        /// </summary>
        /// <returns></returns>
        string GetKey();
    }
}
