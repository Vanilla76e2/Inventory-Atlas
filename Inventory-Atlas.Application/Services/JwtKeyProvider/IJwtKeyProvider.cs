namespace Inventory_Atlas.Application.Services.JwtKeyProvider
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
