﻿
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityFrameworkConfiguration
{
    public class AnimalChipTypeConfiguration : IEntityTypeConfiguration<AnimalChip>
    {
        public void Configure(EntityTypeBuilder<AnimalChip> builder)
        {
            builder
                .ToTable("AnimalChip", "Dogi")
                .HasKey(x => x.Id)
                .IsClustered(false);

            builder.HasOne<Person>(f => f.AnimalChipOwner)
                .WithMany(r => r.AnimalChips)
                .HasForeignKey(fk => fk.OwnerPersonalIdentifier);
        

        }
    }
}
