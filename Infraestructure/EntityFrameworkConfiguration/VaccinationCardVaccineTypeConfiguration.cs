using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class VaccinationCardVaccineTypeConfiguration : IEntityTypeConfiguration<VaccinationCardVaccine>
    {
        public void Configure(EntityTypeBuilder<VaccinationCardVaccine> builder)
        {
            builder.
                ToTable("VaccinationCardVaccine", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);
        }
    }
}
