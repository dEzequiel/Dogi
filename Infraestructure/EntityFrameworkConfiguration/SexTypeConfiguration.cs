﻿using Domain.Entities;
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


            var totalSexTypes = Enum.GetNames(typeof(Domain.Enums.Sex));

            int id = 0;
            foreach (var type in totalSexTypes)
            {
                id++;
                builder.HasData(new Sex(id, type));
            }
        }
    }
}
