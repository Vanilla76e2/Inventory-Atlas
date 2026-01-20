using AutoMapper;
using Inventory_Atlas.Infrastructure.Services.PasswordHasher;
using Inventory_Atlas.Infrastructure.Validators;
using Inventory_Atlas.Core.DTOs.Users;
using Microsoft.Extensions.Logging;
using Inventory_Atlas.Core.Models;
using Inventory_Atlas.Core;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Inventory_Atlas.Infrastructure.Repository.Common;
using Inventory_Atlas.Infrastructure.Repository.Users;
using Inventory_Atlas.Infrastructure.Auditor;
using Inventory_Atlas.Application.Services.DatabaseServices.Audit;

namespace Inventory_Atlas.Application.Services.DatabaseServices.Users
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUserProfileRepository _userRepo;
        private readonly IPasswordHasher _hasher;
        private readonly IUserSessionService _sessionService;

        public UserProfileService(
            IUnitOfWork uow, 
            IMapper mapper, 
            IUserProfileRepository repo, 
            ILogger<UserProfileService> logger, 
            IPasswordHasher hasher,
            IUserSessionService sessionService) 
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
            _userRepo = repo;
            _hasher = hasher;
            _sessionService = sessionService;
        }

        /// <inheritdoc/>
        public async Task<Response<UserProfileDto>> CreateAsync(
            UserProfileCreateDto newUser, 
            ClientInfo clientInfo, 
            CancellationToken ct = default)
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

                var userId = await _sessionService.GetIdByTokenAsync(clientInfo.SessionToken!);
                if (userId == null)
                    return Response<UserProfileDto>.Fail(ErrorCodes.InvalidSession);

                var userProfile = UserProfileFactory.Create(newUser, _hasher);

                await _uow.SaveChangesAsync(ct, new AuditContext
                {
                    ActionType = Core.Enums.ActionType.Create,
                    SessionToken = clientInfo.SessionToken,
                    UserId = userId,
                    UserAgent = clientInfo.UserAgent,
                    IpAddress = clientInfo.IpAddress,
                    TargetType = typeof(UserProfile).ToString(),
                    TargetId = userProfile.Id.ToString()
                });

                _logger.LogDebug("User {Username} created successfully.", userProfile.Username);

                var userProfileDto = _mapper.Map<UserProfileDto>(userProfile);

                return Response<UserProfileDto>.Ok(userProfileDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Creating user {Username} failed.", newUser.Username);
                return Response<UserProfileDto>.Fail(ErrorCodes.UnexpectedError);
            }
        }

        /// <inheritdoc/>
        public async Task<Response<UserProfileDto>> UpdateAsync(
            UserProfileUpdateDto newUserDto, 
            ClientInfo clientInfo, 
            CancellationToken ct = default)
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

                var userId = await _sessionService.GetIdByTokenAsync(clientInfo.SessionToken!);
                if (userId == null)
                {
                    _logger.LogWarning("Invalid Session");
                    return Response<UserProfileDto>.Fail(ErrorCodes.InvalidSession);
                }

                _userRepo.Update(UserProfileFactory.Update(user, newUserDto, _hasher));

                await _uow.SaveChangesAsync(ct, new AuditContext
                {
                    ActionType = Core.Enums.ActionType.Update,
                    SessionToken = clientInfo.SessionToken,
                    UserId = userId,
                    TargetType = typeof(UserProfile).ToString(),
                    TargetId = newUserDto.Id.ToString()
                });

                _logger.LogDebug("User with id {UserId} updated successfuly.", newUserDto.Id);

                return Response<UserProfileDto>.Ok(_mapper.Map<UserProfileDto>(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Updating user with id {UserId} failed.", newUserDto.Id);
                return Response<UserProfileDto>.Fail(ErrorCodes.UnexpectedError);
            }
        }

        /// <inheritdoc/>
        public async Task<UserProfileDto?> GetByUsernameAsync(string username, CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to get user by username: {Username}", username);
                var result = await _userRepo.GetByUsernameAsync(username, ct);
                
                if (result != null)
                    _logger.LogDebug("User found: {Username} (ID: {Id})", result.Username, result.Id);
                else
                    _logger.LogDebug("User {Username} not found", username);

                return _mapper.Map<UserProfileDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting user by username failed.");
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<List<UserProfileDto>> GetActiveAsync(CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to get all active users...");
                var result = await _userRepo.GetActiveUsersAsync(ct);

                if (result.Count > 0)
                    _logger.LogDebug("Active users found: {Count}", result.Count);
                else
                    _logger.LogWarning("No active users found.");

                return _mapper.Map<List<UserProfileDto>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting active users failed.");
                return new List<UserProfileDto>();
            }
        }

        /// <inheritdoc/>
        public async Task<List<UserProfileDto>> GetAllAsync(CancellationToken ct = default)
        {
            try
            {
                _logger.LogDebug("Try to get all users...");

                var result = await _userRepo.GetAllAsync(ct);

                if (result.Count > 0)
                    _logger.LogDebug($"Users found: {result.Count}");
                else
                    _logger.LogWarning($"No users found.");

                return _mapper.Map<List<UserProfileDto>>(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Getting users failed.");
                return new List<UserProfileDto>();
            }
        }
    }
}
