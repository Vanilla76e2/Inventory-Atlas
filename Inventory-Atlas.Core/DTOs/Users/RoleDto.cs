using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Users
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsSystem { get; set; }
        public int UserCount { get; set; }
    }

    public class RolePermissionsDto : RoleDto
    {
        public string PermissionJson { get; set; } = "[]";
    }
}
