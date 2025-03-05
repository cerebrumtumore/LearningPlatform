using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.DataAccess.Postgres.models
{
    public class course
    {

        public Guid Id { get; set; }
        public string Title{ get; set; } = String.Empty;
        public string Description{ get; set; } = String.Empty;
        public decimal Price { get; set; } = 0;

        public List<lesson> Lessons { get; set; } = [];

        public Author? Author { get; set; }

        public Guid Authorid { get; set; }

        public List<student?> Students { get; set; } = [];
    }
}
