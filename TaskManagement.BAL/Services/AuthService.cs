using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Models;

namespace TaskManagementSystem.BAL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UserDetailModel user)
        {
            var jwtSettings = _configuration.GetSection("JWT");

            var secret = jwtSettings["Secret"];
            var validIssuer = jwtSettings["ValidIssuer"];
            var validAudience = jwtSettings["ValidAudience"];
            var tokenExpiryMinutes = jwtSettings["TokenExpiryMinutes"];

            if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(validIssuer) || string.IsNullOrEmpty(validAudience) || string.IsNullOrEmpty(tokenExpiryMinutes))
            {
                throw new ArgumentNullException("One or more JWT settings are null or empty.");
            }

            var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("LoggedOn", DateTime.Now.ToString()),
        };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWT:TokenExpiryMinutes"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
