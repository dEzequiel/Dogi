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


            builder.HasData(Enum.GetValues(typeof(Domain.Enums.MedicalRecordStatus))
                .Cast<Domain.Enums.MedicalRecordStatus>()
                .Select(e => new MedicalRecordStatus
                {
                    Id = (int)e,
                    Status = e.ToString()
                })
             );
        }
    }
}
