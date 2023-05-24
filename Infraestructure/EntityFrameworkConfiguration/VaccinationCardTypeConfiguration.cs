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
                .ToTable("VaccinationCard", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasMany(p => p.Vaccines)
                .WithMany(m => m.VaccinationCards)
                .UsingEntity<VaccinationCardVaccine>();
        }
    }
}
