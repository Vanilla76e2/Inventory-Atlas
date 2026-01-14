using AutoMapper;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Application.Entities.Users;

namespace Inventory_Atlas.Application.Services.PasswordHasher
{
    public class PasswordHashUpdateResolver : IMemberValueResolver<UserProfileUpdateDto, UserProfile, string?, string>
    {
        private readonly IPasswordHasher _hasher;

        public PasswordHashUpdateResolver(IPasswordHasher hasher)
        {
            _hasher = hasher;
        }

        public string Resolve(UserProfileUpdateDto source, UserProfile destination, string? sourceMember, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source.Password))
                return destMember; 

            return _hasher.Hash(source.Password);
        }
    }
}
