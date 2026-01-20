namespace Inventory_Atlas.Application.Services.PasswordHasher
{
    /// <summary>
    /// Интерфейс сервиса для хеширования и проверки паролей пользователей.
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Метод для проверки пароля пользователя на соответствие хэшу.
        /// </summary>
        /// <param name="password">Пароль.</param>
        /// <param name="storedHash">Хэш пароля.</param>
        /// <returns><see langword="true"/> — Если пароль соотвествует хэшу, иначе <see langword="false"/>.</returns>
        bool Verify(string password, string storedHash);

        /// <summary>
        /// Метод для хеширования пароля пользователя.
        /// </summary>
        /// <param name="password">Пароль.</param>
        /// <returns>Хэш пароля.</returns>
        public string Hash(string password);
    }
}
