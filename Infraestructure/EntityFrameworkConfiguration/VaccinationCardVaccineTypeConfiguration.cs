using Domain.Entities;
using Domain.Support;
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

            builder.HasOne<VaccinationCard>(vc => vc.VaccinationCard)
                .WithMany(x => x.VaccinationCardVaccines)
                .HasForeignKey(vc => vc.VaccinationCardId);

            builder.HasOne<Vaccine>(vc => vc.Vaccine)
                .WithMany(x => x.VaccinationCardVaccines)
                .HasForeignKey(vc => vc.VaccineId);

            builder.HasOne<VaccineStatus>(vs => vs.VaccineStatus)
                .WithMany(x => x.VaccinationCardVaccines)
                .HasForeignKey(vs => vs.VaccineStatusId);
        }
    }
}
