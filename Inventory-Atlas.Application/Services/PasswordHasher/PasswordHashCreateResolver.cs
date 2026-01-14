using AutoMapper;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Application.Entities.Users;

namespace Inventory_Atlas.Application.Services.PasswordHasher
{
    public class PasswordHashCreateResolver : IMemberValueResolver<UserProfileCreateDto, UserProfile, string, string>
    {
        private readonly IPasswordHasher _hasher;

        public PasswordHashCreateResolver(IPasswordHasher hasher)
        {
            _hasher = hasher;
        }

        public string Resolve(UserProfileCreateDto src, UserProfile dest, string srcPassword, string destPassword, ResolutionContext context)
        {
            return _hasher.Hash(srcPassword);
        }
    }
}
