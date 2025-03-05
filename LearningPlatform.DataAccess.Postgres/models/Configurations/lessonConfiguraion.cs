using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.models.Configurations
{
    public class lessonConfiguraion : IEntityTypeConfiguration<lesson>
    {
        public void Configure(EntityTypeBuilder<lesson> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.Course)
                .WithMany(c => c.Lessons)
                .HasForeignKey(l => l.CourseId);
        }
    }
}
