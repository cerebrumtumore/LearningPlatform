﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models.dto
{
    public record class createLessonDto(string title, string description, string lessonText, Guid courseId);
}
