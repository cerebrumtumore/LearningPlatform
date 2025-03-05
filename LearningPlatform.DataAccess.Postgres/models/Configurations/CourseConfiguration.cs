using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.models.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<course>
    {
        public void Configure(EntityTypeBuilder<course> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasOne(c => c.Author)
                .WithMany(c => c.Courses);

            builder
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            builder
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses);

        }
    }
}
