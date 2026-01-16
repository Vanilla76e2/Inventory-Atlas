using Inventory_Atlas.Infrastructure.Services.PermissionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Inventory_Atlas.Server.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AdminOnlyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var permService = context.HttpContext.RequestServices.GetService<IPermissionService>();
            var logger = context.HttpContext.RequestServices.GetService<ILogger<AdminOnlyAttribute>>();

            logger?.LogDebug("Checking admin permissions for the current user.");

            if (!permService!.HasAdminPermission(context.HttpContext))
            {
                logger?.LogDebug("Access denied. User does not have admin permissions.");
                context.Result = new ForbidResult();
                return;
            }

            logger?.LogDebug("Access granted. User has admin permissions.");
            await next();
        }
    }
}
