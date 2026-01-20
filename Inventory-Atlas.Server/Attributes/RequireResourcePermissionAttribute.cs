using Inventory_Atlas.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Inventory_Atlas.Application.Services.PermissionService;

namespace Inventory_Atlas.Server.Attributes
{
    /// <summary>
    /// Атрибут для проверки прав пользователя на конкретный ресурс перед выполнением метода контроллера.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class RequireResourcePermissionAttribute : Attribute, IAsyncActionFilter
    {
        private readonly ResourceType _resourceType;
        private readonly string? _responsible;
        private readonly DictionariesEnum? _dictionary;
        private readonly RolePermissionEnum _requiredLevel;

        /// <summary>
        /// Создает атрибут проверки прав на ресурс.
        /// </summary>
        /// <param name="resourceType">Тип ресурса (InventoryItems, Documents и т.д.)</param>
        /// <param name="responsibleUserId">Id пользователя, ответственного за ресурс.</param>
        /// <param name="requiredLevel">Минимальный уровень прав (по умолчанию Read).</param>
        public RequireResourcePermissionAttribute(ResourceType resourceType, string? responsibleIdParameterName, DictionariesEnum? dictionary, RolePermissionEnum requiredLevel)
        {
            _resourceType = resourceType;
            _responsible = responsibleIdParameterName;
            _dictionary = dictionary;
            _requiredLevel = requiredLevel;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var permService = context.HttpContext.RequestServices.GetService<IPermissionService>();
            var logger = context.HttpContext.RequestServices.GetService<ILogger<RequireResourcePermissionAttribute>>();
            bool allowed = false;

            logger?.LogDebug("Checking permissions for resource type {ResourceType} with required level {RequiredLevel}.",
                _resourceType, _requiredLevel);

            if (_responsible != null)
            {
                if (!context.ActionArguments.TryGetValue(_responsible, out var arg))
                {
                    context.Result = new BadRequestObjectResult($"Missing action argument: {_responsible}");
                    logger?.LogWarning("Missing action argument: {Responsible}", _responsible);
                    return;
                }
                
                if (arg is not int resposnibleId)
                {
                    context.Result = new BadRequestObjectResult($"Invalid type for action argument: {_responsible}. Expected int.");
                    logger?.LogWarning("Invalid type for action argument: {Responsible}. Expected int.", _responsible);
                    return;
                }

                allowed = permService!.HasPermission(context.HttpContext, _resourceType, resposnibleId, _requiredLevel);
            }
            else if (_dictionary != null)
            {
                allowed = permService!.HasPermission(context.HttpContext, _resourceType, _dictionary.Value, _requiredLevel);
            }
            else
            {
                allowed = permService!.HasPermission(context.HttpContext, _resourceType, _requiredLevel);
            }

            if (!allowed)
            {
                context.Result = new ForbidResult();
                logger?.LogDebug("Permission denied for resource type {ResourceType} with required level {RequiredLevel}.",
                    _resourceType, _requiredLevel);
                return;
            }

            logger?.LogDebug("Permission granted for resource type {ResourceType} with required level {RequiredLevel}.",
                _resourceType, _requiredLevel);
            await next();
        }
    }
}
