using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class VaccinationCardTypeConfiguration : IEntityTypeConfiguration<VaccinationCard>
    {
        public void Configure(EntityTypeBuilder<VaccinationCard> builder)
        {
            builder
                .ToTable("VaccinationCard", "Veterinary")
                .HasKey(x => x.Id)
                .IsClustered(false);
        }
    }
}