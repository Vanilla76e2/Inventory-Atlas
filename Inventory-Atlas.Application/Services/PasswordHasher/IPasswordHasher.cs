namespace Inventory_Atlas.Application.Services.PasswordHasher
{
    public interface IPasswordHasher
    {
        bool Verify(string password, string storedHash);
        public string Hash(string password);
    }
}
