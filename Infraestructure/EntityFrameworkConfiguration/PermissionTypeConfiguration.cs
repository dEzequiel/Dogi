using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class PermissionTypeConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder
            .ToTable("Permission", "Authorization")
            .HasKey(x => x.Id);

        builder.HasData(Enum.GetValues(typeof(Permissions))
            .Cast<Permissions>()
            .Select(e => new Role()
            {
                Id = (int)e,
                Name = e.ToString()
            })
        );
    }
}