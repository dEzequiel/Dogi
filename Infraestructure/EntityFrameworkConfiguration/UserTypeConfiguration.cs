using Domain.Entities.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("User", "Authorization")
            .HasKey(x => x.Id)
            .IsClustered(false);
    }
}