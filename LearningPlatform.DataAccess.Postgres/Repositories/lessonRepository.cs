using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.Repositories
{
    public class lessonRepository
    {
        private readonly LearningDbContext _context;
        public lessonRepository(LearningDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<lesson> add(Guid courseId, createLessonDto dto)
        {
            course course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

            var lessonEntity = new lesson
            {
                Id = Guid.NewGuid(),
                Title = dto.title,
                Description = dto.description,
                LessonText = dto.lessonText,
                CourseId = courseId,


            };

            await _context.AddAsync(lessonEntity);
            await _context.SaveChangesAsync();
            return lessonEntity;

        }
    }
}
