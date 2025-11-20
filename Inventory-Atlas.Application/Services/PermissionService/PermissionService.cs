using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Inventory_Atlas.Application.Services.PermissionService
{
    /// <summary>
    /// Сервис проверки прав пользователя на доступ к ресурсам системы.
    /// </summary>
    public class PermissionService : IPermissionService
    {
        ILogger _logger;

        /// <summary>
        /// Создает новый экземпляр <see cref="PermissionService"/>.
        /// </summary>
        /// <param name="logger">Сервис логирования.</param>
        public PermissionService(ILogger<PermissionService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Проверяет права пользователя по материальной ответственности.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <param name="resourceType">Тип ресурса.</param>
        /// <param name="responsibleUserId">Идентификатор пользователя, ответственного за объект.</param>
        /// <param name="requiredLevel">Минимальный уровень прав для доступа (по умолчанию Read).</param>
        /// <returns>True, если пользователь имеет нужные права, иначе false.</returns>
        public bool HasPermission(HttpContext context, ResourceType resourceType, int responsibleUserId, RolePermissionEnum requiredLevel = RolePermissionEnum.Read)
        {
            _logger.LogDebug("Checking permissions for resource type {ResourceType} with required level {RequiredLevel} for responsible user ID {ResponsibleUserId}.",
                resourceType, requiredLevel, responsibleUserId);

            if (IsAdmin(context, out var rolePermission))
                return true;

            // Проверка прав в зависимости от типа ресурса
            return resourceType switch
            {
                ResourceType.InventoryItems => rolePermission.InventoryItemsPermissions
                    .Any(p => p.Level >= requiredLevel && p.ResponsibleIds.Contains(responsibleUserId)),

                ResourceType.Documents => rolePermission.DocumentsPermissions
                    .Any(p => p.Level >= requiredLevel && p.ResponsibleIds.Contains(responsibleUserId)),

                _ => false
            };
        }

        /// <summary>
        /// Проверяет права пользователя на словари.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <param name="resourceType">Тип ресурса (должен быть Dictionaries).</param>
        /// <param name="dictionary">Конкретный словарь.</param>
        /// <param name="requiredLevel">Минимальный уровень прав (по умолчанию Read).</param>
        /// <returns>True, если пользователь имеет нужные права, иначе false.</returns>
        public bool HasPermission(HttpContext context, ResourceType resourceType, DictionariesEnum dictionary, RolePermissionEnum requiredLevel = RolePermissionEnum.Read)
        {
            _logger.LogDebug("Checking dictionary permissions for resource type {ResourceType} with required level {RequiredLevel} for dictionary {Dictionary}.",
                resourceType, requiredLevel, dictionary);

            if (IsAdmin(context, out var rolePermission))
                return true;

            return resourceType switch
            {
                ResourceType.Dictionaries => rolePermission.DictionaryPermissions.TryGetValue(dictionary, out var level) && level >= requiredLevel,

                _ => false
            };
        }

        /// <summary>
        /// Проверяет права пользователя на глобальные ресурсы.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <param name="resourceType">Тип ресурса.</param>
        /// <param name="requiredLevel">Минимальный уровень прав (по умолчанию Read).</param>
        /// <returns>True, если пользователь имеет нужные права, иначе false.</returns>
        public bool HasPermission(HttpContext context, ResourceType resourceType, RolePermissionEnum requiredLevel = RolePermissionEnum.Read)
        {
            _logger.LogDebug("Checking global permissions for resource type {ResourceType} with required level {RequiredLevel}.",
                resourceType, requiredLevel);

            if (IsAdmin(context, out var rolePermission))
                return true;

            return resourceType switch
            {
                ResourceType.Workplaces => rolePermission.Workplaces >= requiredLevel,

                _ => false
            };
        }

        /// <summary>
        /// Проверяет, является ли текущий пользователь администратором.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <returns>True, если пользователь администратор, иначе false.</returns>
        public bool HasAdminPermission(HttpContext context)
        {
            _logger.LogDebug("Checking if user has admin permissions.");

            return IsAdmin(context, out _);
        }

        /// <summary>
        /// Получает объект <see cref="RolePermission"/> из контекста запроса.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <returns>Объект прав роли пользователя.</returns>
        private RolePermission GetPermissions(HttpContext context)
        {
            _logger.LogDebug("Retrieving RolePermission from HttpContext.Items.");

            var prmsJson = context.Items["Permissions"] as string;
            if (string.IsNullOrEmpty(prmsJson))
            {
                _logger.LogWarning("Permissions not found in HttpContext.Items or is empty.");
                return new RolePermission();
            }

            _logger.LogDebug("Deserializing Permissions JSON: {PermissionsJson}", prmsJson);

            var rolePermission = JsonSerializer.Deserialize<RolePermission>(prmsJson);
            if (rolePermission == null)
            {
                _logger.LogWarning("Failed to deserialize Permissions JSON to RolePermission object.");
                return new RolePermission();
            }    

            _logger.LogDebug("Successfully retrieved RolePermission.");

            return rolePermission;
        }

        /// <summary>
        /// Проверяет, является ли текущий пользователь администратором.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <param name="rolePermission">Выходной параметр с правами пользователя.</param>
        /// <returns>True, если пользователь администратор, иначе false.</returns>
        private bool IsAdmin(HttpContext context, out RolePermission rolePermission)
        {
            rolePermission = GetPermissions(context);
            return rolePermission.IsAdmin;
        }
    }
}
