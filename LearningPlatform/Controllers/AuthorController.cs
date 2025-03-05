using LearningPlatform.DataAccess.Postgres;
using LearningPlatform.DataAccess.Postgres.models.dto;
using LearningPlatform.DataAccess.Postgres.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> create([FromBody] createAuthordto dto, LearningDbContext db)
        {
            AuthorRepository repo = new AuthorRepository(db);
            await repo.Add(dto);
            return Ok(repo);
        }

    }
}
