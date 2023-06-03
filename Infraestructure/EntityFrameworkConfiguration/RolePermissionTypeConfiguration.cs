using Domain.Entities.Authorization;
using Domain.Enums.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration;

public class RolePermissionTypeConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder
            .ToTable("RolePermission", "Authorization")
            .HasKey(x => new { x.RoleId, x.PermissionId });

        /// Administrador permissions.
        builder.HasData(new List<RolePermission>()
        {
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanRegister
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanDelete
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanCreateMedicalRecord
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanAssigneRole
            },
        });

        /// Veterinary permissions.
        builder.HasData(new List<RolePermission>()
        {
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanCreateMedicalRecord
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanCheckMedicalRecord
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanCloseMedicalRecord
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanVaccine
            },
        });
    }
}