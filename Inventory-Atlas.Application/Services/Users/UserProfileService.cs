using AutoMapper;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Application.Services.Audit;
using Inventory_Atlas.Application.Validators;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Microsoft.Extensions.Logging;
using Inventory_Atlas.Core.Enums;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Core;

namespace Inventory_Atlas.Application.Services.Users
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUserProfileRepository _userRepo;
        private readonly ILogEntryService<UserProfile> _dbLogger;
        private readonly IPasswordHasher _hasher;

        public UserProfileService(IUnitOfWork uow, IMapper mapper, IUserProfileRepository repo, ILogger<UserProfileService> logger, ILogEntryService<UserProfile> dbLogger, IPasswordHasher hasher) 
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
            _userRepo = repo;
            _dbLogger = dbLogger;
            _hasher = hasher;
        }

        /// <inheritdoc/>
        public async Task<Response<UserProfile>> CreateUserProfile(UserProfileCreateDto newUser, CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to create user: {Username} . . .", newUser.Username);

                var validationResult = UserProfileValidator.ValidateCreate(newUser);

                if(!validationResult.IsValid)
                {
                    _logger.LogDebug("Cannot create user: {Reason}", validationResult.Error);
                    return Response<UserProfile>.Fail(validationResult.Error);
                }

                var existing = await _userRepo.GetByUsernameAsync(newUser.Username, ct);
                if (existing != null)
                {
                    _logger.LogDebug("Cannot create user: Username {Username} already exists.", newUser.Username);
                    return Response<UserProfile>.Fail(ErrorCodes.UsernameAlreadtExists);
                }

                UserProfile userProfile = new UserProfile()
                {
                    Username = newUser.Username,
                    PasswordHash = _hasher.Hash(newUser.Password),
                    IsActive = true,
                    RoleId = newUser.RoleId,
                    EmployeeId = newUser.EmployeeId
                };

                await _dbLogger.SaveEntityWithLogAsync(userProfile, ActionType.Create, null, ct);

                _logger.LogDebug("User created successfully.");

                return Response<UserProfile>.Ok(userProfile);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Creating user {Username} failed.", newUser.Username);
                return Response<UserProfile>.Fail(ErrorCodes.UnexpectedError);
            }
        }

        public async Task<Response<UserProfile>> UpdateUserProfile(UserProfileUpdateDto newUser, CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to update user {Username} . . .", newUser.Username);

                var validationResult = UserProfileValidator.ValidateUpdate(newUser);
                if (!validationResult.IsValid)
                {
                    _logger.LogDebug("Cannot update user: {Reason}", validationResult.Error);
                    return Response<UserProfile>.Fail(validationResult.Error);
                }

                var oldUser = await _userRepo.GetByIdAsync(newUser.Id, ct);
                if (oldUser == null)
                {
                    _logger.LogError("User {Username} does not exists.", newUser.Username);
                    return Response<UserProfile>.Fail(ErrorCodes.UserNotExist);
                }

                if(!string.IsNullOrWhiteSpace(newUser.Username)) oldUser.Username = newUser.Username;
                if(!string.IsNullOrWhiteSpace(newUser.Password)) oldUser.PasswordHash = _hasher.Hash(newUser.Password);
                if (newUser.RoleId != null) oldUser.RoleId = (int)newUser.RoleId;
                if(newUser.IsActive != null) oldUser.IsActive = (bool)newUser.IsActive;
                if(newUser.EmployeeId != null) oldUser.EmployeeId = newUser.EmployeeId;
                if (newUser.EmployeeId == 0) oldUser.EmployeeId = null;

                _userRepo.Update(oldUser);



                _dbLogger.Log()
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to get user by username: {Username}", username);
                var result = await _userRepo.GetByUsernameAsync(username, ct);
                
                if (result != null)
                    _logger.LogDebug("User found: {Username} (ID: {Id})", result.Username, result.Id);
                else
                    _logger.LogDebug("User {Username} not found", username);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting user by username failed.");
                return null;
            }
        }

        public async Task<List<UserProfile>> GetActiveUsersAsync(CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to get all active users.");
                var result = await _userRepo.GetActiveUsersAsync(ct);

                if (result.Count > 0)
                    _logger.LogDebug("Active users found: {Count}", result.Count);
                else
                    _logger.LogDebug("No active users found.");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting active users failed.");
                return new List<UserProfile>();
            }
        }
    }
}
