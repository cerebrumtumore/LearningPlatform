using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.DataAccess.Postgres.models.dto;
using LearningPlatform.DataAccess.Postgres.models;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.Repositories
{
    public class AuthorRepository
    {
        private readonly LearningDbContext _context;

        public AuthorRepository(LearningDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task Add(createAuthordto dto)
        {

            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(dto.password, 13);

            var courseEntity = new Author
            {
                Id = Guid.NewGuid(),
                UserName = dto.username,
                Password = passwordHash,
                Email = dto.email
            };

            await _context.AddAsync(courseEntity);
            await _context.SaveChangesAsync();
        }
    }
}
