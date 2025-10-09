using Inventory_Atlas.Core.DTOs.Common;

namespace Inventory_Atlas.Core.DTOs.Users
{
    public class UserProfileDto : AuditableDto
    {
        public string Username { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; }
        public string? Employee { get; set; }
        public RoleDto Role { get; set; } = null!;
    }
}
