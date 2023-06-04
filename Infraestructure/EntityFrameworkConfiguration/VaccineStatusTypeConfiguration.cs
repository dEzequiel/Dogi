﻿using Domain.Enums.Veterinary;
using Domain.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class VaccineStatusTypeConfiguration : IEntityTypeConfiguration<VaccineStatus>
    {
        public void Configure(EntityTypeBuilder<VaccineStatus> builder)
        {
            builder
                .ToTable("VaccineStatus", "Veterinary")
                .HasKey(x => x.Id)
                .IsClustered(false);

            var totalVaccineStatusTypes = Enum.GetNames(typeof(VaccineStatuses));

            int id = 0;
            foreach (var status in totalVaccineStatusTypes)
            {
                id++;
                builder.HasData(new VaccineStatus(id, status));
            }
        }
    }
}