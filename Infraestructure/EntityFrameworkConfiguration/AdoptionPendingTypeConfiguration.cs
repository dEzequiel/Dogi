using Domain.Entities.Adoption;
using Domain.Entities.Shelter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class AdoptionPendingTypeConfiguration : IEntityTypeConfiguration<AdoptionPending>
{
    public void Configure(EntityTypeBuilder<AdoptionPending> builder)
    {
        builder
            .ToTable("AdoptionPending", "Adoption")
            .HasKey(x => x.Id)
            .IsClustered(false);

        builder.HasOne<AdoptionPendingStatus>(f => f.AdoptionPendingStatus)
            .WithMany(p => p.AdoptionPendings)
            .HasForeignKey(fk => fk.AdoptionPendingStatusId);

        builder.HasOne<IndividualProceeding>(f => f.IndividualProceeding)
            .WithOne(p => p.AdoptionPending)
            .HasForeignKey<AdoptionPending>(fk => fk.IndividualProceedingId);
    }
}