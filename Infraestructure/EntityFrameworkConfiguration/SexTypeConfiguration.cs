using Domain.Entities.Shelter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class SexTypeConfiguration : IEntityTypeConfiguration<Sex>
    {
        public void Configure(EntityTypeBuilder<Sex> builder)
        {
            builder
                .ToTable("Sex", "Shelter")
                .HasKey(x => x.Id)
                .IsClustered(false);


            var totalSexTypes = Enum.GetNames(typeof(Domain.Enums.Shelter.Sexes));

            int id = 0;
            foreach (var type in totalSexTypes)
            {
                id++;
                builder.HasData(new Sex(id, type));
            }
        }
    }
}