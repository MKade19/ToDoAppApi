using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ToDoApp.Common.Security
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; 
        public const string AUDIENCE = "MyAuthClient"; 
        const string KEY = "uhotgwuoGHuoe/;ghushguoghero/;usrhguish;rgshrngousrgousrhsr"; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
