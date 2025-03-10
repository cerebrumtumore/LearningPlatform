using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningPlatform.DataAccess.Postgres.models.Configurations
{
    public class userConfiguration : IEntityTypeConfiguration<user>
    {
        public void Configure(EntityTypeBuilder<user> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.HasMany(u => u.Courses)
            .WithMany(c => c.Students)
            .UsingEntity(j => j.ToTable("CourseStudents"));

            builder.HasMany(u => u.AuthorCourses)
                .WithOne(c => c.UserAuthor)
                .HasForeignKey(c => c.UserAuthorid);

        }
    }
}
