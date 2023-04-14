using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

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

            builder.HasOne(f => f.IndividualProceeding)
                .WithOne(r => r.Animal)
                .HasForeignKey<Animal>(rd => rd.IndividualProceedingId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(a => a.Sex)
                   .HasConversion<int>()
                    .IsRequired();

          
        }
    }
}
