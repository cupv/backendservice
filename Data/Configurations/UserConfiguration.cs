using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;

namespace API.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(o => o.Id);
            builder.HasOne<Role>(c => c.Role).WithMany().HasForeignKey("RoleId");
            builder.HasOne<Grade>(c => c.Grade).WithMany().HasForeignKey("GradeId");
            builder.HasOne<Team>(c => c.Team).WithMany().HasForeignKey("TeamId");
        }
    }
}
