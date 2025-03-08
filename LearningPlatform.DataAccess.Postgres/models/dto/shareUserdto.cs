using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models.dto
{
    public record class shareUserdto(Guid id, string email, List<course> courses, List<lesson> lessons, string role);

}
