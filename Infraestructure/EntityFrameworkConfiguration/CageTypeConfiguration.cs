using Domain.Entities;
using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class CageTypeConfiguration : IEntityTypeConfiguration<Cage>
    {
        public void Configure(EntityTypeBuilder<Cage> builder)
        {
            builder
                .ToTable("Cage", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasOne<AnimalZone>(f => f.AnimalZone)
                .WithMany(r => r.Cages)
                .HasForeignKey(fk => fk.ZoneId);

            int totalZones = 10;

            for (int zone = 1; zone < totalZones; zone++)
            {
                for (int cage = 0; cage < 50; cage++)
                {
                    builder.HasData(
                        new Cage(
                            Guid.NewGuid(),
                            zone,
                            cage,
                            false)
                        );
                }
            }

        }
    }
}
