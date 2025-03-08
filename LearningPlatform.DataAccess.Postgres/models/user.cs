using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models
{
    public class user
    {
        public Guid Id { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }
        public string FullName { get; set; }

        public string Password { get; set; }

        public List<course> Courses { get; set; } = [];

        public List<course> AuthorCourses { get; set; } = [];

        public List<lesson?> Lessons { get; set; } = [];
    }
}
