namespace Inventory_Atlas.Application.Services.PasswordHasher
{
    /// <summary>
    /// Сервис для хеширования и проверки паролей пользователей.
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        /// <inheritdoc/>
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <inheritdoc/>
        public bool Verify(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}
