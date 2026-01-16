using Inventory_Atlas.Infrastructure.Services.PermissionService;
using Inventory_Atlas.Server.Attributes;
using Inventory_Atlas.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Application.Services.DatabaseServices.Users;
using Microsoft.AspNetCore.Authorization;
using Inventory_Atlas.Application.Services.DatabaseServices.Audit;

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

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser([FromBody] UserProfileCreateDto request, CancellationToken ct)
        {
            _logger.LogDebug($"Attempt to create new UserProfile with username {request.Username}...");

            var client = HttpContext.GetClientInfo();

            if (string.IsNullOrWhiteSpace(client.SessionToken))
            {
                _logger.LogWarning("Request rejected: missing or empty SessionToken for creating user {Username}", request.Username);
                return BadRequest("SessionToken not found.");
            }

            var userId = await _sessionService.GetUserIdByTokenAsync(client.SessionToken, ct);
            if (userId == null)
                return Unauthorized("Invalid session token.");


            var result = await _userService.CreateUserProfileAsync(request, client.SessionToken, ct);

            if (result.IsSuccess)
            {
                _logger.LogDebug($"UserProfile with username {request.Username} was created.");
                return Ok(result);
            }    
            else
            {
                _logger.LogDebug($"UserProfile with username {request.Username} was denied.");
                return BadRequest(result);
            }
        }


    }
}
