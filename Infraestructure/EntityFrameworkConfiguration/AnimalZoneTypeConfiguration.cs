using Domain.Enums;
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


            var totalAnimalZones = Enum.GetNames(typeof(AnimalZones));

            int id = 0;
            foreach (var zone in totalAnimalZones)
            {
                id++;
                builder.HasData(new AnimalZone(id, zone));
            }
        }
    }
}