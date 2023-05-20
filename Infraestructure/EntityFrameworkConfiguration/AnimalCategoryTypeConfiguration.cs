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


            var totalAnimalCategories = Enum.GetNames(typeof(Domain.Enums.AnimalCategory));

            int id = 0;
            foreach (var category in totalAnimalCategories)
            {
                id++;
                builder.HasData(new AnimalCategory(id, category));
            }

        }
    }
}
