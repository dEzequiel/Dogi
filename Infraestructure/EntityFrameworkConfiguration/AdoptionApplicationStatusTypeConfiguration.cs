using Domain.Entities.Adoption;
using Domain.Enums.Adoption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class AdoptionApplicationStatusTypeConfiguration : IEntityTypeConfiguration<AdoptionApplicationStatus>
{
    public void Configure(EntityTypeBuilder<AdoptionApplicationStatus> builder)
    {
        builder
            .ToTable("AdoptionApplicationStatus", "Adoption")
            .HasKey(x => x.Id)
            .IsClustered();

        builder.HasData(Enum.GetValues(typeof(AdoptionApplicationStatuses))
            .Cast<AdoptionApplicationStatuses>()
            .Select(e => new AdoptionApplicationStatus
            {
                Id = (int)e,
                Status = e.ToString()
            })
        );
    }
}