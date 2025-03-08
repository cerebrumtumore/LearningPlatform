using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.DataAccess.Postgres.models;
using LearningPlatform.DataAccess.Postgres.models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres;
public class LearningDbContext(DbContextOptions<LearningDbContext> options) :DbContext(options)
{
    public DbSet<course> Courses { get; set; }
    public DbSet<lesson> Lessons { get; set; }
    public DbSet<user> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new lessonConfiguraion());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new userConfiguration());
        base.OnModelCreating(modelBuilder);
    }

}
