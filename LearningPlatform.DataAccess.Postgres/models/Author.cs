using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; }


        public List<course> Courses { get; set; } = [];
    }
}
