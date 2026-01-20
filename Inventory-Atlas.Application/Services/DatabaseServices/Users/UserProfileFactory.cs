using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Application.Services.PasswordHasher;

namespace Inventory_Atlas.Application.Services.DatabaseServices.Users
{
    internal static class UserProfileFactory
    {
        internal static UserProfile Create(UserProfileCreateDto dto, IPasswordHasher hasher)
        {
            return new UserProfile
            {
                Username = dto.Username,
                PasswordHash = hasher.Hash(dto.Password),
                IsActive = true,
                RoleId = dto.RoleId,
                EmployeeId = dto.EmployeeId == 0 ? null : dto.EmployeeId
            };
        }

        internal static UserProfile Update(UserProfile entity, UserProfileUpdateDto dto, IPasswordHasher hasher)
        {
            if (!string.IsNullOrWhiteSpace(dto.Username))
                entity.Username = dto.Username;

            if (dto.EmployeeId.HasValue)
                entity.EmployeeId = dto.EmployeeId == 0 ? null : dto.EmployeeId.Value;

            if (dto.RoleId.HasValue)
                entity.RoleId = dto.RoleId.Value;

            if (dto.IsActive.HasValue)
                entity.IsActive = dto.IsActive.Value;

            if (!string.IsNullOrWhiteSpace(dto.Password))
                entity.PasswordHash = hasher.Hash(dto.Password);

            entity.UpdatedAt = DateTime.UtcNow;

            return entity;
        }
    }
}
