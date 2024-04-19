using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToDoApp.Common.Models;
using ToDoApp.Common.Security;
using ToDoApp.Auth.Services.Abstract;

namespace ToDoApp.Auth.Services
{
    public class TokenService : ITokenService
    {
        public string GetToken(object payload)
        {
            Employee user = (Employee)payload;

            var claims = new List<Claim> {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
                    signingCredentials: new SigningCredentials(
                        AuthOptions.GetSymmetricSecurityKey(),
                        SecurityAlgorithms.HmacSha256
                    ));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
