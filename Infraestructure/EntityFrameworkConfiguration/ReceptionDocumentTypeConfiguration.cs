using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class ReceptionDocumentTypeConfiguration : IEntityTypeConfiguration<ReceptionDocument>
    {
        public void Configure(EntityTypeBuilder<ReceptionDocument> builder)
        {
            builder
                .ToTable("ReceptionDocument", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);
        }
    }
}
