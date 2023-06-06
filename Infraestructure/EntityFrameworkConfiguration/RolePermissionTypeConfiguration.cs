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
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanCreateAdoptionPending
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanCompleteAdoption
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanReadUser
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanReadAdoptionApplications
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanReadVaccinationCard
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanReadMedicalRecord
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanReadCage
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanReadPerson
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanReadAnimalChip
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Administrator,
                PermissionId = (int)Permissions.CanReadIndividualProceeding
            }
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
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanReadVaccinationCard
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanReadUser
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanReadMedicalRecord
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanReadCage
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanReadPerson
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanReadAnimalChip
            },
            new RolePermission()
            {
                RoleId = (int)Roles.Veterinary,
                PermissionId = (int)Permissions.CanReadIndividualProceeding
            }
        });

        /// Guest permissions.
        builder.HasData(new List<RolePermission>()
        {
            new RolePermission()
            {
                RoleId = (int)Roles.Guest,
                PermissionId = (int)Permissions.CanReadPerson
            }
        });
    }
}