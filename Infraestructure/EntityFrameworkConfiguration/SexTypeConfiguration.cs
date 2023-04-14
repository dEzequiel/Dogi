using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class SexTypeConfiguration : IEntityTypeConfiguration<Sex>
    {
        public void Configure(EntityTypeBuilder<Sex> builder)
        {
            builder
                .ToTable("Sex", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasData(
                Enum.GetValues(typeof(Domain.Enums.Sex))
                .Cast<Domain.Enums.Sex>()
                .Select(e => new { Id = (int)e, Type = e.ToString() })
            );
        }
    }
}
