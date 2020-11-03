using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;

namespace Test.Data.Configurations
{
    public class LessionConfiguration : IEntityTypeConfiguration<Lession>
    {
        public void Configure(EntityTypeBuilder<Lession> builder)
        {
            builder.ToTable("Lessions");
            builder.HasOne<Course>(l => l.Course).WithMany().HasForeignKey("CourseId");
        }

    }
}
