using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace TodoApp.Extensions
{
    public static class TokenExtension
    {
        public static int GetUserId(this HttpRequest request)
        {
            var auth = request.Headers["Authorization"].ToString();
            var handler = new JwtSecurityTokenHandler();
            var userId =
                int.Parse(handler.ReadJwtToken(auth.Substring(7)).Claims.First(c => c.Type == "UserId").Value);
            return userId;
        }
    }
}