using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LearningPlatform.DataAccess.Postgres;
using LearningPlatform.DataAccess.Postgres.Auth;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;
using LearningPlatform.DataAccess.Postgres.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LearningPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(UserRepository repo, AuthOptions options) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] loginDto dto, LearningDbContext db)
        {
            var token = await repo.LoginAsync(dto);
            Response.Cookies.Append("slivki", token, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok("succes");
        }


        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {

                var jwt = Request.Cookies["slivki"];    
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(jwt);
                Guid userId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "id").Value);


                if (repo.GetAuthorById(userId) != null)
                {
                    Author user = repo.GetAuthorById(userId);
                    return Ok(user);
                }
                else if (repo.GetStudentById(userId) != null)
                {
                    student user = repo.GetStudentById(userId);
                    return Ok(user);
                }

                return Ok("НЕОК");
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
