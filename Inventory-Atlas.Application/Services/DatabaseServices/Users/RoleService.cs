using AutoMapper;
using Inventory_Atlas.Core;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Microsoft.Extensions.Logging;

namespace Inventory_Atlas.Application.Services.DatabaseServices.Users
{
    public class RoleService : IRoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly IUnitOfWork _uow;
        private readonly IRoleRepository _repo;
        private readonly IMapper _mapper;

        public RoleService(ILogger<RoleService> logger, IUnitOfWork uow, IRoleRepository repo, IMapper mapper)
        {
            _logger = logger;
            _uow = uow;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Response<RoleDto>> CreateRoleAsync(RoleCreateDto roleCreateDto, CancellationToken ct)
        {
            _logger.LogDebug("Creating a new role with Name {Name}.", roleCreateDto.Name);

            if(string.IsNullOrWhiteSpace(roleCreateDto.Name))
            {
                _logger.LogWarning("Role creation failed: Name is null or empty.");
                return Response<RoleDto>.Fail(ErrorCodes.InvalidRoleName);
            }

            if(roleCreateDto.Permission == null)
            {
                _logger.LogWarning("Role creation failed: Permissions are null.");
                return Response<RoleDto>.Fail(ErrorCodes.RolePermissionsInvalid);
            }

            var existingRole = await _repo.GetByNameAsync(roleCreateDto.Name, ct);
            if (existingRole != null)
            {
                _logger.LogWarning("Role creation failed: A role with Name {Name} already exists.", roleCreateDto.Name);
                return Response<RoleDto>.Fail(ErrorCodes.RoleNameAlreadyExists);
            }

            var newRole = _mapper.Map<Role>(roleCreateDto);
            _repo.Add(newRole);

            try
            {
                await _uow.SaveChangesAsync(ct);
                _logger.LogDebug("Successfully created role with ID {Id}.", newRole.Id);
                var roleDto = _mapper.Map<RoleDto>(newRole);
                return Response<RoleDto>.Ok(roleDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Role creation failed due to an unexpected error.");
                return Response<RoleDto>.Fail(ErrorCodes.UnexpectedError);
            }
        }

        public Task<Response<bool>> DeleteRoleAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task<List<RoleDto>> GetAllAsync(CancellationToken ct)
        {
            _logger.LogDebug("Fetching all roles from the database.");

            var result = await _repo.GetAllAsync(ct);

            _logger.LogDebug("Successfully fetched {Count} roles.", result.Count);

            return _mapper.Map<List<RoleDto>>(result);
        }

        /// <inheritdoc/>
        public async Task<RoleDto> GetByIdAsync(int id, CancellationToken ct)
        {
            _logger.LogDebug("Fetching role with ID {Id} from the database.", id);

            var result = await _repo.GetByIdAsync(id, ct);

            if (result == null)
            {
                _logger.LogDebug("No roles with ID {id} was fetched.", id);
                return new();
            }

            _logger.LogDebug("Successfully fetched role with ID {Id}.", id);
            return _mapper.Map<RoleDto>(result);
        }

        /// <inheritdoc/>
        public async Task<RoleWithPermissionsDto> GetByIdWithPermissionsAsync(int id, CancellationToken ct)
        {
            _logger.LogDebug("Fetching role with ID {Id} and its permissions from the database.", id);

            var result = await _repo.GetByIdAsync(id, ct);

            if (result == null)
            {
                _logger.LogWarning("No roles with ID {id} was fetched.", id);
                return new();
            }

            _logger.LogDebug("Successfully fetched role with ID {Id} and its permissions.", id);
            return _mapper.Map<RoleWithPermissionsDto>(result);
        }

        /// <inheritdoc/>
        public Task<RoleDto> GetByNameAsync(string name, CancellationToken ct)
        {
            _logger.LogDebug("Fetching role with Name {Name} from the database.", name);

            var result = _repo.GetByNameAsync(name, ct);
            
            if (result != null)
                _logger.LogDebug("Successfully fetched role with Name {Name}.", name);
            else 
                _logger.LogDebug("No roles with Name {name} was fetched.", name);

            return _mapper.Map<Task<RoleDto>>(result);
        }

        public async Task<RolePermissions> GetRolePermissionsAsync(int id, CancellationToken ct)
        {
            _logger.LogDebug("Fetching permissions for role with ID {Id}.", id);

            var role = await _repo.GetByIdAsync(id, ct);

            if (role == null)
            {
                _logger.LogWarning("No role with ID {Id} exists. Cannot fetch permissions.", id);
                return new();
            }

            _logger.LogDebug("Successfully fetched permissions for role with ID {Id}.", id);
            return role.Permissions;
        }

        public async Task<Response<RoleDto>> UpdateRoleAsync(RoleUpdateDto roleUpdateDto, CancellationToken ct)
        {
            _logger.LogDebug("Updating role with Name {Name}.", roleUpdateDto.Name);

            var role = await _repo.GetByIdAsync(roleUpdateDto.Id, ct);
            if (role == null)
            {
                _logger.LogError("Role update failed: No role with ID {Id} exists.", roleUpdateDto.Id);
                return Response<RoleDto>.Fail(ErrorCodes.RoleNotExist);
            }

            if (roleUpdateDto.Name != null)
            {
                if (await _repo.ExistsByNameAsync(roleUpdateDto.Name, roleUpdateDto.Id, ct))
                {
                    _logger.LogWarning("Role update failed: A role with Name {Name} already exists.", roleUpdateDto.Name);
                    return Response<RoleDto>.Fail(ErrorCodes.RoleNameAlreadyExists);
                }
            }

            if (roleUpdateDto.Name != null)
                role.Name = roleUpdateDto.Name;
            if (roleUpdateDto.Description != null)
                role.Description = roleUpdateDto.Description;
            if (roleUpdateDto.Permissions != null)
                role.Permissions = roleUpdateDto.Permissions;

            try
            {
                await _uow.SaveChangesAsync(ct);
                _logger.LogDebug("Successfully updated role with ID {Id}.", role.Id);
                var roleDto = _mapper.Map<RoleDto>(role);
                return Response<RoleDto>.Ok(roleDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Role update failed due to an unexpected error.");
                return Response<RoleDto>.Fail(ErrorCodes.UnexpectedError);
            }
        }
    }
}
