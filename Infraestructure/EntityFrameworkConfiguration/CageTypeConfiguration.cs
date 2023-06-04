using Domain.Entities.Shelter;
using Domain.Enums.Shelter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class CageTypeConfiguration : IEntityTypeConfiguration<Cage>
    {
        public void Configure(EntityTypeBuilder<Cage> builder)
        {
            builder
                .ToTable("Cage", "Shelter")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasOne<AnimalZone>(r => r.AnimalZone)
                .WithMany(p => p.Cages)
                .HasForeignKey(fk => fk.AnimalZoneId);


            var totalAnimalZones = Enum.GetNames(typeof(AnimalZones));

            for (int zone = 1; zone <= totalAnimalZones.Length; zone++)
            {
                for (int cage = 0; cage <= 50; cage++)
                {
                    builder.HasData(
                        new Cage(Guid.NewGuid(), zone, null, cage, false)
                    );
                }
            }
        }
    }
}