using Administration.Application.Authentication;
using Administration.Domain.Entities;
using Administration.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Administration.Infrastructure.ExternalServices
{
    /// <summary>
    /// Generates JWT tokens using the configured signing key, issuer, audience, and expiry.
    /// </summary>

    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IConfiguration configuration)
        {
            _jwtSettings = new JwtSettings
            {
                Key = configuration["JwtSettings:Key"],
                Issuer = configuration["JwtSettings:Issuer"],
                Audience = configuration["JwtSettings:Audience"],
                ExpiryMinutes = int.Parse(configuration["JwtSettings:ExpiryMinutes"] ?? "60")
            };
        }

        public string GenerateAccessToken(User user)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Claims can be added here based on the user information, such as roles, permissions, etc.
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
               new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
               new Claim(JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber)
            };
            
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
