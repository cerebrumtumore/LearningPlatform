using LearningPlatform.DataAccess.Postgres.models.dto;
using LearningPlatform.DataAccess.Postgres.Repositories;
using LearningPlatform.DataAccess.Postgres;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> create([FromBody] createStudentdto dto, LearningDbContext db)
        {
            StudentRepository repo = new StudentRepository(db);
            await repo.Add(dto);
            return Ok(repo);
        }
    }
}
