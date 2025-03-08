using LearningPlatform.DataAccess.Postgres;
using LearningPlatform.DataAccess.Postgres.models.dto;
using LearningPlatform.DataAccess.Postgres.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class courseController : ControllerBase 
    {


        static Guid GetIdFromHttpContext(HttpContext ctx)
        {
            return new(ctx.User.FindFirst("id").Value);
        }
        [HttpPost("createCourse")]
        public async Task<IActionResult> create([FromBody] createCoursedto dto, LearningDbContext db) 
        {

            CourseRepository repo = new CourseRepository(db);
            await repo.Add(dto);
            return Ok(dto);
        }
    }


}
