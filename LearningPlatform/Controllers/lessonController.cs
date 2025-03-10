using LearningPlatform.DataAccess.Postgres;
using LearningPlatform.DataAccess.Postgres.Auth;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;
using LearningPlatform.DataAccess.Postgres.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class lessonController(lessonRepository repo, AuthOptions options) : ControllerBase
    {
        [HttpPost("createLesson")]
        public async Task<IActionResult> createLesson([FromQuery] Guid courseId, [FromBody] createLessonDto dto, LearningDbContext db)
        {
            lesson newLesson =  await repo.add(courseId, dto);
            return Ok(newLesson);
        }
    }
}
