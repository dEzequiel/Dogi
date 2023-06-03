using Domain.Entities;
using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class VaccineTypeConfiguration : IEntityTypeConfiguration<Vaccine>
    {
        public void Configure(EntityTypeBuilder<Vaccine> builder)
        {
            builder
                .ToTable("Vaccine", "Veterinary")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasOne<AnimalCategory>(c => c.AnimalCategory)
                .WithMany(v => v.Vaccines)
                .HasForeignKey(fk => fk.AnimalCategoryId);
        }
    }
}