using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Server.Attributes;

namespace Inventory_Atlas.Application.Services.Middlewares
{
    public class AuditEnrichmentMiddleware
    {
        private readonly RequestDelegate _next;

        public AuditEnrichmentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            AuditContext.SessionToken = context.Request.Headers["Authriation"]
                .FirstOrDefault()?.Replace("Bearer ", "");

            var endpoint = context.GetEndpoint();

            var actionAttr = endpoint?.Metadata.GetMetadata<AuditActionAttribute>();
            if (actionAttr != null)
            {
                AuditContext.ActionType = actionAttr.ActionType;
            }
            else
            {
                AuditContext.ActionType = ActionType.Unknown;
            }

            await _next(context);
        }
    }
}
