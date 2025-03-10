using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models.dto
{
    public class shareUserdto
    {
        public shareUserdto(Guid id, string token, string email, List<shareCourseDto> courses, string role)
        {
            this.id = id;
            this.token = token;
            this.email = email;
            this.courses = courses;
            this.role = role;
        }

        public Guid id { get; set; }
        public string token { get; set; }
        public string email { get; set; }
        public List<shareCourseDto> courses { get; set; }
        public string role { get; set; }
    }

}
