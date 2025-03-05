
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DataAccess.Postgres.models.Configurations
{
    public class studentConfiguration : IEntityTypeConfiguration<student>
    {
        public void Configure(EntityTypeBuilder<student> builder)
        {
            builder.HasKey(e => e.Id);
            builder
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students);
        }
    }
}
