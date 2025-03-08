using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LearningPlatform.DataAccess.Postgres.models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LearningPlatform.DataAccess.Postgres.Auth
{
    public class AuthOptions(IOptions<AuthSettings> options)
    {


        public string CreateToken(user user)
        {
            var claims = new List<Claim>
            {
                new Claim("fullname", user.FullName),
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)

            };

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
