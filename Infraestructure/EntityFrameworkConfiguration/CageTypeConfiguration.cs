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
        }
    }
}
