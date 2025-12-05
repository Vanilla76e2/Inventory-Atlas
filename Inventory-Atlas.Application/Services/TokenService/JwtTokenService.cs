using Inventory_Atlas.Application.Services.JwtKeyProvider;
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
        public string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_keyProvider.GetKey()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
