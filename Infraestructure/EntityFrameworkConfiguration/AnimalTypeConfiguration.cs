﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class AnimalTypeConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
                .ToTable("Animals", "dbo")
                .HasKey(x => x.Id)
                .HasName("PK_Animals")
                .IsClustered(false);

            builder.HasOne<ReceptionDocument>(f => f.ReceptionDocument)
                .WithOne(r => r.Animal)
                .HasForeignKey<Animal>(rd => rd.ReceptionDocumentId);
        }
    }
}
