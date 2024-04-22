using System.IdentityModel.Tokens.Jwt;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Services
{
    public class TokenService : ITokenService
    {
        public async Task<JwtSecurityToken> DecodeTokenAsync(string encodedToken)
        {
            return await Task.Run(() =>
            {
                var handler = new JwtSecurityTokenHandler();
                return handler.ReadJwtToken(encodedToken);
            });
        }

        public async Task<int> ExtractIdFromTokenAsync(JwtSecurityToken decodedToken)
        {
            return await Task.Run(() =>
            {
                string idString = decodedToken.Claims.First(claim => claim.Type == "id").Value;
                return Convert.ToInt32(idString);
            });
        }
    }
}
