using Inventory_Atlas.Core.DTOs.Users;

namespace Inventory_Atlas.Application.Services.Users
{
    public interface IRoleService
    {
        Task<RoleDto> GetByNameAsync(string roleName, CancellationToken ct = default);
    }
}
