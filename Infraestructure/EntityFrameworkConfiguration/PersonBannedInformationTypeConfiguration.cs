
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class PersonBannedInformationTypeConfiguration : IEntityTypeConfiguration<PersonBannedInformation>
    {
        public void Configure(EntityTypeBuilder<PersonBannedInformation> builder)
        {
            builder
                .ToTable("PersonBannedInformation", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

        }
    }
}