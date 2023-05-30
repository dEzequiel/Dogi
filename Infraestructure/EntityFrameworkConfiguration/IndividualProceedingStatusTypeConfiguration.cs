using Domain.Enums;
using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class IndividualProceedingStatusTypeConfiguration : IEntityTypeConfiguration<IndividualProceedingStatus>
    {
        public void Configure(EntityTypeBuilder<IndividualProceedingStatus> builder)
        {
            builder
                .ToTable("IndividualProceedingStatus", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);


            builder.HasData(Enum.GetValues(typeof(IndividualProceedingStatuses))
                .Cast<IndividualProceedingStatuses>()
                .Select(e => new IndividualProceedingStatus
                {
                    Id = (int)e,
                    Status = e.ToString()
                })
             );
        }
    }
}
