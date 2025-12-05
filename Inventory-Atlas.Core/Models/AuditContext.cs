using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Core.Models
{
    public static class AuditContext
    {
        private static readonly AsyncLocal<string?> _sessionToken = new();
        private static readonly AsyncLocal<ActionType?> _actionType = new();

        public static string? SessionToken
        {
            get => _sessionToken.Value;
            set => _sessionToken.Value = value;
        }

        public static ActionType? ActionType
        {
            get => _actionType.Value;
            set => _actionType.Value = value;
        }
    }
}
