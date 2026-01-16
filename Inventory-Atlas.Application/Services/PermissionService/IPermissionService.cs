using Inventory_Atlas.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Inventory_Atlas.Infrastructure.Services.PermissionService
{
    /// <summary>
    /// Интерфейс сервиса проверки прав пользователя на доступ к ресурсам системы.
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// Проверяет права пользователя по материальной ответственности.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <param name="resourceType">Тип ресурса.</param>
        /// <param name="responsibleUserId">Идентификатор пользователя, ответственного за объект.</param>
        /// <param name="requiredLevel">Минимальный уровень прав для доступа (по умолчанию Read).</param>
        /// <returns>True, если пользователь имеет нужные права, иначе false.</returns>
        bool HasPermission(HttpContext context, ResourceType resourceType, int responsibleUserId, RolePermissionEnum requiredLevel = RolePermissionEnum.Read);

        /// <summary>
        /// Проверяет права пользователя на словари.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <param name="resourceType">Тип ресурса (должен быть Dictionaries).</param>
        /// <param name="dictionary">Конкретный словарь.</param>
        /// <param name="requiredLevel">Минимальный уровень прав (по умолчанию Read).</param>
        /// <returns>True, если пользователь имеет нужные права, иначе false.</returns>
        bool HasPermission(HttpContext context, ResourceType resourceType, DictionariesEnum dictionary, RolePermissionEnum requiredLevel = RolePermissionEnum.Read);

        /// <summary>
        /// Проверяет права пользователя на глобальные ресурсы.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <param name="resourceType">Тип ресурса.</param>
        /// <param name="requiredLevel">Минимальный уровень прав (по умолчанию Read).</param>
        /// <returns>True, если пользователь имеет нужные права, иначе false.</returns>
        bool HasPermission(HttpContext context, ResourceType resourceType, RolePermissionEnum requiredLevel = RolePermissionEnum.Read);

        /// <summary>
        /// Проверяет, является ли текущий пользователь администратором.
        /// </summary>
        /// <param name="context">HTTP-контекст текущего запроса.</param>
        /// <returns>True, если пользователь администратор, иначе false.</returns>
        bool HasAdminPermission(HttpContext context);
    }
}
