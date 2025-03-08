using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models.dto
{
    public class getCoursesDto
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public List<lesson?> lessons { get; set; }
        public Guid UserAuthorid { get; set; }
        public List<user?> students { get; set; }

        // Конструктор
        public getCoursesDto(Guid id, string title, string description, decimal price, List<lesson> lessons, Guid UserAuthorid, List<user> students)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.price = price;
            this.lessons = lessons;
            this.UserAuthorid = UserAuthorid;
            this.students = students;
        }
    };
}
