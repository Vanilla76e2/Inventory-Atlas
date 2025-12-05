using AutoMapper;
using Inventory_Atlas.Application.Services.PasswordHasher;
using Inventory_Atlas.Application.Validators;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Microsoft.Extensions.Logging;
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
        private readonly IPasswordHasher _hasher;

        public UserProfileService(IUnitOfWork uow, IMapper mapper, IUserProfileRepository repo, ILogger<UserProfileService> logger, IPasswordHasher hasher) 
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
            _userRepo = repo;
            _hasher = hasher;
        }

        /// <inheritdoc/>
        public async Task<Response<UserProfileDto>> CreateUserProfile(UserProfileCreateDto newUser, CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to create user: {Username} . . .", newUser.Username);

                var validationResult = UserProfileValidator.ValidateCreate(newUser);
                if(!validationResult.IsValid)
                {
                    _logger.LogDebug("Cannot create user: {Reason}", validationResult.Error);
                    return Response<UserProfileDto>.Fail(validationResult.Error);
                }

                var existing = await _userRepo.GetByUsernameAsync(newUser.Username, ct);
                if (existing != null)
                {
                    _logger.LogDebug("Cannot create user: Username {Username} already exists.", newUser.Username);
                    return Response<UserProfileDto>.Fail(ErrorCodes.UsernameAlreadtExists);
                }

                var userProfile = UserProfileFactory.Create(newUser, _hasher);

                await _uow.SaveChangesAsync();

                _logger.LogDebug("User created successfully.");

                var userProfileDto = _mapper.Map<UserProfileDto>(userProfile);

                return Response<UserProfileDto>.Ok(userProfileDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Creating user {Username} failed.", newUser.Username);
                return Response<UserProfileDto>.Fail(ErrorCodes.UnexpectedError);
            }
        }

        public async Task<Response<UserProfileDto>> UpdateUserProfile(UserProfileUpdateDto newUserDto, CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to update user with id {UserId} . . .", newUserDto.Id);

                var validationResult = UserProfileValidator.ValidateUpdate(newUserDto);
                if (!validationResult.IsValid)
                {
                    _logger.LogDebug("Cannot update user: {Reason}", validationResult.Error);
                    return Response<UserProfileDto>.Fail(validationResult.Error);
                }

                var user = await _userRepo.GetByIdAsync(newUserDto.Id, ct);
                if (user == null)
                {
                    _logger.LogError("User with id {UserId} does not exist.", newUserDto.Id);
                    return Response<UserProfileDto>.Fail(ErrorCodes.UserNotExist);
                }

                UserProfileFactory.Update(user, newUserDto, _hasher);

                _userRepo.Update(user);

                await _uow.SaveChangesAsync(ct);

                _logger.LogDebug("User with id {UserId} updated successfuly.", newUserDto.Id);

                return Response<UserProfileDto>.Ok(_mapper.Map<UserProfileDto>(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Updating user with id {UserId} failed.", newUserDto.Id);
                return Response<UserProfileDto>.Fail(ErrorCodes.UnexpectedError);
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
