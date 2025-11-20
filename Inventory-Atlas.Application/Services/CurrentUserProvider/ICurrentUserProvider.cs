using Inventory_Atlas.Infrastructure.Entities.Users;

namespace Inventory_Atlas.Application.Services.CurrentUserProvider
{
    public interface ICurrentUserProvider
    {
        Guid? UserId { get; }
        string? UserName { get; }
        Role? Role { get; }
        bool IsAuthenticated { get; }
    }
}
