namespace Inventory_Atlas.Infrastructure.Services.PasswordHasher
{
    /// <summary>
    /// Сервис для хеширования и проверки паролей пользователей.
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        /// <inheritdoc/>
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        /// <inheritdoc/>
        public bool Verify(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, storedHash);
        }
    }
}
