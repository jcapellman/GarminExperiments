using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jcGAI.WebAPI.Common
{
    public class JWTIO
    {
        public static string GenerateToken(Guid userId)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, AppConstants.JWT_Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                AppConstants.JWT_Issuer,
                AppConstants.JWT_Audience,
                claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConstants.JWT_Secret)), 
                SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}