using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class ProceedingStatusTypeConfiguration : IEntityTypeConfiguration<ProceedingStatus>
    {
        public void Configure(EntityTypeBuilder<ProceedingStatus> builder)
        {
            builder
                .ToTable("ProceedingStatus", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasData(
                Enum.GetValues(typeof(Domain.Enums.IndividualProceedingStatus))
                .Cast<Domain.Enums.IndividualProceedingStatus>()
                .Select(e => new { Id = (int)e, Status = e.ToString() })
             );
        }
    }
}
