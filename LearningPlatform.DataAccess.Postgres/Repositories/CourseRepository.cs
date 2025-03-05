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

        public async Task Add(createCoursedto dto, Guid userid)
        {

            var courseEntity = new course
            {
                Id = Guid.NewGuid(),
                Authorid = userid,
                Title = dto.title,
                Description = dto.desc,
                Price = dto.price
            };

            await _context.AddAsync(courseEntity);
            await _context.SaveChangesAsync();
        }
    }
}
