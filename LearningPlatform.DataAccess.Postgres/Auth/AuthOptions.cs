using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LearningPlatform.DataAccess.Postgres.Auth
{
    public class AuthOptions(IOptions<AuthSettings> options)
    {


        public string CreateToken(Dictionary<string, string> data)
        {
            List<Claim> claims = [];
            foreach (var pair in data)
                claims.Add(new Claim(pair.Key, pair.Value));

            var expires = DateTime.UtcNow.Add(options.Value.Expires);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)), "HS256");

            JwtSecurityToken tokenObj = new(
                claims: claims,
                expires: expires,
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenObj);
            return token;
        }


        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(options.Value.SecretKey);
            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}
