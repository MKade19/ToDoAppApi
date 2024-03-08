using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToDoApp.Models;
using ToDoApp.Security;
using ToDoApp.Services.Abstract;

namespace ToDoApp.Services
{
    public class TokenService : ITokenService
    {
        public string GetToken(object payload)
        {
            User user = (User)payload;

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
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

            var jopa = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
