
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class AnimalChipTypeConfiguration : IEntityTypeConfiguration<AnimalChip>
    {
        public void Configure(EntityTypeBuilder<AnimalChip> builder)
        {
            builder
                .ToTable("AnimalChip", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.OwnsOne(vo => vo.Owner, owner =>
            {
                owner.Property(x => x.Name).HasColumnName("OwnerName");
                owner.Property(x => x.Lastname).HasColumnName("OwnerLastName");
                owner.Property(x => x.Contact).HasColumnName("OwnerContact");
                owner.OwnsOne(z => z.Address, address =>
                {
                    address.Property(x => x.Street).HasColumnName("OwnerAddressStreet");
                    address.Property(x => x.City).HasColumnName("OwnerAddressCity");
                    address.Property(x => x.ZipCode).HasColumnName("OwnerAddressZipCode");
                });
            });


        }
    }
}
