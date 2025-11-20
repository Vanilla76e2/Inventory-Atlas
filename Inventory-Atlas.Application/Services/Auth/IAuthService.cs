using Inventory_Atlas.Core.Models;

namespace Inventory_Atlas.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(string username, string password, string? userAgent = null);
        Task LogoutAsync(string token);
    }
}
