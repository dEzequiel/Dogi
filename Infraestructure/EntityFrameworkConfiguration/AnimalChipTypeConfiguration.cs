using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.OwnsOne(vo => vo.Owner, o =>
            {
                o.Property(x => x.Name).HasColumnName("OwnerName");
                o.Property(x => x.Lastname).HasColumnName("OwnerLastName");
            });
            builder.OwnsOne(vo => vo.Address, a =>
            {
                a.Property(x => x.City).HasColumnName("City");
                a.Property(x => x.Street).HasColumnName("Street");
            });
        }
    }
}
