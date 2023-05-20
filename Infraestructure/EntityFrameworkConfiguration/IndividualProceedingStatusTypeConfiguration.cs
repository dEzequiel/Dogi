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

            int id = 0;
            foreach (var status in totalProceedingStatusTypes)
            {
                id++;
                builder.HasData(new IndividualProceedingStatus(id, status));
            }
        }
    }
}
