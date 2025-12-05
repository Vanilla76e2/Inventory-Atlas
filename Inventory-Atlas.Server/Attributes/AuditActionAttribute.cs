using Inventory_Atlas.Core.Enums;

namespace Inventory_Atlas.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AuditActionAttribute : Attribute
    {
        public ActionType ActionType { get; }

        public AuditActionAttribute(ActionType actionType)
        {
            ActionType = actionType;
        }
    }
}
