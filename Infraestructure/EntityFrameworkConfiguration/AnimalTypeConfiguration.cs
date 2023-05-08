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

            builder.HasOne(f => f.Sex)
                .WithMany(r => r.Animals)
                .HasForeignKey(fk => fk.SexId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.AnimalCategory)
                .WithMany(r => r.Animals)
                .HasForeignKey(fk => fk.AnimalCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
