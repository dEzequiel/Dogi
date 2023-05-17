using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class PersonTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .ToTable("Person", "Dogi")
                .HasKey(x => x.PersonIdentifier)
                .IsClustered(false);

                builder.Property(p => p.PersonIdentifier)
                .ValueGeneratedNever();

                builder.HasMany<AnimalChip>(f => f.AnimalChips)
                    .WithOne(r => r.AnimalChipOwner)
                    .HasForeignKey(fk => fk.OwnerPersonalIdentifier);
                
                builder.HasMany<PersonBannedInformation>(f => f.Bans)
                    .WithOne(b => b.Person)
                    .HasForeignKey(fk => fk.PersonIdentifierId);

                builder.OwnsOne(z => z.Address, address =>
                    {
                        address.Property(x => x.Street).HasColumnName("OwnerAddressStreet");
                        address.Property(x => x.City).HasColumnName("OwnerAddressCity");
                        address.Property(x => x.ZipCode).HasColumnName("OwnerAddressZipCode");
                    });
        }
    }
}