using Domain.Entities.Adoption;
using Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class AdoptionApplicationTypeConfiguration : IEntityTypeConfiguration<AdoptionApplication>
{
    public void Configure(EntityTypeBuilder<AdoptionApplication> builder)
    {
        builder
            .ToTable("AdoptionApplication", "Adoption")
            .HasKey(x => x.Id)
            .IsClustered(false);

        builder.HasOne<AdoptionPending>(f => f.AdoptionPending)
            .WithMany(x => x.AdoptionApplications)
            .HasForeignKey(fk => fk.AdoptionPendingId);

        builder.HasOne<User>(f => f.User)
            .WithMany(x => x.AdoptionApplications)
            .HasForeignKey(fk => fk.UserId);

        builder.HasOne<HousingType>(f => f.HousingType)
            .WithMany(x => x.AdoptionApplications)
            .HasForeignKey(fk => fk.HousingTypeId);

        builder.OwnsOne(x => x.HouseDescription);
        builder.OwnsOne(x => x.OtherAnimals);
        builder.OwnsOne(x => x.PersonalReferences);
    }
}