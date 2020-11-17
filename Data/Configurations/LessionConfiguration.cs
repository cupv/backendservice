using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;

namespace API.Data.Configurations
{
    public class LessionConfiguration : IEntityTypeConfiguration<Lession>
    {
        public void Configure(EntityTypeBuilder<Lession> builder)
        {
            builder.ToTable("Lession");
            builder.HasOne<Course>(l => l.Course).WithMany().HasForeignKey("CourseId");
        }

    }
}
