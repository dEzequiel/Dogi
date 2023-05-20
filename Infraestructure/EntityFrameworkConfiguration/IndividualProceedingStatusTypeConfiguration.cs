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


            var totalProceedingStatusTypes = Enum.GetNames(typeof(Domain.Enums.IndividualProceedingStatus));

            for (int id = 1; id < totalProceedingStatusTypes.Length; id++)
            {
                builder.HasData(new IndividualProceedingStatus(id, totalProceedingStatusTypes[id]));
            }
        }
    }
}
