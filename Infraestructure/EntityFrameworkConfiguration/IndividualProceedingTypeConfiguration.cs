using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.HasOne<AnimalChip>(b => b.AnimalChip)
                .WithOne(b => b.IndividualProceeding)
                .HasForeignKey<IndividualProceeding>(fk => fk.AnimalChipId)
                .IsRequired(false);

            builder.Property(s => s.Status)
                    .HasConversion<int>();

            builder.Property(s => s.AnimalCategory)
                    .HasConversion<int>();

        }
    }
}
