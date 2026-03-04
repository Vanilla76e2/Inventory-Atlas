using Inventory_Atlas.Application.Services.PermissionService;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Inventory_Atlas.Server.Authorization
{
    public class AdminRequirementHandler : AuthorizationHandler<AdminRequirement>
    {
        private readonly IPermissionService _permissionService;
        private readonly ILogger<AdminRequirementHandler> _logger;

        public AdminRequirementHandler(IPermissionService permissionService, ILogger<AdminRequirementHandler> logger)
        {
            _permissionService = permissionService;
            _logger = logger;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AdminRequirement requirement)
        {
            _logger.LogDebug("AdminOnly policy check.");

            var roleIdClaim = context.User.FindFirst(ClaimTypes.Role);
            if (roleIdClaim == null) return;

            if (!int.TryParse(roleIdClaim.Value, out var roleId))
            {
                _logger.LogWarning("No role Id in token found.");
                return;
            }

            if (await _permissionService.HasAdminPermission(roleId))
            {
                _logger.LogDebug("AdminOnly policy check passed successfuly");
                context.Succeed(requirement);
            }

            _logger.LogWarning("AdminOnly policy check failed.");
        }
    }
}
