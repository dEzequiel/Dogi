using Domain.Entities.Adoption;
using Domain.Enums.Adoption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class AdoptionPendingStatusTypeConfiguration : IEntityTypeConfiguration<AdoptionPendingStatus>
{
    public void Configure(EntityTypeBuilder<AdoptionPendingStatus> builder)
    {
        builder
            .ToTable("AdoptionPendingStatus", "Adoption")
            .HasKey(x => x.Id)
            .IsClustered();

        builder.HasData(Enum.GetValues(typeof(AdoptionPendingStatuses))
            .Cast<AdoptionPendingStatuses>()
            .Select(e => new AdoptionPendingStatus()
            {
                Id = (int)e,
                Status = e.ToString()
            })
        );
    }
}