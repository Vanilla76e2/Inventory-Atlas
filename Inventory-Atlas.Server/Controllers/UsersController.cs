using Inventory_Atlas.Application.Services.DatabaseServices.Audit;
using Inventory_Atlas.Application.Services.DatabaseServices.Users;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Auditor;
using Inventory_Atlas.Infrastructure.Services.PermissionService;
using Inventory_Atlas.Server.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly ILogger<UsersController> _logger;
        private readonly IUserProfileService _userService;
        private readonly IUserSessionService _sessionService;

        public UsersController(
            IPermissionService permissionService, 
            ILogger<UsersController> logger, 
            IUserProfileService userService,
            IUserSessionService sessionService)
        {
            _permissionService = permissionService;
            _logger = logger;
            _userService = userService;
            _sessionService = sessionService;
        }

        [AdminOnly]
        [HttpPost("create-userprofile")]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateDto request, CancellationToken ct)
        {
            _logger.LogDebug($"Attempt to create new UserProfile with username {request.Username}...");

            var client = HttpContext.GetClientInfo();

            if (string.IsNullOrWhiteSpace(client.SessionToken))
            {
                _logger.LogWarning($"Request rejected: missing or empty SessionToken for creating user {request.Username}");
                return BadRequest(Core.ErrorCodes.InvalidSession);
            }

            if (client == null || string.IsNullOrWhiteSpace(client.SessionToken))
            {
                _logger.LogWarning(
                    "Invalid session. Client is null or SessionToken is empty. IP: {Ip}, Path: {Path}",
                    HttpContext.Connection.RemoteIpAddress?.ToString(),
                    HttpContext.Request.Path
                );
                return Unauthorized(Core.ErrorCodes.InvalidSession);
            }

            var result = await _userService.CreateAsync(request, client, ct);

            if (result.IsSuccess)
            {
                _logger.LogDebug($"Creation UserProfile with username {request.Username} was success.");
                return Ok(result.Data);
            }    
            else
            {
                _logger.LogWarning($"Creation UserProfile with username {request.Username} was denied.");
                return BadRequest(result.Error);
            }
        }

        [AdminOnly]
        [HttpPost("update-userprofile")]
        public async Task<IActionResult> UpdateUserProfile([FromBody] UserProfileUpdateDto request, CancellationToken ct)
        {
            _logger.LogDebug($"Attempt to update UserProfile with username {request.Username}...");

            var client = HttpContext.GetClientInfo();

            if (client == null || string.IsNullOrWhiteSpace(client.SessionToken))
            {
                _logger.LogWarning(
                    "Invalid session. Client is null or SessionToken is empty. IP: {Ip}, Path: {Path}",
                    HttpContext.Connection.RemoteIpAddress?.ToString(),
                    HttpContext.Request.Path
                );
                return Unauthorized(Core.ErrorCodes.InvalidSession);
            }

            var result = await _userService.UpdateAsync(request, client, ct);

            if (result.IsSuccess)
            {
                _logger.LogDebug($"Update UserProfile with username {request.Username} was success.");
                return Ok(result.Data);
            }
            else
            {
                _logger.LogWarning($"Update UserProfile with username {request.Username} was denied.");
                return BadRequest(result.Error);
            }
        }

        [AdminOnly]
        [HttpGet("get-all-userprofiles")]
        public async Task<IActionResult> GetAllUserProfiles(CancellationToken ct)
        {
            _logger.LogDebug("Attempt to get UserProfiles...");

            var result = await _userService.GetAllAsync(ct);

            _logger.LogDebug("Getting UserProfiles success.");

            return Ok(result);
        }
    }
}
