using Domain.Entities.Shelter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class PersonBannedInformationTypeConfiguration : IEntityTypeConfiguration<PersonBannedInformation>
    {
        public void Configure(EntityTypeBuilder<PersonBannedInformation> builder)
        {
            builder
                .ToTable("PersonBannedInformation", "Shelter")
                .HasKey(x => x.Id)
                .IsClustered(false);
        }
    }
}