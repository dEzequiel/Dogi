using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class MedicalRecordStatusTypeConfiguration : IEntityTypeConfiguration<MedicalRecordStatus>
    {
        public void Configure(EntityTypeBuilder<MedicalRecordStatus> builder)
        {
            builder
                .ToTable("MedicalRecordStatus", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            var totalMedicalStatusTypes = Enum.GetNames(typeof(Domain.Enums.MedicalRecordStatus));

            int id = 0;
            foreach (var status in totalMedicalStatusTypes)
            {
                id++;
                builder.HasData(new MedicalRecordStatus(id, status));
            }
        }
    }
}
