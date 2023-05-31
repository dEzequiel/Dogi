using Domain.Entities;
using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class MedicalRecordTypeConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder
                .ToTable("MedicalRecord", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasOne<MedicalRecordStatus>(f => f.MedicalRecordStatus)
                .WithMany(m => m.MedicalRecords)
                .HasForeignKey(fk => fk.MedicalStatusId);


        }
    }
}
