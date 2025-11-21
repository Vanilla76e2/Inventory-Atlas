using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Application.Services.Users
{
    public interface IUserProfileService
    {
        Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken ct = default);

        Task<List<UserProfile>> GetActiveUsersAsync(CancellationToken ct = default);
    }
}
