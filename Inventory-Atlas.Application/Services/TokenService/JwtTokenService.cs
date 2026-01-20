using Inventory_Atlas.Application.Services.JwtKeyProvider;
using Inventory_Atlas.Core.DTOs.Users;
using Inventory_Atlas.Infrastructure.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventory_Atlas.Application.Services.TokenService
{
    /// <summary>
    /// Класс для генерации JWT токенов для сессий пользователей.
    /// </summary>
    public class JwtTokenService : ITokenGenerator
    {
        private readonly IJwtKeyProvider _keyProvider;
        private readonly IConfiguration _config;

        /// <summary>
        /// Создаёт экземаляр класса <see cref="JwtTokenService"/>.
        /// </summary>
        public JwtTokenService(IConfiguration config, IJwtKeyProvider keyProvider)
        {
            _keyProvider = keyProvider;
            _config = config;
        }

        /// <inheritdoc/>
        public string GenerateToken(UserProfile user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_keyProvider.GetKey()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            if (user.Role == null)
                throw new InvalidOperationException($"User {user.Username} has no role assigned.");

            if (string.IsNullOrWhiteSpace(user.Role.PermissionJson))
                throw new InvalidOperationException($"Role {user.Role.Name} has empty permissions.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name),
                new Claim("permissions", user.Role.PermissionJson)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
