using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class MedicalRecordVaccinesTypeConfiguration : IEntityTypeConfiguration<MedicalRecordVaccines>
    {
        public void Configure(EntityTypeBuilder<MedicalRecordVaccines> builder)
        {
            builder.
                ToTable("MedicalRecordVaccines", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);
        }
    }
}
