using Domain.Entities.Adoption;
using Domain.Enums.Adoption;
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

        builder.HasData(Enum.GetValues(typeof(HousingTypes))
            .Cast<HousingTypes>()
            .Select(e => new HousingType()
            {
                Id = (int)e,
                Type = e.ToString()
            })
        );
    }
}