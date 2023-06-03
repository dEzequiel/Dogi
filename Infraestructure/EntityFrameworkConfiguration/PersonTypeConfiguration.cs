using Domain.Entities.Shelter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class PersonTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .ToTable("Person", "Shelter")
                .HasKey(x => x.PersonIdentifier)
                .IsClustered(false);

            builder.Property(p => p.PersonIdentifier)
                .ValueGeneratedNever();

            builder.HasMany(p => p.Bans)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonIdentifierId);

            builder.OwnsOne(person => person.Address, address =>
            {
                address.Property(x => x.Street).HasColumnName("AddressStreet");
                address.Property(x => x.City).HasColumnName("AddressCity");
                address.Property(x => x.ZipCode).HasColumnName("AddressZipCode");
            });
        }
    }
}