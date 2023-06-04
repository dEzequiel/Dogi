using Domain.Entities.Shelter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class ReceptionDocumentTypeConfiguration : IEntityTypeConfiguration<ReceptionDocument>
    {
        public void Configure(EntityTypeBuilder<ReceptionDocument> builder)
        {
            builder
                .ToTable("ReceptionDocument", "Shelter")
                .HasKey(x => x.Id)
                .IsClustered(false);
        }
    }
}