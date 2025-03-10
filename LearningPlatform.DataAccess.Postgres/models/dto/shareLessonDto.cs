using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models.dto
{

    public class shareLessonDto
    {
        public shareLessonDto(Guid id, string title, string description, string lessonText, Guid courseId)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.lessonText = lessonText;
            this.courseId = courseId;
        }

        public Guid id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string lessonText { get; set; }
        public Guid courseId { get; set; }
    }
}
