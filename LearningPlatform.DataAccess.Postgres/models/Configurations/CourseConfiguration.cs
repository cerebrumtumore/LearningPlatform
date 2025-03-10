using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace LearningPlatform.DataAccess.Postgres.models.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<course>
    {
        public void Configure(EntityTypeBuilder<course> builder)
        {
            builder.HasKey(e => e.Id);

            builder
                .HasMany(c => c.Students)
                .WithMany(u => u.Courses);

            builder.HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.UserAuthor)
                .WithMany(u => u.AuthorCourses)
                .HasForeignKey(c => c.UserAuthorid)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
