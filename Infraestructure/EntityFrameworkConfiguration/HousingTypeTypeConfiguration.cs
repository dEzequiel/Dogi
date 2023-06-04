using Domain.Entities.Adoption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class HousingTypeTypeConfiguration : IEntityTypeConfiguration<HousingType>
{
    public void Configure(EntityTypeBuilder<HousingType> builder)
    {
        builder
            .ToTable("HousingType", "Adoption")
            .HasKey(x => x.Id)
            .IsClustered(false);
    }
}