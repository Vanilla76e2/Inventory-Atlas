using Inventory_Atlas.Application.Services.PermissionService;
using Inventory_Atlas.Server.Attributes;
using Inventory_Atlas.Core.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Atlas.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IPermissionService permissionService, ILogger<UsersController> logger)
        {
            _permissionService = permissionService;
            _logger = logger;
        }

        

    }
}
