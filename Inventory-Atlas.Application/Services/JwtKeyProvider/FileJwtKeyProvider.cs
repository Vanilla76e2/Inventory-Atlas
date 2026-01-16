using System.Security.Cryptography;

namespace Inventory_Atlas.Infrastructure.Services.JwtKeyProvider
{
    public class FileJwtKeyProvider : IJwtKeyProvider
    {
        private readonly string _path = OperatingSystem.IsWindows()
            ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "InventoryAtlas", "jwt.key")
            : "etc/inventoryatlas/jwt.key";
     
        public string GetKey()
        {
            if (!File.Exists(_path))
                return GenerateAndStoreKey();

            return File.ReadAllText(_path);
        }

        private string GenerateAndStoreKey()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);
            var key = Convert.ToBase64String(bytes);

            Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
            File.WriteAllText(_path, key);

            try
            {
                // Linux права 600
                if (!OperatingSystem.IsWindows())
                {
                    UnixFileMode mode = UnixFileMode.UserRead | UnixFileMode.UserWrite;
                    File.SetUnixFileMode(_path, mode);
                }
            }
            catch { /* игнор — на Windows это не нужно */ }

            return key;
        }
    }
}
