using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class AnimalChipOwnerTypeConfiguration : IEntityTypeConfiguration<AnimalChipOwner>
    {
        public void Configure(EntityTypeBuilder<AnimalChipOwner> builder)
        {
            builder
                .ToTable("AnimalChipOwner", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);
                

            builder.OwnsOne(vo => vo.Address, a =>
            {
                a.Property(x => x.City).HasColumnName("City");
                a.Property(x => x.Street).HasColumnName("Street");
            });
        }
    }
}
