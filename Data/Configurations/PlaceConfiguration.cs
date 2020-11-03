using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;

namespace Test.Data.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable(" Places");
            builder.HasKey(o => o.Id);
            builder.HasOne<Lession>(c => c.Lession).WithMany().HasForeignKey("LessionId");
        }
    }
}
