﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models
{
    public class lesson
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = String.Empty;
        public string LessonText { get; set; } = string.Empty;

        public Guid CourseId { get; set; }

        [JsonIgnore]
        public course Course { get; set; }
    }
}
