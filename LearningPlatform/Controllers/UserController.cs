using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Azure.Core;
using LearningPlatform.DataAccess.Postgres;
using LearningPlatform.DataAccess.Postgres.Auth;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;
using LearningPlatform.DataAccess.Postgres.Repositories;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var user = await db.Users
                .Include(u => u.Courses)
                .FirstOrDefaultAsync(x => x.Email == dto.email);

            


            string token = await repo.LoginAsync(dto);
            var userDto = new shareUserdto
            (
                user.Id,
                token,
                user.Email,
                user.Courses.Select(c => new shareCourseDto
                (
                    c.Id,
                    c.Title,
                    c.UserAuthorid,
                    c.Price,
                    c.Description,
                    c.Lessons.Select(l => new shareLessonDto
                    (
                        l.Id,
                        l.Title,
                        l.Description,
                        l.LessonText,
                        c.Id

                    )).ToList()

                )).ToList(),
                user.Role
            );
            List<course> courses = user.Courses;
            return Ok(userDto);
        }


        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] createUserDto dto, LearningDbContext db)
        {
            await repo.register(dto);
            return Ok("da") ;
        }


        [HttpGet("getCourses")]
        public IActionResult getCourses()
        {
            string token = null;
            Guid userId = Guid.Empty;

            if (Request.Headers.ContainsKey("Authorization"))
            {
                var authHeader = Request.Headers["Authorization"].ToString();
                if (authHeader.StartsWith("Bearer "))
                {
                    token = authHeader.Substring("Bearer ".Length).Trim();
                }
            }
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                userId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "id").Value);
            }

            return Ok(repo.getCourses(userId));
        }


        [HttpGet("user")]
        public async Task<IActionResult> User(LearningDbContext db)
        {

            Guid userId = Guid.Empty;
            try
            {
                string token = null;
                

                if (Request.Headers.ContainsKey("Authorization"))
                {
                    var authHeader = Request.Headers["Authorization"].ToString();
                    if (authHeader.StartsWith("Bearer "))
                    {
                        token = authHeader.Substring("Bearer ".Length).Trim();
                    }
                }
                if (!string.IsNullOrEmpty(token))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(token);
                    userId = Guid.Parse(jwtToken.Claims.First(claim => claim.Type == "id").Value);
                }

                                


                if (repo.GetAuthorById(userId) != null)
                {
                    var user = await db.Users
                    .Include(u => u.Courses)
                    .FirstOrDefaultAsync(x => x.Id == userId);

                    var userDto = new shareUserdto
                    (
                        user.Id,
                        token,
                        user.Email,
                        user.Courses.Select(c => new shareCourseDto
                        (
                            c.Id,
                            c.Title,
                            c.UserAuthorid,
                            c.Price,
                            c.Description,
                            c.Lessons.Select(l => new shareLessonDto
                            (
                                l.Id,
                                l.Title,
                                l.Description,
                                l.LessonText,
                                c.Id

                            )).ToList()

                        )).ToList(),
                        user.Role
                    );
                    return Ok(userDto);
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
