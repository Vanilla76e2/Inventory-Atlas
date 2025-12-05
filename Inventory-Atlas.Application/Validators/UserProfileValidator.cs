using Inventory_Atlas.Core;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Core.Models;

namespace Inventory_Atlas.Application.Validators
{
    /// <summary>
    /// Валидатор данных профиля пользователей.
    /// </summary>
    public static class UserProfileValidator
    {
        /// <summary>
        /// Валидация при создании пользователя.
        /// </summary>
        /// <param name="dto">Данные профиля пользователя.</param>
        /// <returns><see cref="ValidationResult"/></returns>
        public static ValidationResult ValidateCreate(UserProfileCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                return new(false, ErrorCodes.InvalidUsername);

            if (string.IsNullOrEmpty(dto.Password))
                return new(false, ErrorCodes.InvalidPassword);

            if (dto.Username.Length < 3)
                return new(false, ErrorCodes.UsernameTooShort);

            if (dto.Password.Length < 8)
                return new(false, ErrorCodes.PasswordTooShort);

            if (dto.EmployeeId.HasValue && dto.EmployeeId <= 0)
                return new(false, ErrorCodes.InvalidEmployeeId);

            if (dto.RoleId <= 0)
                return new(false, ErrorCodes.InvalidRoleId);

            return new(true);
        }

        /// <summary>
        /// Валидация при изменении профиля пользователя.
        /// </summary>
        /// <param name="dto">Новые данные для профиля пользователя.</param>
        /// <returns><see cref="ValidationResult"/>.</returns>
        public static ValidationResult ValidateUpdate(UserProfileUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Username) && dto.Username.Length < 3)
                return new(false, ErrorCodes.UsernameTooShort);

            if (!string.IsNullOrWhiteSpace(dto.Password) && dto.Password.Length < 8)
                return new(false, ErrorCodes.PasswordTooShort);

            if (dto.EmployeeId.HasValue && dto.EmployeeId < 0)
                return new(false, ErrorCodes.InvalidEmployeeId);

            if (dto.RoleId.HasValue && dto.RoleId <= 0)
                return new(false, ErrorCodes.InvalidRoleId);

            return new(true);
        }
    }
}
