
using Inventory_Atlas.Infrastructure.Entities;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;

namespace Inventory_Atlas.Infrastructure.Repository.UsersProfiles
{
    public interface IUsersProfilesRepository : IDatabaseRepository<UserProfile>
    {
        Task<UserProfile?> GetByUsernameAsync(string username);

        // Сюда добавлять методы, специфичные для UsersProfile
    }
}
