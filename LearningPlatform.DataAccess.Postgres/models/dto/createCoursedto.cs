using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models.dto;
    public record class createCoursedto(Guid id, string title, string desc, decimal price);

