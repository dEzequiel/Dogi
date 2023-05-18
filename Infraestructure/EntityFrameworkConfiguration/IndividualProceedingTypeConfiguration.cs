using Domain.Entities;
using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class IndividualProceedingTypeConfiguration : IEntityTypeConfiguration<IndividualProceeding>
    {
        public void Configure(EntityTypeBuilder<IndividualProceeding> builder)
        {
            builder
                .ToTable("IndividualProceeding", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasOne<ReceptionDocument>(f => f.ReceptionDocument)
                .WithOne(r => r.IndividualProceeding)
                .HasForeignKey<IndividualProceeding>(rd => rd.ReceptionDocumentId);

            builder.HasOne<ProceedingStatus>(b => b.ProceedingStatus)
                .WithMany(p => p.Processees)
                .HasForeignKey(fk => fk.StatusId)
                .IsRequired(false);

            builder.HasOne<AnimalCategory>(f => f.AnimalCategory)
                .WithMany(r => r.IndividualProceedings)
                .HasForeignKey(fk => fk.CategoryId);

            builder.HasOne<Cage>(f => f.Cage)
                .WithOne(r => r.IndividualProceeding)
                .HasForeignKey<IndividualProceeding>(rd => rd.CageId);
        }
    }
}
