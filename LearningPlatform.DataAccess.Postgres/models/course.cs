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

        public user? UserAuthor { get; set; }

        public Guid UserAuthorid { get; set; }

        public List<user?> Students { get; set; } = [];
    }
}
