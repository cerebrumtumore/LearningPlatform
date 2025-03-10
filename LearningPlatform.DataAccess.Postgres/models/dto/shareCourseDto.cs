using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models.dto
{
    public class shareCourseDto
    {
        public shareCourseDto(Guid id, string title, Guid authorId, decimal price, string description, List<shareLessonDto> lessons)
        {
            this.id = id;
            this.title = title;
            this.authorId = authorId;
            this.price = price;
            this.description = description;
            this.lessons = lessons;
        }

        public Guid id { get; set; }
        public string title { get; set; }
        public Guid authorId { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public List<shareLessonDto> lessons { get; set; }
    }
    
}
