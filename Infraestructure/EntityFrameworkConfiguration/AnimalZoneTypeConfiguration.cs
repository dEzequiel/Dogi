using Domain.Entities;
using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class AnimalZoneTypeConfiguration : IEntityTypeConfiguration<AnimalZone>
    {
        public void Configure(EntityTypeBuilder<AnimalZone> builder)
        {
            builder
                .ToTable("Zone", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasMany<Cage>(f => f.Cages)
                .WithOne(r => r.AnimalZone)
                .HasForeignKey(fk => fk.AnimalZoneId);

            builder.HasData(
                Enum.GetValues(typeof(Domain.Enums.AnimalZone))
                .Cast<Domain.Enums.AnimalZone>()
                .Select(e => new { Id = (int)e, Name = e.ToString() })
            );
        }
    }
}