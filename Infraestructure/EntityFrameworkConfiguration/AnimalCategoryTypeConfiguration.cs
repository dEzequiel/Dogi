using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class AnimalCategoryTypeConfiguration : IEntityTypeConfiguration<AnimalCategory>
    {
        public void Configure(EntityTypeBuilder<AnimalCategory> builder)
        {
            builder
                .ToTable("AnimalCategory", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasData(
                Enum.GetValues(typeof(Domain.Enums.AnimalCategory))
                .Cast<Domain.Enums.AnimalCategory>()
                .Select(e => new { Id = (int)e, Type = e.ToString() })
            );
        }
    }
}
