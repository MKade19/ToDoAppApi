using System.IdentityModel.Tokens.Jwt;

namespace ToDoApp.Data.Services.Abstract
{
    public interface ITokenService
    {
        /// <summary>
        /// Decodes token from given string.
        /// </summary>
        /// <param name="encodedToken">String with token to be decoded.</param>
        /// <returns>Decoded jwt token.</returns>
        Task<JwtSecurityToken> DecodeTokenAsync(string encodedToken);

        /// <summary>
        /// Extracts id value from token object.
        /// </summary>
        /// <param name="decodedToken">Decoded token object.</param>
        /// <returns>Value of id from token payload</returns>
        Task<int> ExtractIdFromTokenAsync(JwtSecurityToken decodedToken);
    }
}
