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

            builder.HasOne<Animal>(b => b.Animal)
                .WithOne(b => b.IndividualProceeding)
                .HasForeignKey<IndividualProceeding>(fk => fk.AnimalId)
                .IsRequired(false);

            builder.HasOne<ReceptionDocument>(f => f.ReceptionDocument)
                .WithOne(r => r.IndividualProceeding)
                .HasForeignKey<IndividualProceeding>(rd => rd.ReceptionDocumentId);

            builder.HasOne<AnimalChip>(b => b.AnimalChip)
                .WithOne(b => b.IndividualProceeding)
                .HasForeignKey<IndividualProceeding>(fk => fk.AnimalChipId)
                .IsRequired(false);

            builder.HasOne<ProceedingStatus>(b => b.ProceedingStatus)
                .WithMany(p => p.Processees)
                .HasForeignKey(fk => fk.StatusId)
                .IsRequired(false);

            builder.HasOne<AnimalCategory>(b => b.AnimalCategory)
                .WithMany(p => p.Processees)
                .HasForeignKey(fk => fk.CategoryId)
                .IsRequired(false);

        }
    }
}
