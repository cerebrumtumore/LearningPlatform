using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.DataAccess.Postgres.Auth;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LearningPlatform.DataAccess.Postgres.Repositories
{
    public class UserRepository(AuthOptions auth, LearningDbContext _context)
    {

        public async Task<user> findById(Guid id)
        {
            user user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            return user;
        }

        public async Task<List<getCoursesDto>> getCourses(Guid id)
        {
            user user = await findById(id);
            return user.Courses.Select(course => new getCoursesDto
            (
                course.Id,  
                course.Title,
                course.Description,
                course.Price,
                course.Lessons,
                course.UserAuthorid,
                new List<user> { user }
            )).ToList();
        }


        public async Task register(createUserDto dto)
        {
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(dto.password, 13);
            var userEntity = new user
            {
                Id = Guid.NewGuid(),
                FullName = dto.fullName,
                Email = dto.email,
                Password = passwordHash,
                Role = dto.role
            };
            await _context.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<string> LoginAsync(loginDto dto)
        {
            string token = null;

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == dto.email);

            if (!BCrypt.Net.BCrypt.EnhancedVerify(dto.password, user.Password))
            {
                throw new Exception("not correct password");
            }
            else
            {
                token = auth.CreateToken(user);
            }
            return token;
        }


        public user GetAuthorById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
