using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;

namespace Test.Data.Configurations
{
    public class ClassUserConfiguration : IEntityTypeConfiguration<ClassUser>
    {
        public void Configure(EntityTypeBuilder<ClassUser> builder)
        {
            builder.ToTable("ClassUsers");
            builder.HasKey(s => new { s.UserId, s.ClassId });
            builder.HasOne<User>(u => u.User).WithMany(u => u.ClassUser).HasForeignKey(cu => cu.UserId);
            builder.HasOne<Class>(c => c.Class).WithMany(c => c.ClassUser).HasForeignKey(cu => cu.ClassId);
        }
    }
}
