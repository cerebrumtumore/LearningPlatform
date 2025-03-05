using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.DataAccess.Postgres.Auth;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LearningPlatform.DataAccess.Postgres.Repositories
{
    public class UserRepository(AuthOptions auth, LearningDbContext _context)
    {

        public async Task<string> LoginAsync(loginDto dto)
        {
            string token = null;

            var author = await _context.Authors
                .FirstOrDefaultAsync(x => x.Email == dto.email);

            var student = await _context.Students
                .FirstOrDefaultAsync(x => x.Email == dto.email);

            if(author != null)
            {
                if (!BCrypt.Net.BCrypt.EnhancedVerify(dto.password, author.Password))
                {
                    throw new Exception("not correct password");
                }
                else
                {
                    token = auth.CreateToken(new()
                    {
                        { "id", author.Id.ToString() }
                    });
                }
            }
            if (student != null)
            {
                if (!BCrypt.Net.BCrypt.EnhancedVerify(dto.password, student.Password))
                {
                    throw new Exception("not correct password");
                }
                else
                {
                    token = auth.CreateToken(new()
                    {
                        { "id", student.Id.ToString() }
                    });
                }
            }
            return token;
        }


        public Author GetAuthorById(Guid id)
        {
            return _context.Authors.FirstOrDefault(u => u.Id == id);
        }

        public student GetStudentById(Guid id)
        {
            return _context.Students.FirstOrDefault(u => u.Id == id);
        }
    }
}
