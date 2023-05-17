﻿// <auto-generated />
using System;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AnimalChip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChipNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.ToTable("AnimalChip", "Dogi");
                });

            modelBuilder.Entity("Domain.Entities.IndividualProceeding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReceptionDocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("ZoneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("CategoryId");

                    b.HasIndex("ReceptionDocumentId")
                        .IsUnique();

                    b.HasIndex("SexId");

                    b.HasIndex("StatusId");

                    b.HasIndex("ZoneId");

                    b.ToTable("IndividualProceeding", "Dogi");
                });

            modelBuilder.Entity("Domain.Entities.ReceptionDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasChip")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PickupLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.ToTable("ReceptionDocument", "Dogi");
                });

            modelBuilder.Entity("Domain.Support.AnimalCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.ToTable("AnimalCategory", "Dogi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Dogs"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Cats"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Rabbits"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Rodents"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Birds"
                        },
                        new
                        {
                            Id = 6,
                            Type = "Reptiles"
                        },
                        new
                        {
                            Id = 7,
                            Type = "Exotic"
                        },
                        new
                        {
                            Id = 8,
                            Type = "Farm"
                        });
                });

            modelBuilder.Entity("Domain.Support.AnimalZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.ToTable("Zone", "Dogi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dogs"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cats"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rabbits"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rodents"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Birds"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Reptiles"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Exotic"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Farm"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Quarantine"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Cure"
                        });
                });

            modelBuilder.Entity("Domain.Support.ProceedingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.ToTable("ProceedingStatus", "Dogi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "Close"
                        },
                        new
                        {
                            Id = 2,
                            Status = "Open"
                        },
                        new
                        {
                            Id = 3,
                            Status = "Adopted"
                        });
                });

            modelBuilder.Entity("Domain.Support.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.ToTable("Sex", "Dogi");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Female"
                        });
                });

            modelBuilder.Entity("Domain.Entities.AnimalChip", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.AnimalChipOwner", "Owner", b1 =>
                        {
                            b1.Property<Guid>("AnimalChipId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Contact")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("OwnerContact");

                            b1.Property<bool>("IsResponsible")
                                .HasColumnType("bit");

                            b1.Property<string>("Lastname")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("OwnerLastName");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("OwnerName");

                            b1.HasKey("AnimalChipId");

                            b1.ToTable("AnimalChip", "Dogi");

                            b1.WithOwner()
                                .HasForeignKey("AnimalChipId");

                            b1.OwnsOne("Domain.ValueObjects.Address", "Address", b2 =>
                                {
                                    b2.Property<Guid>("AnimalChipOwnerAnimalChipId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("City")
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("OwnerAddressCity");

                                    b2.Property<string>("Street")
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("OwnerAddressStreet");

                                    b2.Property<string>("ZipCode")
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("OwnerAddressZipCode");

                                    b2.HasKey("AnimalChipOwnerAnimalChipId");

                                    b2.ToTable("AnimalChip", "Dogi");

                                    b2.WithOwner()
                                        .HasForeignKey("AnimalChipOwnerAnimalChipId");
                                });

                            b1.Navigation("Address");
                        });

                    b.Navigation("Owner")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.IndividualProceeding", b =>
                {
                    b.HasOne("Domain.Support.AnimalCategory", "AnimalCategory")
                        .WithMany("IndividualProceedings")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ReceptionDocument", "ReceptionDocument")
                        .WithOne("IndividualProceeding")
                        .HasForeignKey("Domain.Entities.IndividualProceeding", "ReceptionDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Support.Sex", "Sex")
                        .WithMany("IndividualProceedings")
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Support.ProceedingStatus", "ProceedingStatus")
                        .WithMany("Processees")
                        .HasForeignKey("StatusId");

                    b.HasOne("Domain.Support.AnimalZone", "AnimalZone")
                        .WithMany("IndividualProceedings")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalCategory");

                    b.Navigation("AnimalZone");

                    b.Navigation("ProceedingStatus");

                    b.Navigation("ReceptionDocument");

                    b.Navigation("Sex");
                });

            modelBuilder.Entity("Domain.Entities.ReceptionDocument", b =>
                {
                    b.Navigation("IndividualProceeding");
                });

            modelBuilder.Entity("Domain.Support.AnimalCategory", b =>
                {
                    b.Navigation("IndividualProceedings");
                });

            modelBuilder.Entity("Domain.Support.AnimalZone", b =>
                {
                    b.Navigation("IndividualProceedings");
                });

            modelBuilder.Entity("Domain.Support.ProceedingStatus", b =>
                {
                    b.Navigation("Processees");
                });

            modelBuilder.Entity("Domain.Support.Sex", b =>
                {
                    b.Navigation("IndividualProceedings");
                });
#pragma warning restore 612, 618
        }
    }
}
