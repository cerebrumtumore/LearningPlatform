using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;

namespace LearningPlatform.DataAccess.Postgres.Repositories
{
    public class StudentRepository
    {
        private readonly LearningDbContext _context;

        public StudentRepository(LearningDbContext context)
        {
            _context = context;
        }

        public async Task Add(createStudentdto dto)
        {
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(dto.password, 13);

            var studentEntity = new student
            {
                Id = Guid.NewGuid(),
                Name = dto.name,
                Email = dto.email,
                Password = passwordHash,
            };

            await _context.AddAsync(studentEntity);
            await _context.SaveChangesAsync();
        }
    }
}
