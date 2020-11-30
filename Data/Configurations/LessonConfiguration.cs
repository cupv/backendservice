using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;

namespace API.Data.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lesson");
            builder.HasOne<Course>(l => l.Course).WithMany().HasForeignKey("CourseId");
        }

    }
}
