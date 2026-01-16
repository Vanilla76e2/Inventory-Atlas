using Inventory_Atlas.Core.DTOs.Users;

namespace Inventory_Atlas.Application.Services.DatabaseServices.Users
{
    public interface IRoleService
    {
        Task<RoleDto> GetByNameAsync(string roleName, CancellationToken ct = default);
    }
}
