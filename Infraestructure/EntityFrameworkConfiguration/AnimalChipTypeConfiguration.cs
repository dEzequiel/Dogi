using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class AnimalChipTypeConfiguration : IEntityTypeConfiguration<AnimalChip>
    {
        public void Configure(EntityTypeBuilder<AnimalChip> builder)
        {
            builder
                .ToTable("AnimalChip", "Shelter")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder
                .HasOne<Person>(f => f.Person)
                .WithOne(r => r.AnimalChip)
                .HasForeignKey<AnimalChip>(rd => rd.PersonIdentifierId);

            builder
                .HasOne<ReceptionDocument>(f => f.ReceptionDocument)
                .WithOne(r => r.AnimalChip)
                .HasForeignKey<AnimalChip>(rd => rd.ReceptionDocumentId);
        }
    }
}