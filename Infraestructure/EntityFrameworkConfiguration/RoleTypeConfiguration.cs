using Domain.Entities.Authorization;
using Domain.Enums.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class RoleTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .ToTable("Role", "Authorization")
            .HasKey(x => x.Id);

        builder.HasMany(x => x.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();

        builder.HasMany(x => x.Users)
            .WithMany()
            .UsingEntity<RoleUser>();

        builder.HasData(Enum.GetValues(typeof(Roles))
            .Cast<Roles>()
            .Select(e => new Role()
            {
                Id = (int)e,
                Name = e.ToString()
            })
        );
    }
}