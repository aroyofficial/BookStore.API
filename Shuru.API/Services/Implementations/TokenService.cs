using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shuru.API.Configurations;
using Shuru.API.DTOs.Internal;
using Shuru.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shuru.API.Services.Implementations
{
    /// <summary>
    /// Provides functionality for generating JSON Web Tokens (JWT) for authentication purposes.
    /// </summary>
    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class with the specified token configuration.
        /// </summary>
        /// <param name="configuration">The token configuration options.</param>
        public TokenService(IOptions<TokenConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        /// <inheritdoc/>
        public (string, DateTime) GenerateToken(TokenPayload payload)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, payload.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, payload.UserName),
                new Claim("username", payload.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var expiresAt = DateTime.UtcNow.AddMinutes(_configuration.ExpiryMinutes);
            var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials
            );

            return (new JwtSecurityTokenHandler().WriteToken(token), expiresAt);
        }
    }
}
