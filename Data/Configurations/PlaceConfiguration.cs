using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;

namespace API.Data.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable(" Place");
            builder.HasKey(o => o.Id);
            builder.HasOne<Lession>(c => c.Lession).WithMany().HasForeignKey("LessionId");
        }
    }
}
