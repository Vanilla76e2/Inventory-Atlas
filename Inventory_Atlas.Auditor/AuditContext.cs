using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Auditor
{
    public class AuditContext
    {
        public int? UserId { get; set; }
        public string? SessionToken { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }

        public ActionType ActionType { get; set; } = Core.Enums.ActionType.Unknown;

        public string? TargetType { get; set; }
        public string? TargetId { get; set; }

        public Dictionary<string, object>? Details { get; set; }
    }
}
