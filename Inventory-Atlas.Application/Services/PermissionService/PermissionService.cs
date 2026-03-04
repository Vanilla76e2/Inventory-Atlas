using Inventory_Atlas.Application.Services.DatabaseServices.Users;
using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;

namespace Inventory_Atlas.Application.Services.PermissionService
{
    /// <summary>
    /// Сервис проверки прав пользователя на доступ к ресурсам системы.
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;
        private readonly IRoleService _roleService;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);


        /// <summary>
        /// Создает новый экземпляр <see cref="PermissionService"/>.
        /// </summary>
        /// <param name="logger">Сервис логирования.</param>
        public PermissionService(ILogger<PermissionService> logger,
            IMemoryCache cache,
            IRoleService roleService,
            CancellationToken ct = default)
        {
            _logger = logger;
            _cache = cache;
            _roleService = roleService;
        }

        /// <inheritdoc/>
        public async Task<bool> HasPermission(int roleId,
            ResourceType resourceType,
            int responsibleUserId,
            RolePermissionEnum requiredLevel = RolePermissionEnum.Read,
            CancellationToken ct = default)
        {
            _logger.LogDebug("Checking permissions for resource type {ResourceType} with required level {RequiredLevel} for responsible user ID {ResponsibleUserId}.",
                resourceType, requiredLevel, responsibleUserId);

            var permissions = await GetRolePermissionsAsync(roleId, ct);

            if (permissions == null)
            {
                _logger.LogWarning("Role with ID {RoleId} not found when checking permissions.", roleId);
                return false;
            }

            if (permissions.IsAdmin)
                return true;

            return resourceType switch
            {
                ResourceType.InventoryItems => permissions.InventoryItemsPermissions
                    .Any(p => p.Level >= requiredLevel && p.ResponsibleIds.Contains(responsibleUserId)),

                ResourceType.Documents => permissions.DocumentsPermissions
                    .Any(p => p.Level >= requiredLevel && p.ResponsibleIds.Contains(responsibleUserId)),

                _ => false
            };
        }

        /// <inheritdoc/>
        public async Task<bool> HasPermission(int roleId, 
            ResourceType resourceType, 
            DictionariesEnum dictionary, 
            RolePermissionEnum requiredLevel = RolePermissionEnum.Read, 
            CancellationToken ct = default)
        {
            _logger.LogDebug("Checking dictionary permissions for resource type {ResourceType} with required level {RequiredLevel} for dictionary {Dictionary}.",
                resourceType, requiredLevel, dictionary);

            var permissions = await GetRolePermissionsAsync(roleId, ct);

            if (permissions.IsAdmin)
                return true;

            return resourceType switch
            {
                ResourceType.Dictionaries => permissions.DictionaryPermissions.TryGetValue(dictionary, out var level) && level >= requiredLevel,

                _ => false
            };
        }

        /// <inheritdoc/>
        public async Task<bool> HasPermission(int roleId, 
            ResourceType resourceType, 
            RolePermissionEnum requiredLevel = RolePermissionEnum.Read, 
            CancellationToken ct = default)
        {
            _logger.LogDebug("Checking global permissions for resource type {ResourceType} with required level {RequiredLevel}.",
                resourceType, requiredLevel);

            var permissions = await GetRolePermissionsAsync(roleId, ct);

            if (permissions.IsAdmin)
                return true;

            return resourceType switch
            {
                ResourceType.Workplaces => permissions.Workplaces >= requiredLevel,

                _ => false
            };
        }

        /// <inheritdoc/>
        public async Task<bool> HasAdminPermission(int id, CancellationToken ct = default)
        {
            _logger.LogDebug("Checking admin permissions.");

            var permissions = await GetRolePermissionsAsync(id, ct);
            return permissions.IsAdmin;
        }

        private async Task<RolePermissions> GetRolePermissionsAsync(int roleId, CancellationToken ct = default)
        {
            var result = await _cache.GetOrCreateAsync(roleId, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _cacheDuration;
                var role = await _roleService.GetByIdWithPermissionsAsync(roleId, ct);
                return role.Permission;
            });

            return result ?? new();
        }
    }
}
