using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Core.Models;

namespace Inventory_Atlas.Application.Services.DatabaseServices.Users
{
    public interface IRoleService
    {
        /// <summary>
        /// Асинхронно получает все роли.
        /// </summary>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>Список DTO ролей.</returns>
        Task<List<RoleDto>> GetAllAsync(CancellationToken ct);

        /// <summary>
        /// Асинхронно получает роль по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор роли.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>DTO роли.</returns>
        Task<RoleDto> GetByIdAsync(int id, CancellationToken ct);

        /// <summary>
        /// Асинхронно получает роль по её имени.
        /// </summary>
        /// <param name="name">Имя роли.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>DTO роли.</returns>
        Task<RoleDto> GetByNameAsync(string name, CancellationToken ct);

        /// <summary>
        /// Асинхронно создает новую роль.
        /// </summary>
        /// <param name="roleCreateDto">DTO для создания роли.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>DTO созданной роли.</returns>
        Task<Response<RoleDto>> CreateRoleAsync(RoleCreateDto roleCreateDto, CancellationToken ct);

        /// <summary>
        /// Асинхронно обновляет существующую роль.
        /// </summary>
        /// <param name="roleCreateDto">DTO с новыми данными для роли.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>Новый DTO роли.</returns>
        Task<Response<RoleDto>> UpdateRoleAsync(RoleUpdateDto roleUpdateDto, CancellationToken ct);

        /// <summary>
        /// Асинхронно удаляет роль по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор роли.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns><see langword="true"/> если удаление успешно, иначе <see langword="false"/>.</returns>
        Task<Response<bool>> DeleteRoleAsync(int id, CancellationToken ct);

        /// <summary>
        /// Асинхронно получает разрешения роли по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор роли.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>Объект представляющий разрешения роли.</returns>
        Task<RolePermissions> GetRolePermissionsAsync(int id, CancellationToken ct);

        /// <summary>
        /// Асинхронно получает роль вместе с её разрешениями по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор роли.</param>
        /// <param name="ct">Токен отмены.</param>
        /// <returns>DTO роли с правами.</returns>
        Task<RoleWithPermissionsDto> GetByIdWithPermissionsAsync(int id, CancellationToken ct);
    }
}
