using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Infrastructure.Auditor
{
    public class AuditContext
    {
        public int? UserId { get; init; }
        public string? SessionToken { get; init; }

        public ActionType ActionType { get; init; } = Core.Enums.ActionType.Unknown;

        public string? TargetType { get; init; }
        public string? TargetId { get; init; }

        public Dictionary<string, object>? Details { get; init; }
    }
}
