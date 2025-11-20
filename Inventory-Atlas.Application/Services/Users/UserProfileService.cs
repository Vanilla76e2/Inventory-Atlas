using AutoMapper;
using Inventory_Atlas.Application.Services.Common;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Services.Users
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _repo;
        private readonly ILogger<UserProfileService> _logger;

        public UserProfileService(IUnitOfWork uow, IMapper mapper, IUserProfileRepository repo, ILogger<UserProfileService> logger) 
        {
            _uow = uow;
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }

        public async Task<UserProfile?> GetByUsernameAsync(string username)
        {
            var user = await _repo.GetByUsernameAsync(username);
            return user;
        }

        public Task<IEnumerable<UserProfile>> GetActiveUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
