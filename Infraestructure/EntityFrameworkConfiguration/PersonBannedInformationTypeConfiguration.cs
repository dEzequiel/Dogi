
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class PersonBannedInformationType : IEntityTypeConfiguration<PersonBannedInformation>
    {
        public void Configure(EntityTypeBuilder<PersonBannedInformation> builder)
        {
            builder
                .ToTable("PersonBannedInformation", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);


                builder.HasOne<Person>(f => f.Person)
                    .WithMany(r => r.Bans)
                    .HasForeignKey(fk => fk.PersonIdentifierId);
        }
    }
}