using LearningPlatform.DataAccess.Postgres.Auth;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.Repositories
{

    public class CourseRepository
    {
        private readonly LearningDbContext _context;

        public CourseRepository(LearningDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<List<course>> GetCourses()
        {
            return await _context.Courses
                .AsNoTracking()
                .OrderBy(c => c.Title)
                .ToListAsync();
        }

        public async Task<List<course>> GetWithLessons()
        {
            return await _context.Courses
                .AsNoTracking()
                .Include(c => c.Lessons)
                .ToListAsync();
        }

        public async Task<course?> GetById(Guid id)
        {
            return await _context.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Add(createCoursedto dto)
        {
            user user = await _context.Users.FirstOrDefaultAsync(c => c.Id == dto.authorId);


            var courseEntity = new course
            {
                Id = Guid.NewGuid(),
                UserAuthorid = dto.authorId,
                Title = dto.title,
                Description = dto.description,
                Price = dto.price,
                Students = new List<user?> { user },
                
            };

            await _context.AddAsync(courseEntity);
            await _context.SaveChangesAsync();
        }
    }
}
