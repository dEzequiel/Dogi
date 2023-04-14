using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
                .ToTable("Animal", "Dogi")
                .HasKey(x => x.Id)
            .IsClustered(false);

            builder.HasOne<IndividualProceeding>(f => f.IndividualProceeding)
                .WithOne(r => r.Animal)
                .HasForeignKey<Animal>(rd => rd.IndividualProceedingId);                
        }
    }
}
