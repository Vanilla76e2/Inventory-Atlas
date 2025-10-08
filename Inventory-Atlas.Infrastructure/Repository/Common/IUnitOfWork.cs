using Inventory_Atlas.Infrastructure.Entities.Technics;
using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Infrastructure.Repository.Common
{
    public interface IUnitOfWork
    {
        IDatabaseRepository<UserProfile> UsersProfiles { get; }
        IDatabaseRepository<Computer> Computers { get; }
    }
}
