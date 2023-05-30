using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init2jk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dogi");

            migrationBuilder.CreateTable(
                name: "AnimalCategory",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalCategory", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "IndividualProceedingStatus",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualProceedingStatus", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecordStatus",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecordStatus", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "Dogi",
                columns: table => new
                {
                    PersonIdentifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBan = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonIdentifier)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "ReceptionDocument",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasChip = table.Column<bool>(type: "bit", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionDocument", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Sex",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCard",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCard", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "VaccineStatus",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineStatus", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Vaccine",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalCategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccine", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Vaccine_AnimalCategory_AnimalCategoryId",
                        column: x => x.AnimalCategoryId,
                        principalSchema: "Dogi",
                        principalTable: "AnimalCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonBannedInformation",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonIdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonBannedInformation", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PersonBannedInformation_Person_PersonIdentifierId",
                        column: x => x.PersonIdentifierId,
                        principalSchema: "Dogi",
                        principalTable: "Person",
                        principalColumn: "PersonIdentifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalChip",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonIdentifierId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceptionDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerIsResponsible = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalChip", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_AnimalChip_Person_PersonIdentifierId",
                        column: x => x.PersonIdentifierId,
                        principalSchema: "Dogi",
                        principalTable: "Person",
                        principalColumn: "PersonIdentifier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalChip_ReceptionDocument_ReceptionDocumentId",
                        column: x => x.ReceptionDocumentId,
                        principalSchema: "Dogi",
                        principalTable: "ReceptionDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cage",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AnimalZoneId = table.Column<int>(type: "int", nullable: true),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cage", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Cage_Zone_AnimalZoneId",
                        column: x => x.AnimalZoneId,
                        principalSchema: "Dogi",
                        principalTable: "Zone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaccinationCardVaccine",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccineStatusId = table.Column<int>(type: "int", nullable: true),
                    VaccineStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VaccineEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationCardVaccine", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_VaccinationCardVaccine_VaccinationCard_VaccinationCardId",
                        column: x => x.VaccinationCardId,
                        principalSchema: "Dogi",
                        principalTable: "VaccinationCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationCardVaccine_VaccineStatus_VaccineStatusId",
                        column: x => x.VaccineStatusId,
                        principalSchema: "Dogi",
                        principalTable: "VaccineStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VaccinationCardVaccine_Vaccine_VaccineId",
                        column: x => x.VaccineId,
                        principalSchema: "Dogi",
                        principalTable: "Vaccine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndividualProceeding",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceptionDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VaccinationCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndividualProceedingStatusId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SexId = table.Column<int>(type: "int", nullable: false),
                    CageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualProceeding", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_AnimalCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Dogi",
                        principalTable: "AnimalCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_Cage_CageId",
                        column: x => x.CageId,
                        principalSchema: "Dogi",
                        principalTable: "Cage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_IndividualProceedingStatus_IndividualProceedingStatusId",
                        column: x => x.IndividualProceedingStatusId,
                        principalSchema: "Dogi",
                        principalTable: "IndividualProceedingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_ReceptionDocument_ReceptionDocumentId",
                        column: x => x.ReceptionDocumentId,
                        principalSchema: "Dogi",
                        principalTable: "ReceptionDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_Sex_SexId",
                        column: x => x.SexId,
                        principalSchema: "Dogi",
                        principalTable: "Sex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_VaccinationCard_VaccinationCardId",
                        column: x => x.VaccinationCardId,
                        principalSchema: "Dogi",
                        principalTable: "VaccinationCard",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualProceedingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalStatusId = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_IndividualProceeding_IndividualProceedingId",
                        column: x => x.IndividualProceedingId,
                        principalSchema: "Dogi",
                        principalTable: "IndividualProceeding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_MedicalRecordStatus_MedicalStatusId",
                        column: x => x.MedicalStatusId,
                        principalSchema: "Dogi",
                        principalTable: "MedicalRecordStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Dogi",
                table: "AnimalCategory",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Dogs" },
                    { 2, "Cats" },
                    { 3, "Rabbits" },
                    { 4, "Rodents" },
                    { 5, "Birds" },
                    { 6, "Reptiles" },
                    { 7, "Exotic" },
                    { 8, "Farm" }
                });

            migrationBuilder.InsertData(
                schema: "Dogi",
                table: "IndividualProceedingStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Close" },
                    { 2, "Open" },
                    { 3, "Adopted" }
                });

            migrationBuilder.InsertData(
                schema: "Dogi",
                table: "MedicalRecordStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Waiting" },
                    { 2, "Checked" },
                    { 3, "Close" }
                });

            migrationBuilder.InsertData(
                schema: "Dogi",
                table: "Sex",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                schema: "Dogi",
                table: "VaccineStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Done" },
                    { 3, "NotNeeded" }
                });

            migrationBuilder.InsertData(
                schema: "Dogi",
                table: "Zone",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dogs" },
                    { 2, "Cats" },
                    { 3, "Rabbits" },
                    { 4, "Rodents" },
                    { 5, "Birds" },
                    { 6, "Reptiles" },
                    { 7, "Exotic" },
                    { 8, "Farm" },
                    { 9, "Quarantine" },
                    { 10, "Cure" },
                    { 11, "WaitingForOwner" },
                    { 12, "WaitingForMedicalRevision" }
                });

            migrationBuilder.InsertData(
                schema: "Dogi",
                table: "Cage",
                columns: new[] { "Id", "AnimalZoneId", "Created", "CreatedBy", "IsOccupied", "LastModified", "LastModifiedBy", "Number" },
                values: new object[,]
                {
                    { new Guid("00e83ea1-8a8b-4d29-9b6b-d96f6966fc16"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("0110a2d3-b977-47f4-b54b-e7efbe659fda"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("0183a62b-77cd-4773-8914-1ca5f3be6c64"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("01a88eab-f01f-4e32-b060-3bc9e5c7f8fb"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("02068eab-63d9-4758-a3b9-c1dfa0262a9d"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("022f2333-f7cd-47bc-a6e3-f949a9df6118"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("02952115-d04d-4990-881e-aff2e41f99e7"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("03499bc3-904d-445d-9dec-f7069aa7bd75"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("03a33e93-f84b-4304-846f-05b8b6488e72"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("03a3af2d-ecbe-40aa-9cdf-c45403b87d9b"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("03a6116f-7bed-403b-930e-03626fa8f6ce"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("05e2e749-a79d-45e6-b9f5-f65b06c0f729"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("060095e0-5637-49fe-85d7-120995c2e10b"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("06ac8a30-27c0-4f30-a1f7-623119c223f5"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("06ecbce9-7d4d-42bf-8bfc-5de22058b1ec"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("07762923-e482-418d-9b37-4ec47457357f"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("0801298b-ee69-41b7-a80e-5de7ff1509f8"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("088b150a-7ab0-45b2-9ee4-cdba5a442a7b"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("08e5a282-dc72-4f4f-8803-e82db808c12b"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("09064577-15f4-4da7-8638-50167afdd43f"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("09967f41-0d32-47d6-8ae2-e068695f0e4c"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("09a822cf-2395-4d5e-b0ee-7876ea59d63f"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("09fc6ba6-08f2-4e50-b1d6-4c3965e89a9e"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("0c715d4a-b36d-4ac2-bd9d-8830b866cf4f"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("0cc5a4cb-6810-4085-9ae2-3c2033d2f3f4"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("0d00944b-289a-41e3-9a4e-16401457f094"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("0d2b1a19-63c9-4db7-b19a-e042a80a698e"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("0e0e58da-323b-49e8-8ff9-19c35480f1f2"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("0e2d6839-e3fc-42d6-80b0-5aca8d6aa28c"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("0e75c663-9b89-481d-bb6b-101b98208683"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("0f29f4dc-5b77-4397-8284-2278f86b37af"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("0f2cf5eb-e63e-4b45-ad2e-55005f105da2"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("0f521075-c9dc-4a6f-a0f8-47d608462c3b"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("0fd20f43-6d4a-4aeb-b981-a18133570478"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("10f7aaaa-49d5-4706-9ab7-d1f6a246ff65"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("11139d76-32e1-4446-94f4-c38f2e5a1064"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("11cd46e2-b50b-4665-8fc7-11b4caa55a0d"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("12799622-57fa-418d-ac34-bbe09c806b6b"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("1355627a-99b3-4d67-b3c6-98b33ce0c64c"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("135d0d11-c810-4276-b458-21488e752ca6"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("1378d0f6-7287-4d2b-a5f7-0e80fb2ab45d"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("14aafb45-14f4-4c2a-ae64-a5b3e042d72e"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("14ea2f32-868c-4448-a2c5-f1e3c635a639"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("152e7dd7-1f65-4b18-9e9a-e83f26108363"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("157515cb-5172-4ce0-9305-f68a0a490da6"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("16ac2a62-1c73-4dca-ba1c-5bb5dd232285"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("172951bd-6e0f-485a-99f0-0bedbca30bb3"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("174d668a-6ab7-4c9b-98a5-66e48082ade6"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("17d9e691-004e-4c19-b54d-b9c35467e67b"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("183ab5ef-171c-43c8-b083-e93c85b0533b"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("18763cc7-629b-4b32-9397-5e2868138553"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("197ba686-ad7c-41c7-9bb0-e6f86df8be56"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("1996a64f-9425-4d65-894d-42ee42e35c09"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("199a13af-9f01-4bfc-a80d-84391420d07b"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("199e36ce-5202-4d6f-a587-5da9ae41feca"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("1a341c06-0ea9-4119-a90f-3b0d2e576d10"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("1a532c8d-c08c-4f8d-a319-afb6587f0827"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("1a85499f-8320-4d89-b05e-25a1c689aad9"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("1aa4f6d8-0ea0-468a-82c2-4fa600e80c2b"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("1aa7d1f6-aa67-4739-aece-b5710b87899f"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("1bee29f3-cccc-4e28-aa17-02de1e54adb7"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("1bf2c6ac-3dad-436e-99d3-f01da88d6fb0"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("1cb54468-82b4-4dee-9d75-2787f2101f86"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("1d16c142-0df4-4494-b44d-39d4ac7571da"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("1d383e60-f5a4-4532-af91-e215676e1103"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("1e0a6cac-8f2b-4499-ac04-311936981a54"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("1f19770b-2a22-4958-90e7-472536445821"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("1fe45d3a-052c-47b3-b576-8591816ece81"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("2025e5ba-282d-499b-9e8e-a74fe467a895"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("202bbef4-2ed9-4427-9a80-a5f62057c20f"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("20d069cd-189a-4284-8d85-49901cf8d30e"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("20e27ece-7efb-4839-98a8-375105d66dae"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("2121070d-e0c0-4491-b653-695748565c95"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("2157296b-013e-46ea-b547-21f78788f61c"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("2224c49e-2b1c-4b3a-a1da-5b8613c81657"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("22582552-adc1-4e9f-b281-7e0226086cd2"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("2271f862-9e12-4c9c-a9db-4496d919112e"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("24b734fa-9535-46c5-b825-3dc3aa7c3e61"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("25fa2862-51e2-4043-b5a7-d60a7fa6e757"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("2604ad63-b254-454e-b394-45d548a456c4"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("27be2d4a-d56f-4dca-b1f7-04ef36786a6a"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("28526f24-6008-44e2-8090-ed95ccc80411"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("29666b6c-410e-4e94-8a73-314956a0f81f"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("296eab95-c9cc-4801-94d0-0e569e30642a"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("297e4780-bea3-4808-bb0c-a98ce862e994"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("2a3dc76b-12f8-4765-a590-db329f883799"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("2acd2daf-7547-4b72-bb23-52ae232e092c"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("2b0d1b39-7a04-441e-97a4-4307dc3730c6"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("2bf02b50-f087-46ec-bfca-3992e146abc8"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("2db4c0b9-e551-4e7a-b386-1bf96c7d2f5d"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("2dee4525-c067-45c8-80cd-d11e75e604d8"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("2e0aee5b-fc62-4998-84bd-87b8ec860645"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("2e488f99-de91-4c6d-b857-0bd31244185d"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("2e4b08cb-a2c8-4337-ae5b-5299335075b8"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("2e9a3684-d0c3-407e-952f-c37722027ae0"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("2f18a336-28d3-4eba-8d79-acf6ed166f15"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("2fd714af-cace-4bb9-b908-c0f5dbf0247e"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("3291d86c-1472-4b49-ab04-1dc723916a15"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("32d1520a-2c95-4eb6-b654-ff3c6eae2bf1"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("33057bcb-d839-4bd4-8bbf-736a9b89e56d"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("330b0920-744d-4307-b344-50789f080eec"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("333860a7-0d0c-4b87-97d3-1e7dc46a8b44"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("33473f2a-4744-4b90-b5a2-661cbb760f24"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("3353c24e-a5b0-4c1b-8a47-12574f3c6d36"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("33815de2-e195-4d64-8dc5-d15188762da5"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("3392f9b3-da1d-4291-9bbc-fc505b7bffc2"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("34e44e14-88e4-426a-b480-40f240b498ae"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("34fc5e1e-e82a-4010-b58e-11896e4a718b"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("355e9d01-9135-48a2-a371-c98b7a3b88c6"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("3567959b-03aa-4e82-8857-d4bcad0562a3"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("3569690f-6601-411b-b5ac-7f0b71c39d09"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("3577ff35-b634-487a-a8b5-1b7925267df2"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("35d8a62e-4b93-4c1a-8992-12057cce3775"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("3627da33-3009-4f2a-8a9d-44cc60af969e"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("36e884b0-fb1d-49d3-86e1-ed8e953790af"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("37a50a16-b051-4fbf-8857-22644ff57833"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("3814af15-f22e-4331-89fd-4272ce527afa"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("3909b3fa-99c4-4528-960b-dc64525e9c18"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("3917a14b-ab9e-40e5-b30e-022d0af8cdcd"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("3a3f13e5-cef9-46b1-aa16-5e8ea7254cd3"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("3a7963ed-e3a5-4fe4-9384-312ceca0c76f"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("3aa8687c-5600-4604-9d5b-e7ff5d2b95ff"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("3b6807a7-8289-40ef-98b6-1a415bd74d23"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("3baaae13-2caf-40e2-94e6-b66d5640e1ee"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("3bdd60e1-026b-463c-a1e2-5861e8854bbf"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("3d8c2fd2-df7e-4003-bac7-497fdc8831d9"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("3d98e291-7136-4c2f-a6f6-df00dd467d5e"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("3de0d5bc-debb-4dd5-bc36-c298cc1d0943"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("3e1d9399-cd17-47ca-bd32-7623eefdd5ef"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("3f0547fa-65ab-4e3a-8074-7fb79739c943"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("408385fc-e043-465b-af2d-1ad69701c372"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("40b18ff9-080d-4c28-a752-7cadd043e5b5"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("40be4f7a-9b75-4b32-8d79-f0d8b7705d99"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("40c81099-9915-470c-b7c9-57f4bd0348cc"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("40f927ea-2769-417b-9adc-c2dd69145f92"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("41075e15-2d37-4c4b-b02c-5b64612f4253"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("4162a68f-ed93-4ea6-a4b0-b045588e798b"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("42ae01e4-23b7-4cb7-9cfe-29143ce2691e"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("42d272db-16fd-4730-ad68-b8c0ce88cebd"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("43fcf6c5-2d8a-4b2e-87bc-0969427c990e"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("4489cb09-9fae-4ac3-9a7f-77e0786a8866"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("458cb13b-0dac-4501-b935-bce3f0840725"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("46b4399f-5f05-4d84-96b0-d5395048fc4a"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("46be83a5-3c62-49e0-9286-c0008e02b82b"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("4762f72d-b0f3-4104-a6bf-ab13990c8ee2"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("4765a7a0-c5f2-40fb-9fee-eaccfe3103ef"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("47fc01b7-99ff-48a0-a28f-df7df23d469f"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("48674a66-52b0-4e3c-a713-823586fea63b"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("4877eb9b-3845-42df-a83d-a5fbefb17e44"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("489a7672-09c7-4652-a47b-9c2a87b8009e"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("48f31393-7a08-463f-8ae5-b89ee027640a"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("49167e44-89e5-4f3a-bfc5-33b11ae66986"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("49780c6f-e14a-4f70-a077-2d07ab2c1951"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("49831784-03e5-43fe-b68c-829ad7223235"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("4a1718b8-c214-4b9d-97f5-ef69371dee1f"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("4ac6ba39-c061-461b-b64c-75450b2fee9f"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("4aec89f4-dddc-49b4-9dda-832609557333"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("4b4bdad0-a158-4271-b5aa-6c49f8999651"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("4bd22b74-479d-4bf2-8c8e-472abee0a1dc"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("4c5a3a86-a062-4d0b-b947-f3cf6ad9b414"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("4cd1a9ac-b2aa-4b0b-bb9b-c55e06cd3d7a"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("4d037535-3742-463f-85c7-31adf0cb322c"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("4ddb8d7b-ec7f-4f34-81b1-65569541aee0"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("4e42f8a2-8dec-4b51-925f-384ec688d827"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("4e91f8a0-f781-42ad-9b6f-9420374c05b0"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("4eb00234-a2c5-4f66-bf62-744e93fabd42"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("4f5f9916-6311-4326-b25f-988283c4f028"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("4f6af8bd-1d06-4c79-8a7f-9086c3c1c7c4"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("4fa5a9f8-82df-46b9-988d-c04de328e2ee"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("4faa43c0-80f6-46f5-a744-3a8caf17abe6"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("50008a8e-6c6e-48bb-855c-57564a3b7625"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("503e78c2-08ed-4b65-bb1e-18a180e136c0"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("505cea8b-1ffd-4943-8135-476f37053cfb"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("507e4c1a-2a40-47d3-881d-2fb844097cb3"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("50d3a687-8f3e-478d-a367-f760f4771f32"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("510ea3cf-594e-4b11-9c71-a5b2b1c3a89a"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("515f466c-0bba-47b2-b871-f8d9def3e88c"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("5165f0cf-a404-407b-a133-0b41e902ebbd"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("5189bb78-55b0-4b39-b4b7-3dc49d3c4808"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("5206f5d3-f476-43c6-814a-c5de4b678ba3"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("5258f89d-6723-40da-8935-7228c879bee2"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("5273a6f3-99be-4f4b-9777-29cdf4ee09fc"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("52b346fe-264e-4ad1-8e78-949e49c5bde1"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("52d072ea-4d25-467b-8f5b-c6d1e796d4fb"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("534a88ae-a6c9-428f-980e-0b9838667a19"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("5364a44b-92e9-4686-998d-1939499cd373"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("53988d50-26d7-4627-8ac8-9a2d949a1ec9"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("53ef91ab-117b-478c-8c99-9ba68b288c98"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("555959d3-f6bf-42e4-b5df-0ca4dea92b39"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("559a65cf-1589-4623-bf79-005737b9358b"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("559b0140-c4aa-4a49-9c46-07afe6857d46"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("56ac6bd6-212b-4eed-8192-438c52f653ec"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("56eb2934-6282-463f-a342-c4c71b47f9c2"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("57119d8f-e479-4991-90f6-154ce3ebb263"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("5811b74a-2664-4be0-bc20-352424f3ad4e"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("584e235c-6aff-4390-b2c1-dc219226dea4"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("585663e8-6060-44f6-a902-0faa4ecc5458"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("59112526-d4e7-471e-82af-acd304040cdf"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("5943bad2-d821-4e46-b749-b02985289ab2"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("5988b44e-1196-44ed-a669-87c301cb64e2"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("59bae586-309a-4752-b535-11f391c1f4a9"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("59d8459a-1823-4474-a090-2138090ae549"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("59f0ac81-d0a4-41a7-866e-4c622e051414"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("5a487891-c4e1-439a-b807-f495b0ce0761"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("5afc819e-7c5d-4685-921d-15ae3f56e269"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("5b05d38b-3b5c-4dc5-a939-1b6d65fc6913"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("5b4baac9-65de-466c-bc2b-d804831265c3"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("5c34284e-3abb-4678-a614-413144bb7ea4"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("5c560db7-98c2-4955-8c9a-ba6be5cc2939"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("5d2ec285-8a3e-4667-bc32-3cdd7549da6a"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("5d87d470-8003-4d90-8a0f-715bc97485b0"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("5dc85c5b-93bf-4c99-99b8-e053e03a8d50"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("5e2d1e80-0ca3-43b5-8df9-bae4e3809bec"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("5e6cc8f3-46af-42b9-84a2-f971b4df72a9"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("5e8749a5-45fb-4a71-b0eb-4184133a3574"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("5e9c0d46-cbc5-45c6-a261-c4c675fca28a"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("5f43fd3a-9cba-4f14-a332-cc7535b2c102"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("60591da0-30b3-4d94-b630-fce65e3ce1db"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("6071b2e7-a8a5-4164-a743-c6e4c07bcafd"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("607cfceb-504a-4167-85d1-9917d90c6b69"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("60a2512f-543d-4b28-b73c-da6f19ec06d0"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("618d759e-3416-4c23-9bd1-52dd33fe4e3e"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("61a75d10-3937-41b7-80b9-9a3870a347e3"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("6268b93a-9936-4452-ae7b-f7b149c6af9b"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("62a0c417-b19b-4a1c-bd59-9fd7f1e57f8e"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("62b9ff03-2f78-4c1c-9441-fba7c62bcc2b"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("62fbd000-0468-4205-8568-c38469b4c191"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("6319a2e3-c4d9-448a-bb43-aed0d1faba55"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("641e53f7-2105-4346-8859-65294aac6c37"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("642df5b9-da04-4e94-8fef-2c7053921e99"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("65d2ffca-6bc9-46c2-9e8d-ec034accdc43"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("66346d4f-ab15-4511-9b3d-975be011631e"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("66c7ff9e-400d-4826-b093-4dd4ea2ad9cf"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("674146c9-92ef-466c-b0a6-b8fba20c1175"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("67640e57-9f37-4b3f-bd39-18768a8b38fc"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("67b63a1c-8d32-43b7-b63e-6d57d910937c"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("67d4378a-b37f-45a8-8146-9d49b232d87e"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("689c3632-1561-4f7d-8043-5bd1cef756eb"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("68e83d80-2f8c-47f1-95c9-4d97de7b025b"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("697743de-b4ed-4c3f-be17-8e1fda07c94c"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("69868207-6306-4592-8aef-66d5ec8f0e4c"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("69ee17d0-f5c7-44cc-9315-b6b841e4660c"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("6ab13f3b-c77a-4996-86cc-7d666eaaee08"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("6abe3b29-580b-4a7e-aafa-edeb39aed0af"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("6b3067a6-68a0-4a62-b66e-f9b998e9d1c0"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("6b49c3e1-2e22-40a8-bb58-74afabc71121"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("6bc5c308-9daf-42c0-8e4f-957405b56bfc"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("6c29e868-8f5b-49de-8cc6-49e2b2f09672"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("6c5c3e0c-fe9b-443c-96c0-dfb171b98556"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("6c8a0a28-7fa6-4b7f-bf62-5ee6e139330a"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("6cb98b1e-12f2-4bf5-88b0-901543787365"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("6cc41950-4238-4fbf-b9ee-d356b4e7fc16"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("6d5e6232-b9ca-42d8-9b9a-d17e927badf5"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("6dc0c45b-b4fb-4b0d-bdb3-2e65d9e3e90d"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("6de46a7d-dfb4-4a3d-9b36-d49004462b1c"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("6df54965-61b9-4df2-ba7f-c6724102f5c5"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("6e2c5d87-7dee-4e6d-b5a9-3bedf00099c1"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("6e3a3b70-4db9-49cd-aefe-27f438285e9d"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("6e48bc41-c35c-436d-b988-6304b20e4822"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("6e85fde2-850b-4800-8afe-9fdb2656a6b1"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("6f2731ec-0332-42c2-9c34-01b43d19ac92"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("6fd2d8ee-323e-4eba-93f9-1085a72784ba"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("704a73cc-a281-4fba-82d9-06bb91074d0c"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("72d869bc-5b01-43f5-9643-2c965192bd1e"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("72dfe22e-7fb2-4d1a-8229-f3b373785d28"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("7302c4d6-65c7-4cd4-b814-7ea1c46d8984"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("7338425f-96c5-4c4f-8a29-80ec2a64e8e0"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("73734655-9d4e-40bd-846f-d74a9e6c1854"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("73f591a3-f37c-43b9-a986-6dc0cea7b4d8"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("74497d68-05d4-4355-b4fa-c05731c07ba3"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("7459f78f-8998-4c74-a9c7-4d06f0344f0d"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("75236ba0-88b7-4412-a65b-32d872c90dea"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("75284961-1fae-45d4-a1d5-892067605d52"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("75396019-1a06-44b9-b863-1d48807de4ef"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("75582a98-47e1-4694-a160-6c9c001e2a29"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("75c5052a-349e-47b2-815f-0717e9d8fa3b"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("76c75cc4-0777-4d43-98d3-700716a0d0d2"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("778105e8-0510-46ad-a0dd-c9651c888939"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("77970862-902c-4951-a320-1621d0ec610b"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("793ca290-2261-461f-8203-d2bd358fe3f0"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("79ffe35c-6941-4c80-924e-7fa938691227"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("7ae4bb61-bfd1-4cee-8dcb-02a284eddcd1"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("7b5807d6-f709-4957-853c-1f8312286cb2"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("7bab5c4c-5be6-426e-9d16-5e063b03500a"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("7c4dd245-6979-4834-abf2-9461e0554c0e"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("7c75196d-4fe1-4765-b071-f1e6196a550a"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("7ceceec0-c74c-44af-9d05-6cca1c3bed1e"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("7dca3afd-3e8f-4ac9-9f12-37f50ff5e989"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("7e393dac-d911-4bf8-ba4e-0084086cfd06"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("7eb27f2b-4259-41ef-b1a3-bacf93f649d2"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("7ec62ab3-84f5-45db-9815-355d01b0c2da"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("7ef89f89-f530-4a6b-b9f1-42eb399149f3"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("807f0718-0a17-45b0-9965-5e2156037f03"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("809d21be-73a2-455d-bcc6-278e524e306b"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("81c47b05-9cbc-4fe7-bdad-ddf0c3372ff6"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("81f07b98-3999-445b-8f56-401a564daadd"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("826b581f-7314-4617-9994-6f4a381264c8"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("827bb1a8-81b4-4f0e-bdbe-da38b960687d"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("829fbbf7-e6f0-469c-82a2-e74a5f14f07e"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("82a91357-bb6d-4fd4-a270-3211622c1190"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("82c103c5-a199-4e0a-810a-a47abd4f9a65"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("834aba54-1808-406a-b961-ba4b9fda8ac0"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("834fdf9d-442d-4151-87fd-7f99e3284f62"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("8372f151-50fb-427d-8730-7ead738d4e48"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("83a48573-c79b-48aa-a43a-393fa42ede52"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("8419dafa-41b6-4ad9-9b3c-302aec7d24eb"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("84560d51-57f5-4d5c-88db-4022dbd33fde"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("846dce1b-1c33-4239-8890-26b44e392d6a"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("8512fe56-227b-468b-b7e3-973d6654355b"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("85371d82-cfe6-4b3f-ac86-790d43d6212f"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("861f04d7-919d-4c09-9b2e-858a26b7a808"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("870ad615-22b4-42c7-8f55-abddbf5727ed"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("8758814f-51d4-4e09-b35c-3913b20a51e3"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("876b3f23-4990-4dc0-bc85-e382c15a0599"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("88226d2d-6a4a-4f3b-9181-cbc1a43a8f61"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("883dcbfa-2fca-4f43-9ec1-15d283330a45"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("88746f95-181a-4ed0-a53c-9c5e17091436"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("88ae24fb-3097-4930-986d-4d55d56865da"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("88e1d4fd-f186-4816-b6f7-bbb172af11ef"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("89ed8ac4-1d8d-4a03-b530-83d994de838a"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("89eed9f3-c7d1-45a0-af28-205d503b1509"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("8a2635fd-dc81-47a6-894c-affab498f44e"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("8b3648bc-5cc4-4ce2-a2e4-cc0c1f2882a3"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("8c0fc8e3-d08b-4535-b2bb-5b959874fdc1"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("8c3c62d8-3f65-4e19-b1bc-398c565f5b40"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("8ca6ef37-cb9b-4ab9-a06f-1316b362d30e"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("8d96d6a8-d89e-48b6-b70f-713f877cd0a5"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("8de6d8ec-50f4-4925-b474-dcb08b35e326"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("8e064fec-8d6f-4349-860f-0f15f151ef3a"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("8e0bb89c-0f6e-4dd8-85a4-6a161b05a4ae"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("8e2ee62d-517e-4333-ad65-738ec8b2bc29"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("8e305303-32ce-4555-af9d-f60313c2760a"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("8f756f14-0015-446c-a960-2f741692228c"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("90b05437-84a7-42de-bf6d-175fe6a043cf"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("9136eac2-9c87-403b-909d-51b763df0690"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("921fb845-f643-418c-a17d-d4528520b5a8"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("93ee0520-0242-4a88-bb2b-00e0969ea4e6"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("94b10449-8ee1-4d72-9c83-b4be61f9645f"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("9541f78b-2500-4a90-b998-49b2e3f7ee95"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("956827bf-8085-4431-b1b3-ddf7cb92e912"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("95b5141d-be5b-4023-b808-2e80911b018d"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("95f02061-fa06-45fb-bcea-924c0a88fef9"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("970abe06-a531-431a-afb5-4bd6cd424dcf"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("97f8336f-a513-45cd-862e-6fb1c87883c3"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("982d7ca7-4c4e-4c6f-8207-e52c8aeda821"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("9865de71-ff82-4144-b554-b6967226b10f"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("98731b34-3649-4c09-9bcd-8eaa0f709e66"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("99255160-679c-4c7f-af08-5b71c18b1c79"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("99e32a01-3161-46eb-ae7b-d27c70f367d4"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("9a136d50-0473-4c2c-a548-8550d58c53fe"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("9a24042d-4089-45f3-b45f-eb1fc0fbaef4"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("9aff19b9-a0e0-462b-95ad-d95c716f7d8c"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("9b5e8b7a-8a60-4be6-ad2c-10bc675095b4"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("9b91721b-db3d-4d6d-ad16-c8e5539b9876"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("9bbb5e40-6de1-402b-82dc-21aaf707b43e"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("9be56f81-87bb-4a5a-9dc5-26adc947a15a"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("9c5f14c7-9ef9-405c-a662-aa681854aaec"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("9cb094c3-ef95-41b6-bf2a-160580e2ad09"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("9d1d0163-a7f9-4750-a5b7-ea33963c8d92"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("9d303c92-fe74-47ef-a941-257ee441f08f"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("9d9d35ab-4a48-4fad-8770-5339e081e724"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("9da0e605-6ee3-40ab-b46e-c19d864a6175"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("9da38aee-00b8-436d-b5d2-263ecec7b676"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("9e675659-1188-4090-985f-239716ccf2bd"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("9e7a2f83-7d29-4c6c-a1e3-d602410e5b77"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("9e98c4f0-5670-4a1f-a5a7-55011c3c13ce"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("9ec00829-efb3-4267-afec-e1bcde4694b0"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("9ec6fff8-d573-4d9e-900b-c0005c8a2b91"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("9ee2ba6c-d730-402d-9831-55145c6a04fd"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("9ef8269c-4042-4e10-b5dd-16e5c407096d"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("9f8f9e51-6df6-4152-bde9-e13d1bab7861"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("9fd0f32d-f246-4b46-a382-4296e844756a"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("9fdfc623-8011-407a-b2b8-6b5479e2c18a"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("a0249e8a-e6a6-49ed-8a1e-dc1aa08dbacc"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("a09ba60d-14d9-41a4-b26b-445ce7a8a9fd"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("a14be8e1-4e00-4e19-bd87-2cac2b5937b4"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("a1a6577e-1bf9-4b3e-85f0-e9967b66268d"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("a1c844d5-5f57-4c34-a71b-b3f56f41a61d"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("a1d0eb1f-1edf-4ebd-b37a-53926b4f5de4"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("a2e8306f-277a-48a9-b29b-73869b910451"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("a30c8e2e-813a-4a76-9e87-5bb469859818"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("a381da51-f449-4f6e-876b-090cc7c64823"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("a3e15767-d7b3-4b7c-be15-f7e13dfe8ee2"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("a4079529-72a5-4cbe-9412-9032a3a5864a"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("a46063d3-4d49-4ef5-b7aa-831b7d370515"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("a463dafd-41ff-47e2-912f-8decc9f681b9"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("a56b0795-ca42-4130-9ddd-19e1faacc300"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("a5a536e3-28b9-4d23-aa4c-c249a47f8592"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("a619459e-ad12-4fc0-ae6e-c1c0a1fea43b"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("a66d9581-c470-4824-85b1-1aea20404680"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("a68ab602-1647-47f0-9d1b-df5fa1b09b4c"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("a6b7ef49-35eb-4d52-9a81-2a01cc2a5755"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("a7069cdf-04a2-4055-bd15-6610c01a2a8c"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("a728843f-1497-4edd-9d1a-b1269e174b9e"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("a74b7a13-8b2a-42f2-8ac2-f377fa3d3643"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("a78fa900-e4d2-4bf6-9ebd-290d26302279"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("a7d787ed-6d3a-4293-abe0-044d41e52192"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("a8352988-bde3-43ea-a4ed-26ebb078a5be"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("a86b46f5-7747-43dd-ad9d-881781d8b2b0"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("a8a3db4e-a6ab-473a-afc0-f5efa1c8dcaa"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("a9053b10-7371-4591-97bf-d0e274999357"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("a9b63002-68b1-48fe-8864-3f7794c14a3e"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("aa1e1e54-2421-4636-a49b-37f02c442130"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("aa3b6bfe-f7f4-4de5-aeba-9ee1a60c588b"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("aa723ac4-d6fd-48ec-b917-8d6eca38ed0f"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("ab3cbe46-4ac7-4a00-be53-47c2f2673549"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("ab487997-1cf6-4f02-850f-95f70a3b6aa3"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("ab82bf6f-a277-411b-8145-e12befb160a9"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("acd8c925-0cf2-40af-aa78-3edf8b850b8f"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("acd9562a-023d-49e1-8200-b039fe6a9004"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("ace6d359-fa94-4129-9819-ab48c962ca5a"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("ada5d5a6-4272-4085-acb6-f3d68806ea6b"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("adbed9e7-eab0-42ab-a159-7f13a7317c08"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("add4ebd2-57fb-4cf3-a789-687098302722"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("ae94c72c-370b-4e39-9e20-f1541363cf01"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("aef5a281-8370-4bce-b9ca-bc0cc7743b5b"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("aeff939e-6ebe-4cd8-b8b0-365c3d0b02cb"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("af53f9b8-4ae8-4123-8ea7-57ff49a4e34d"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("b04c7414-f108-460b-a4cf-0e3245361687"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("b0512e25-97a2-4241-8699-ca8880a67867"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("b05cc113-eaef-443f-a0c3-07448704ee9c"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("b063c03a-6cd2-4468-8db5-25fcc8c376ac"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("b063e86f-adeb-480f-9df5-d949dd152f6b"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("b08b6481-6f99-4d12-b9e6-bde8eb427eaf"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("b115e992-d812-4bd3-89db-053c99e4c8a9"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 35 },
                    { new Guid("b1b1021a-cdf2-4a97-ac76-8d6a871f3f81"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("b2b5a406-c659-4d63-aed1-8d6f53c90f28"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("b3439f39-3649-46e7-b4de-054be2337834"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("b3fd9b8b-8d32-4393-a833-68d556af025b"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 47 },
                    { new Guid("b4294108-6b1f-4e7c-9a58-f4fe7e7cd9c1"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("b4400f77-e32e-4722-8df1-a7a6aaf1079a"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("b5b9cda0-6b45-47e0-b2ec-e27b87579e5c"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("b620cba1-6c5b-4e26-8c6f-f5a85f03b83f"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("b77415c0-0e07-4a4e-b235-18debec7b2e3"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("b7a681c9-1ce6-4bcd-a7ef-08b3e2c12dba"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("b7dd6296-f94c-47e2-a410-b64c65bcd8d4"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("b803bbdc-6ec1-4633-bcf5-0ab012a24658"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 8 },
                    { new Guid("b84dec15-8ab7-414f-a4d0-ada7db1cb6f6"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("b8523919-f95f-4934-9c3d-09f4e61cc942"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("b89d240c-7e0b-4f43-90d3-ed91878b9f52"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("b8d2ae46-08cf-44e8-9062-c57a40861c09"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("b93a3bd9-2ea0-4ba6-b5af-b75b6c7f34d0"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("b9999cdc-1bd6-4fab-b085-4c2fcd370394"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("b9d8d983-d4b3-4e06-b1a6-31b42daf67e0"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("ba31f19e-6de6-40bf-b7cf-21e60b7f2a5d"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("ba3f218f-644f-4ab7-90c9-021f482b4364"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("bb32c1bd-7705-4deb-aebc-af9e0f716e58"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("bb386f24-bc52-4fa6-a4b4-8c6931ecb2ee"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("bb8716af-1c74-4f9c-a849-836cd1b49909"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 32 },
                    { new Guid("bb939bdf-5c3c-4934-8b0e-31c12ed89413"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("bbafba10-2e97-440a-98f0-c2cf2b3703d8"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("bbcdda00-0d21-4be7-9270-96cd85d880a8"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("bbd68f76-8a5d-497e-a603-955fb5c6ee3e"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("bc66d71e-9134-4f71-9de5-a175116bd01c"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("bc7f755e-28cc-4320-88e7-bf282efcb9fb"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("bca6d565-60cd-44a2-8afa-569282fb7308"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("bcd23b95-6a15-45dd-b140-4c0309063153"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("bd3ff7b3-37a8-4fe1-9e52-e0f951f5befc"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("bd86f61c-c231-4337-b4e4-50d46594bcc1"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("bd9ac320-c405-40d8-bf2d-f2b03452b109"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("be537780-39fb-4a53-aab7-0eac31febf98"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("bee1c8cd-0378-4802-b5bd-78f863d9388d"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("bf121c82-95b9-4fd8-833f-5f2974705396"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("bf8b6b54-fad4-4346-b582-6be247171fb3"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("c2e1a017-0ccb-4586-a5e9-2bfd1bed30b4"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("c39bdc09-f185-4d14-bde7-b79a25e6b324"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("c39ff805-1d91-4060-8c64-74f2a240cfc0"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("c3b6c15b-547f-40e4-a4ce-e962fa68ab11"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("c405ff26-bde8-4227-9a47-94ab4b616c20"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("c45579d9-5047-4ec3-b3eb-b701f286f90a"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("c4710da1-04a9-4aa3-b169-d50a096a6249"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("c4719f76-35d0-48c4-8468-1f37ed2e9082"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("c5a440b2-4568-4e5e-8772-0cd4f9828063"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("c5b5dc7f-f9b5-4aca-ac94-34ee44d16c2b"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("c5d33557-8cf9-437e-863a-ba38df879e48"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("c6238636-fd14-4592-babe-49876f5c36f4"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("c68b0b87-9cfc-493a-b23f-620550c7237d"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 11 },
                    { new Guid("c6a7e4d2-e313-4f25-a700-b31f1144f0ff"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("c7a84ff6-7ca0-424e-a43e-2fa6dd99ef0b"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("c80bb6c6-e9ee-4c06-8522-f1f35b3bb13c"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("c847c8c1-e31b-4805-8bc9-e046a3c3f32f"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("c8d7cf10-f15e-45ca-9880-8dc4460ee5f7"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("c921956d-917b-4d6f-881d-c4919f962a15"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("c983f451-09e6-4333-b2d1-0a7375460729"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("ca05203d-50f8-4774-b4c8-9a5e30474459"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 4 },
                    { new Guid("ca7b8558-5c1b-4679-a91e-56cd60c6e2fc"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("cabefeeb-3ee5-43da-b3ff-5ee065b07d15"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 20 },
                    { new Guid("cac9bf3f-ca92-4646-afe1-3256346a55cb"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("caefe413-96fb-4f8b-9b08-87f721973084"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("caffbf35-4b57-416f-a129-3bc61cafe506"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("cb171801-bc50-46e4-ba9b-2b7336fde0e6"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 17 },
                    { new Guid("cb4093b9-c7c3-4552-b6c3-b3d177118b81"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("cbfe6099-3def-42d4-97aa-f54858872f79"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("cc70b077-1c3d-4df0-b385-420c3e422e74"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("cce62f56-fc72-490a-a0f6-601a83453519"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("cceb864f-757b-47c2-b439-cef6acc30584"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("ccf9f447-211e-4fcc-bcc0-ef067c32c546"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 28 },
                    { new Guid("ce15e16a-f02f-48e0-8c5a-9cd430bc2e3f"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("ce1eca01-2d4c-457d-9b3e-e7ac998661ab"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("ce78f416-0b60-4eac-8851-b5badcba2cbb"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("ce879bb3-e3d5-4851-b448-e204a3ec66c8"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("ce96e720-e292-4d5f-a611-6e2efd9c9ba5"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("cfaa28e5-67c1-48f4-b6b3-8885d9d8ac8f"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("cfaa37db-5649-4cd7-bf01-57cda4295d7e"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("d06c525d-3e2b-40f4-8a0b-d858eca5f0ee"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("d0720489-fbd6-4da5-8ad2-ef5aef694252"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("d13cf4b8-1512-477f-b654-bf01c56637ab"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("d1d8eba4-33f4-4505-b81a-31d51e98efa8"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("d1f089a6-f792-48ba-9d7d-88e7a71933b5"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("d20fe45b-653e-4bbd-8001-18ec719a3749"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("d273e388-aff5-4772-866e-e3a090412ce8"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 26 },
                    { new Guid("d2c89d04-17d7-4754-a7a8-52a0c70da0c9"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("d30d13df-dbce-4266-945e-3e0003b275ff"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("d3524e40-8e4d-4f44-a559-c77f956bdcb6"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("d376928a-19a5-4851-a38a-f79858c4f3eb"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("d3c9757a-1b67-4745-85d4-24b9278d4d0b"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("d3cac994-6c71-405e-8092-e5e2eb89621b"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("d3f9533f-d2dc-4f7e-9092-b06d65141d6a"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("d44821e0-ce60-4bbe-876e-1e8d66c23ea7"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("d4df7f0d-76c0-4fe0-b4b7-f91be65fdeb5"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("d528be8d-09bf-4369-870b-5f8efa56e062"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("d5f2dd5f-ceff-425b-b569-8109c106f356"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("d63ce1c9-cdd8-40d8-97b2-8a079f49dbec"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 1 },
                    { new Guid("d70d5e84-b22b-4426-bc6c-066361026de5"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("d718b71a-696c-4f0d-a22a-96cb1a4ad380"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("d74378b6-6003-4ef6-bc25-935529708da0"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("d7b65001-cee8-4a50-886b-030ae1f67af7"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("d8180c12-5db1-464b-aa27-f141c2a3ee96"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("d8f18ab2-3326-4e48-b6be-3eaf85c37557"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("d8f57a06-0dfd-4ff7-aac7-5b8d14e66046"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("da84cf94-a615-46d7-8b8d-a0c2ead2bbd7"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("da950788-cd73-4a81-a23a-d05ded3922bb"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 9 },
                    { new Guid("daa7236f-35e2-48c0-8849-ce88bc4db728"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 36 },
                    { new Guid("daf4d0ca-389c-4bf7-b048-87ddc3f4b065"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("db0d918a-2c15-430f-80da-f1d908cf7188"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("dbc75fc8-bbf9-4985-9131-2791f13e6a3c"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("dc3d6360-69b2-4765-a075-255e27726fb5"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("dc4e1937-f65a-4148-b9c9-44ec1fdb3be0"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("dd07d5cf-0407-437a-9e24-a132879a3291"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("dd21bd14-98ab-45b0-ad9a-21386161c829"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 33 },
                    { new Guid("dd4add30-0967-49da-a960-01dd76aeb46e"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("dd5aa07f-a875-4a10-882a-dfde62b1454f"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("de4cc6fe-74f2-4c69-8465-b3d7c8a11ac8"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("df02f44e-b11b-4db1-ba47-fa66897dc158"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("df611140-2e9b-4e01-b992-ee48af9fbe35"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("df97d6a5-8d6d-48a8-9f0c-3f4e34308ee1"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("df9ed80e-c5aa-46d9-bd69-50d9ad95d5e3"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 43 },
                    { new Guid("e0aadecd-757c-4136-a9e9-0adfdb8bee8b"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("e0f8e58a-5c8a-4cee-a42f-c80c38515acf"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("e17ed993-8f75-4ac2-b3ec-4b343a1155c7"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 25 },
                    { new Guid("e205be19-9a31-4b73-bbb7-79a531fa309c"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("e258b5a7-4f26-4b3d-9d93-222f77ce65a5"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("e2a70839-59ef-47db-9ac0-0d2681836867"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("e32e7f95-450b-432d-a799-48cbcb8ddd36"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 18 },
                    { new Guid("e37a235f-d62e-4b4a-9474-08b129c1e68b"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("e46f9893-1b04-4ae6-ad92-e47581388a4c"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("e4b26a35-238b-46eb-9f05-12250eaa408f"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("e6276700-324e-460e-a54e-87f40f9575d4"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("e62dc1cf-42a4-4691-a5f9-6079cbade579"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 39 },
                    { new Guid("e69887e1-b9d2-439d-beb8-36dcc7cdaa63"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("e7bff02c-d2ee-4b0c-bead-0a59e86addd4"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("e81ca092-7e4d-494b-ad7f-d40a4d6945ce"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 49 },
                    { new Guid("e8eafa9c-b4ea-4928-ade6-d5524167bbf8"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 31 },
                    { new Guid("ea220807-6978-4882-b1f1-3b1cdbd4b33a"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("ea2d62ee-b03f-408a-af9b-6291f0fa7f5b"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 2 },
                    { new Guid("eb4e7020-df06-4017-8cae-1e592cb96ac7"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("ec15461a-657f-4a84-8b22-5712ec98284e"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("ec61353f-1967-4a12-858e-b83b7db893b2"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 40 },
                    { new Guid("eceeba6d-068a-4526-800a-3699ed7c1028"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 10 },
                    { new Guid("ed15b9e6-01f5-403c-83cb-f81030f13693"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("ed4bd2cd-c5ae-4a43-9eda-1edb603df320"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 6 },
                    { new Guid("ed9d3697-6a34-4fc2-8c72-dee9c1151b21"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 12 },
                    { new Guid("ee5e1e62-c7c0-47d0-8063-28ce5b412f9f"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 13 },
                    { new Guid("eeed2f2c-59c6-4174-84f0-d97a2d75ddaf"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("eefd789b-497e-4f42-9dd9-c0aaa8828307"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 41 },
                    { new Guid("ef7d55e3-8980-494f-bf47-666666fc28f4"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("f2096d1e-2ceb-44c7-b251-982a931e0ab5"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("f21f3c73-d793-4613-b207-fda6fc194968"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("f2e4b456-1158-4489-9df4-ba975a9769d9"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 44 },
                    { new Guid("f349e8fc-9c0c-4efa-a60c-73145c2a0f69"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 30 },
                    { new Guid("f3e862a4-a24e-4182-820c-d05f1f014338"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("f4741bec-62bf-4396-b787-d8bf8dd6172b"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 15 },
                    { new Guid("f4cf284a-379f-46a3-b5a9-d0ae91d4450b"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("f4d69ef4-fa60-4b1a-bf4c-75cce481e34e"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("f4e49ce6-f34c-4483-94f8-fad0776ebb34"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 16 },
                    { new Guid("f521a34e-c66d-4c36-a598-5a083c83e678"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 19 },
                    { new Guid("f5e34abf-6bc7-4d2b-b664-6760d2ca3729"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 5 },
                    { new Guid("f678f8b3-e241-4b9c-974a-6aa3879d681b"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 38 },
                    { new Guid("f7fc56d4-7f4e-41de-9e96-b9c8f00ea83b"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 50 },
                    { new Guid("f84c7e94-86f4-486d-a65a-0f3f91e3bef2"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("f90163e1-b29d-41b8-9759-1c944e09df55"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 46 },
                    { new Guid("f93537cd-d092-4740-8054-3f76de5c266f"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("f93bb641-fb72-4e6c-bf71-b2f6dd2e7922"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("f9a75d81-26cb-431b-8a76-e8da885e0603"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 45 },
                    { new Guid("fa5e8df9-2d03-4f82-b9a3-afca1686acee"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 23 },
                    { new Guid("fa9650ca-e381-4d90-99fd-6e755dcad4d1"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 34 },
                    { new Guid("faa9962d-815e-454c-a02b-9b88a2afb109"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 21 },
                    { new Guid("fb823f3c-7240-4e34-b363-78e8268cc1ff"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("fbbcbe9e-6a4c-4857-9c53-ae2a16d56651"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 48 },
                    { new Guid("fbd5798e-ad84-417b-947e-03796de6af62"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 22 },
                    { new Guid("fc22719d-a0c6-4cc8-8e3e-95b883416690"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 29 },
                    { new Guid("fc512df7-e3e5-41ef-885f-b44250599090"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 37 },
                    { new Guid("fc809c25-8fed-47fe-82be-49f3fb55f688"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("fccdb4cf-71ec-4f04-87fb-146ba479886e"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 14 },
                    { new Guid("fcd81237-57bc-4477-bb03-133976442308"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 7 },
                    { new Guid("fd14bdc6-5c8c-4fa4-8dda-25098e6444e7"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 3 },
                    { new Guid("fd5372b3-19de-47bb-a5f4-91f9a01f70ff"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("fd54ea97-b542-40b6-9658-c4132f700203"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 0 },
                    { new Guid("fdbe56f7-abc1-4ccb-9458-52bd1505457e"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 27 },
                    { new Guid("fdceb812-5a19-47e3-a205-2bd02eead47a"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 24 },
                    { new Guid("fdfd8674-5dcc-47af-abef-2e7354cd1bc1"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 },
                    { new Guid("ff0ac3e3-b92f-4c73-83ca-7650ab965b4e"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, 42 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalChip_PersonIdentifierId",
                schema: "Dogi",
                table: "AnimalChip",
                column: "PersonIdentifierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalChip_ReceptionDocumentId",
                schema: "Dogi",
                table: "AnimalChip",
                column: "ReceptionDocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cage_AnimalZoneId",
                schema: "Dogi",
                table: "Cage",
                column: "AnimalZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_CageId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "CageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_CategoryId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_IndividualProceedingStatusId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "IndividualProceedingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_ReceptionDocumentId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "ReceptionDocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_SexId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_VaccinationCardId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "VaccinationCardId",
                unique: true,
                filter: "[VaccinationCardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_IndividualProceedingId",
                schema: "Dogi",
                table: "MedicalRecord",
                column: "IndividualProceedingId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_MedicalStatusId",
                schema: "Dogi",
                table: "MedicalRecord",
                column: "MedicalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonBannedInformation_PersonIdentifierId",
                schema: "Dogi",
                table: "PersonBannedInformation",
                column: "PersonIdentifierId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCardVaccine_VaccinationCardId",
                schema: "Dogi",
                table: "VaccinationCardVaccine",
                column: "VaccinationCardId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCardVaccine_VaccineId",
                schema: "Dogi",
                table: "VaccinationCardVaccine",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationCardVaccine_VaccineStatusId",
                schema: "Dogi",
                table: "VaccinationCardVaccine",
                column: "VaccineStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_AnimalCategoryId",
                schema: "Dogi",
                table: "Vaccine",
                column: "AnimalCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalChip",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "MedicalRecord",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "PersonBannedInformation",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "VaccinationCardVaccine",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "IndividualProceeding",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "MedicalRecordStatus",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "VaccineStatus",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "Vaccine",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "Cage",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "IndividualProceedingStatus",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "ReceptionDocument",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "Sex",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "VaccinationCard",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "AnimalCategory",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "Zone",
                schema: "Dogi");
        }
    }
}
