using Inventory_Atlas.Application.Services.Common;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Application.Services.Users
{
    public interface IUserProfileService
    {
        Task<UserProfile?> GetByUsernameAsync(string username);

        Task<IEnumerable<UserProfile>> GetActiveUsersAsync();
    }
}
