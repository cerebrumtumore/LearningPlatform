using LearningPlatform.DataAccess.Postgres;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;
using LearningPlatform.DataAccess.Postgres.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LearningPlatform.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class courseController : ControllerBase
    {

        [HttpGet("getById")]
        public async Task<IActionResult> getById([FromQuery] Guid id, LearningDbContext db)
        {
            CourseRepository repo = new CourseRepository(db);
            course data = await repo.GetById(id);
            var course = new shareCourseDto
                (
                data.Id,
                data.Title,
                data.UserAuthorid,
                data.Price,
                data.Description,
                await db.Lessons
                .Where(l => l.CourseId == data.Id) // Получаем уроки для курса
                .Select(l => new shareLessonDto
                (
                    l.Id,
                    l.Title,
                    l.Description,
                    l.LessonText,
                    data.Id
                ))
                .ToListAsync());
            return Ok(course);
        }


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

        [HttpPost("/remove")]
        public async void removee([FromQuery] Guid id, LearningDbContext db)
        {

            CourseRepository repo = new CourseRepository(db);
            await repo.remove(id);
        }


    }


}
