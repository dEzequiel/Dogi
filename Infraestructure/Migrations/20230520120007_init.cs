using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "Person",
                schema: "Dogi",
                columns: table => new
                {
                    PersonIdentifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerAddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerAddressZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBan = table.Column<bool>(type: "bit", nullable: false)
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
                name: "AnimalChip",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerPersonalIdentifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChipNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerIsResponsible = table.Column<bool>(type: "bit", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalChip", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_AnimalChip_Person_OwnerPersonalIdentifier",
                        column: x => x.OwnerPersonalIdentifier,
                        principalSchema: "Dogi",
                        principalTable: "Person",
                        principalColumn: "PersonIdentifier",
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
                name: "Cage",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AnimalZoneId = table.Column<int>(type: "int", nullable: true),
                    IndividualProceedingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsOccupied = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IndividualProceeding",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceptionDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                table: "Sex",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
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
                    { 11, "WaitingForOwner" }
                });

            migrationBuilder.InsertData(
                schema: "Dogi",
                table: "Cage",
                columns: new[] { "Id", "AnimalZoneId", "IndividualProceedingId", "IsOccupied", "Number" },
                values: new object[,]
                {
                    { new Guid("006f3cd5-31b8-4749-a68f-2443e57970e9"), 2, null, false, 20 },
                    { new Guid("008292da-f4f0-4ec9-a383-19affb079db4"), 5, null, false, 41 },
                    { new Guid("01dce334-667a-4060-b2ef-6b71c15ed3c4"), 7, null, false, 40 },
                    { new Guid("01e022cf-2374-4664-9097-9dedb0aa674c"), 6, null, false, 17 },
                    { new Guid("020aa6c9-8cde-44ac-bcf7-fc83521aec85"), 1, null, false, 9 },
                    { new Guid("028eeb50-e4ad-49f7-adb1-a86627bfe4d6"), 8, null, false, 11 },
                    { new Guid("032d10ca-e5ac-4cf1-a6f0-d6267c4ffe32"), 1, null, false, 37 },
                    { new Guid("039700ff-1d5d-4a55-a9f1-8b1783e8ac88"), 7, null, false, 49 },
                    { new Guid("0401a2b5-6060-4fb8-8872-90d7d33442d5"), 8, null, false, 3 },
                    { new Guid("0489c017-889d-47e8-b017-14b211de1458"), 1, null, false, 45 },
                    { new Guid("0544dc77-498f-444b-9f67-e4cfc457e329"), 2, null, false, 16 },
                    { new Guid("059ad241-d85f-4743-b4e9-5760720b04e6"), 8, null, false, 8 },
                    { new Guid("05a9b72e-a98a-45e5-9f01-8694341230e2"), 2, null, false, 11 },
                    { new Guid("074caf10-5178-49c8-b25d-074e604a73aa"), 8, null, false, 41 },
                    { new Guid("081c9e5c-409a-4606-b36b-bdbc7b4a2951"), 2, null, false, 44 },
                    { new Guid("0c1a208f-f90e-4c7d-862b-0becd5df30c2"), 4, null, false, 2 },
                    { new Guid("0c2ac669-0338-44c0-8592-78e61bb7cc89"), 3, null, false, 33 },
                    { new Guid("0d66766d-b9e3-4696-88f9-7369ab472070"), 3, null, false, 3 },
                    { new Guid("0dd9acd3-3057-4322-9d9f-f6dddc6f0c7d"), 3, null, false, 20 },
                    { new Guid("0e4d56db-db5b-4148-b5b7-c84f6dd9a3e1"), 5, null, false, 27 },
                    { new Guid("0e928849-91f5-4588-8f0c-0b22cd99f48e"), 2, null, false, 24 },
                    { new Guid("0f08f88b-97e7-4816-aa75-8313a19425a5"), 4, null, false, 40 },
                    { new Guid("0f52d031-e31d-4919-9291-a07eafcdeabc"), 9, null, false, 30 },
                    { new Guid("0f584884-e994-42a5-a1fb-2759f3fb04cf"), 7, null, false, 47 },
                    { new Guid("0f73621e-dbb6-4e75-b382-5df0b626fff9"), 3, null, false, 30 },
                    { new Guid("10497237-00fb-4d08-895e-e3e9f9d7eff8"), 2, null, false, 21 },
                    { new Guid("10a1e016-3f80-4333-9ee3-0622b5de7122"), 8, null, false, 42 },
                    { new Guid("1116b7d8-6653-4a61-ab1e-ac0cc4b37128"), 4, null, false, 28 },
                    { new Guid("11fe6527-a169-45ea-9815-d7f99c2bd965"), 4, null, false, 41 },
                    { new Guid("121f2ce0-2be7-44b2-b645-be01489fec63"), 3, null, false, 27 },
                    { new Guid("1257fa1c-dba4-45f5-b832-c66bf42bb5b4"), 8, null, false, 6 },
                    { new Guid("126ead60-1c92-47ab-9946-d1be5e2e4cc0"), 6, null, false, 15 },
                    { new Guid("1288d9e2-0277-4589-ba84-34e117b53019"), 8, null, false, 16 },
                    { new Guid("12e572f4-607b-4805-b33f-be58d47ddba8"), 8, null, false, 21 },
                    { new Guid("1323dbf4-85d1-4459-9297-77dd7a778b7b"), 3, null, false, 19 },
                    { new Guid("13f1a579-3ad6-40cc-a08a-7796f8cdc567"), 1, null, false, 19 },
                    { new Guid("14a2b53f-656b-4d34-ac87-3c343444396a"), 9, null, false, 5 },
                    { new Guid("1546939e-e718-4b2a-8452-03a9db7fb2b3"), 3, null, false, 31 },
                    { new Guid("15714c1c-5437-4a71-be74-2c0f1be0bf11"), 3, null, false, 36 },
                    { new Guid("15b33c29-06a1-463f-8690-3b89c5302109"), 1, null, false, 10 },
                    { new Guid("15e271d9-2ad7-4b57-ae11-bdb7feec3514"), 2, null, false, 45 },
                    { new Guid("163b669e-1a4b-427e-889d-f95abc475624"), 6, null, false, 34 },
                    { new Guid("179972ef-915a-4f73-ad26-602569b6c8cc"), 9, null, false, 8 },
                    { new Guid("17c58de3-1e84-4501-8140-229bf2a9034c"), 2, null, false, 40 },
                    { new Guid("17eff291-bbbe-42d8-aaf5-2c33e1225f4b"), 6, null, false, 23 },
                    { new Guid("180960a6-4c57-41a2-afad-558c7fe06176"), 9, null, false, 49 },
                    { new Guid("186db55b-0478-412b-9aac-a0791fb5bd0d"), 7, null, false, 21 },
                    { new Guid("18bf73dd-8783-437f-8486-25dd2ec0ad95"), 7, null, false, 34 },
                    { new Guid("1910ab96-deab-4b45-832c-d376409ae5b0"), 2, null, false, 12 },
                    { new Guid("1991b280-e864-4508-83e1-99fb35514405"), 5, null, false, 15 },
                    { new Guid("19a2bd07-7b7c-492c-88af-37c46676c91b"), 6, null, false, 8 },
                    { new Guid("1a742f39-5147-46d6-b885-dfc0af83830b"), 2, null, false, 29 },
                    { new Guid("1b071714-101e-4710-bdee-0b7f378cd34d"), 7, null, false, 13 },
                    { new Guid("1b611a99-f320-4ffe-aad1-d7cdc4550607"), 3, null, false, 24 },
                    { new Guid("1cb6c5d4-c34d-4999-954e-e4acab9a6d47"), 1, null, false, 32 },
                    { new Guid("1cd58ea0-5d19-41ff-b0d7-7162ade31f05"), 4, null, false, 44 },
                    { new Guid("1d7969f9-2890-484a-a335-72545364fe07"), 5, null, false, 17 },
                    { new Guid("1d911f45-fd08-43f9-8859-a207ee2c060b"), 4, null, false, 36 },
                    { new Guid("1dacece8-b54a-43c6-a14c-356aec48f492"), 5, null, false, 11 },
                    { new Guid("1ea10e46-4548-4d8a-b343-0ff0b42bd331"), 2, null, false, 3 },
                    { new Guid("1f700fd0-8796-48cd-b768-3a5d108be8e0"), 4, null, false, 19 },
                    { new Guid("2034659a-91a6-4d01-8fed-3745f9cb412b"), 2, null, false, 30 },
                    { new Guid("20e4637f-b910-4118-97d1-97efe91ece1a"), 2, null, false, 47 },
                    { new Guid("213b3a45-bb94-4f3f-a3c7-57f920661a8d"), 2, null, false, 42 },
                    { new Guid("2145e3ef-1218-4098-8fd4-aab4bf10900b"), 9, null, false, 31 },
                    { new Guid("22622b95-8231-4e02-865e-fe221c9af05d"), 7, null, false, 37 },
                    { new Guid("23d66751-9903-47b6-860c-346b7a7a29e3"), 4, null, false, 48 },
                    { new Guid("248fcce5-8b2d-449e-9bfe-8ff341662d88"), 7, null, false, 9 },
                    { new Guid("26378357-5def-47d3-b15b-621d0685b195"), 9, null, false, 39 },
                    { new Guid("2a6299a4-0b8a-420e-9347-19d9b5f05389"), 8, null, false, 31 },
                    { new Guid("2a9711cf-77e7-46a6-9133-0b84ef0cc95d"), 9, null, false, 28 },
                    { new Guid("2cad53cf-e834-4ee4-85fb-ea24dc865848"), 6, null, false, 42 },
                    { new Guid("2d1d5715-ba1e-46e0-918c-af46e21b5788"), 3, null, false, 40 },
                    { new Guid("2de846a3-02e1-441a-9985-27c381827c91"), 5, null, false, 45 },
                    { new Guid("2e06b74b-7e22-4cfa-9e1f-7f3cce4ec01e"), 8, null, false, 48 },
                    { new Guid("2ef9e3a7-4f0e-4811-a5b4-6ae2d779cba7"), 7, null, false, 14 },
                    { new Guid("2f6fa436-8c5b-43f6-b911-09d15a1ee404"), 7, null, false, 43 },
                    { new Guid("3069d5ca-c558-415a-baa9-a043e4474881"), 6, null, false, 24 },
                    { new Guid("30b208fc-398b-49a9-81c0-f1d00be46617"), 9, null, false, 35 },
                    { new Guid("317be60e-5cff-4944-aa9e-ac602adefdd3"), 5, null, false, 7 },
                    { new Guid("322e6350-ccd4-49e3-bd7e-eed1f615c0fe"), 2, null, false, 41 },
                    { new Guid("32560843-62a1-43e8-869b-fc5bb351b3e4"), 3, null, false, 32 },
                    { new Guid("33aa1c45-592c-4c80-ab1b-8ad6b78de748"), 7, null, false, 0 },
                    { new Guid("34485228-59c7-4505-a39d-cf276c5fc494"), 3, null, false, 49 },
                    { new Guid("346da01b-0765-43f1-b2f2-2c801c0f3005"), 4, null, false, 27 },
                    { new Guid("34d44364-02d0-4663-8e7d-c8473527d3e5"), 7, null, false, 27 },
                    { new Guid("34de1438-fbe6-42af-81bb-f87d08df40fa"), 8, null, false, 25 },
                    { new Guid("359271a4-9205-4113-acf7-ad714a46a60d"), 1, null, false, 5 },
                    { new Guid("359ffa1e-2cbb-4b18-b454-46603bfd0c45"), 1, null, false, 12 },
                    { new Guid("36f00bb2-5fc7-4fa5-b25c-1fc377d08349"), 2, null, false, 4 },
                    { new Guid("37ed707e-c06f-46bc-8f0e-0027d9b1fb70"), 7, null, false, 1 },
                    { new Guid("37fc3305-ac9b-4c06-a181-deeecc3a53f1"), 4, null, false, 39 },
                    { new Guid("390e0429-638c-4ad3-9950-82f76a696122"), 3, null, false, 48 },
                    { new Guid("392417be-e0ce-4ff4-af1f-c870194ff0e8"), 2, null, false, 1 },
                    { new Guid("397d044c-79fc-4e87-b8c0-7bf8fe6490cd"), 9, null, false, 42 },
                    { new Guid("398571d9-89b2-4ee1-9720-6896efb880a0"), 7, null, false, 4 },
                    { new Guid("3a92fecf-8e31-41e4-8505-159d8b9275d5"), 6, null, false, 41 },
                    { new Guid("3b54418f-f513-4868-8b5d-699596c79f9c"), 3, null, false, 25 },
                    { new Guid("3b689871-54a8-46b0-8cf5-a4ed2148322e"), 6, null, false, 44 },
                    { new Guid("3c2728d2-8110-4eca-86b7-b18da47040a7"), 1, null, false, 43 },
                    { new Guid("3cc13b02-6219-4581-9ef7-ba3be0e15ac1"), 4, null, false, 43 },
                    { new Guid("3ee33c49-9fe3-427a-b81d-3c0a6a8e0d35"), 1, null, false, 3 },
                    { new Guid("3fa2913d-3303-4b15-a46c-5bc1f1cd8941"), 9, null, false, 3 },
                    { new Guid("3fddbf7c-ad51-4d0e-8ee2-f74eb00b8c9f"), 4, null, false, 8 },
                    { new Guid("3ff3e479-8362-4e4a-a8a9-eb0e3eb34cea"), 3, null, false, 34 },
                    { new Guid("4016ca08-54bc-4fae-862b-a0c8933d7101"), 8, null, false, 17 },
                    { new Guid("408af15f-8ed1-48fb-aa22-8bf8067d2573"), 9, null, false, 45 },
                    { new Guid("409d4ef9-8345-4f77-b175-7ba1b612acb9"), 4, null, false, 32 },
                    { new Guid("4119bca2-375e-467d-9465-68198068069b"), 9, null, false, 0 },
                    { new Guid("43cc9c0c-aac4-44c2-a707-0fcf7bfbb316"), 6, null, false, 28 },
                    { new Guid("44305292-e206-4632-b8f7-16a9eb7b24a3"), 4, null, false, 11 },
                    { new Guid("44517a47-9594-4f5f-9931-ae28753ee9eb"), 8, null, false, 35 },
                    { new Guid("47d1f4c7-2956-4a3b-949c-cc0dcda057e0"), 8, null, false, 45 },
                    { new Guid("48f88166-b588-4a22-bba5-db5a96b8f301"), 4, null, false, 5 },
                    { new Guid("491086f3-8ff3-4cdc-99e6-1887a8c23caf"), 3, null, false, 38 },
                    { new Guid("496cb219-b539-4e14-8037-9c23d6fb52a6"), 1, null, false, 33 },
                    { new Guid("49b13cd9-f7f6-4049-afa2-8e1e1d65ba42"), 6, null, false, 16 },
                    { new Guid("4a318c52-d9f0-4ccc-9fa6-77b2f46facba"), 1, null, false, 36 },
                    { new Guid("4a440899-e484-422d-9baf-c1c47f0ad954"), 2, null, false, 9 },
                    { new Guid("4cde8db8-157e-4fb0-a1e7-c6b8815e880e"), 6, null, false, 13 },
                    { new Guid("4e13a326-60fc-4779-8346-92c9a2b9dd1a"), 4, null, false, 14 },
                    { new Guid("4e736184-833d-4d70-8063-b5720fb7251e"), 1, null, false, 35 },
                    { new Guid("4f830355-b0c4-4580-9dbb-c755cbd385ef"), 4, null, false, 9 },
                    { new Guid("50c472e3-4065-46f3-9644-5a431930fc00"), 6, null, false, 20 },
                    { new Guid("5144e6f0-09c6-41f7-9278-b45a22999f64"), 4, null, false, 15 },
                    { new Guid("52cc5cd5-26a5-432f-b78f-74ff5a655743"), 9, null, false, 23 },
                    { new Guid("52dc634a-50cb-4fb3-9102-e41e57ef6647"), 1, null, false, 24 },
                    { new Guid("53847b53-e75a-45fb-bb23-abeed6d1a32f"), 1, null, false, 46 },
                    { new Guid("5389d0f4-9c9e-4d48-b319-e60dec43043b"), 2, null, false, 17 },
                    { new Guid("53c3a7d3-c859-4f7b-80f0-f104ff7b8d25"), 7, null, false, 28 },
                    { new Guid("53f67f6d-7a57-4a8e-ae66-efade58bea41"), 5, null, false, 22 },
                    { new Guid("5401f3b9-cdd0-476f-aa0d-36c9d55c4e81"), 4, null, false, 31 },
                    { new Guid("543d9a8a-81fd-4e03-80a6-d54c30e28e43"), 4, null, false, 20 },
                    { new Guid("545e18ba-65fa-47ad-9cb5-924b93996dfd"), 3, null, false, 26 },
                    { new Guid("551269b2-9314-4759-a902-776fbaf37e00"), 6, null, false, 1 },
                    { new Guid("56bdcd00-1172-46d1-9b37-4553502101f9"), 2, null, false, 14 },
                    { new Guid("57b82382-24f9-4608-b670-eedab2416501"), 8, null, false, 20 },
                    { new Guid("58688839-1a52-4147-92c9-0a9be4a12d92"), 7, null, false, 7 },
                    { new Guid("5904e9c0-928a-4e87-8b64-7b1f84bed2ac"), 9, null, false, 25 },
                    { new Guid("593ffd3b-d6e4-4c24-8599-df9a43030502"), 1, null, false, 7 },
                    { new Guid("598af379-a785-435f-87ef-517f7c30616a"), 4, null, false, 23 },
                    { new Guid("5acf6fbb-cfb4-4276-ac1a-893889a115f3"), 7, null, false, 38 },
                    { new Guid("5b116073-0ed0-4d1d-b9ad-b4eb2fc8baf2"), 8, null, false, 47 },
                    { new Guid("5c22a490-8d7c-4bc1-85f0-ba5b33e0fc4b"), 6, null, false, 5 },
                    { new Guid("5c9a4dcd-ed55-47b0-8656-76f4284ee3c0"), 6, null, false, 31 },
                    { new Guid("5d1720aa-e959-45ae-a9b6-c9a3b51a00f0"), 7, null, false, 30 },
                    { new Guid("5e2eeb5c-4300-4892-b4c9-e9b873342303"), 2, null, false, 34 },
                    { new Guid("5ea8ccec-59fd-41af-a15c-12db0006460f"), 6, null, false, 0 },
                    { new Guid("5ebc9ff0-6819-4d12-9a38-fee288c7eba1"), 7, null, false, 17 },
                    { new Guid("5f1da36a-d1f7-41ef-9464-431c1ae7085b"), 4, null, false, 26 },
                    { new Guid("5fe5e417-4e2e-4d1b-99de-2e4c68429f53"), 3, null, false, 15 },
                    { new Guid("605f38cc-b7cf-4776-be48-c8bb9f2ee1ec"), 8, null, false, 26 },
                    { new Guid("62f5bec4-8228-43af-afda-d16ef3cbcaca"), 5, null, false, 40 },
                    { new Guid("63fe55e0-bf7e-482a-bfc6-d12fc8f38a95"), 1, null, false, 23 },
                    { new Guid("64aa1927-a965-4e10-a9a2-649b6939511e"), 1, null, false, 17 },
                    { new Guid("657514c9-cadd-49e4-ad25-84adc7ea5e0a"), 2, null, false, 2 },
                    { new Guid("65a7acd6-c8c1-4ab7-a4b5-c418b2ddf16f"), 7, null, false, 31 },
                    { new Guid("6605aac4-eded-4d23-be59-ebd7764f446d"), 9, null, false, 37 },
                    { new Guid("67e369d3-a423-4e74-8760-90784fc9c35d"), 9, null, false, 18 },
                    { new Guid("67ea0da4-1a29-4054-b3b9-91aff63d5562"), 9, null, false, 29 },
                    { new Guid("694457af-ca88-4c0a-a99d-1a8a8192f599"), 5, null, false, 34 },
                    { new Guid("6a108457-77aa-4962-a01a-c61975e0de06"), 9, null, false, 6 },
                    { new Guid("6a2d69f0-7dcf-4e3e-bdc8-cac106ce84f2"), 7, null, false, 2 },
                    { new Guid("6aa18be9-4cb4-4a27-937a-09e3810ba62b"), 6, null, false, 43 },
                    { new Guid("6b71c33c-fc24-480a-b14e-a429c1c8ce9e"), 6, null, false, 48 },
                    { new Guid("6bc1ae69-99f8-45c5-8905-f6bb45f7ac97"), 9, null, false, 38 },
                    { new Guid("6cab785f-0933-476f-a42a-5d9234da80b4"), 9, null, false, 15 },
                    { new Guid("6d057cd1-3671-4fe5-838e-df19eb3d483e"), 2, null, false, 27 },
                    { new Guid("6e8048af-7cc0-4f6d-b994-cab3476354bc"), 2, null, false, 0 },
                    { new Guid("6ecc886f-567d-4258-b42a-47dd2d29266c"), 5, null, false, 8 },
                    { new Guid("6f2d2ea9-5038-45e2-8ebe-0049cbbe51ee"), 2, null, false, 15 },
                    { new Guid("70015c77-1c4f-4eab-8e49-2b9a82154357"), 5, null, false, 26 },
                    { new Guid("706dba65-476e-49e4-99a3-206c614980f3"), 6, null, false, 33 },
                    { new Guid("7082263f-fdaf-4860-a9b2-21ee9b31a99d"), 3, null, false, 7 },
                    { new Guid("708b4458-789c-4412-a970-4233bf3b955c"), 5, null, false, 43 },
                    { new Guid("71665144-4662-4d7b-8d55-679e19144000"), 7, null, false, 41 },
                    { new Guid("71925cb0-3d78-41d8-9302-0e42db2f25eb"), 4, null, false, 29 },
                    { new Guid("723ba4f7-9a89-4fdd-96f9-ef342d1c08f6"), 2, null, false, 33 },
                    { new Guid("730d5d94-c88e-476a-b376-04ab3d495a79"), 5, null, false, 47 },
                    { new Guid("737e49ff-77b8-43fa-9608-044dc7a612f2"), 8, null, false, 23 },
                    { new Guid("73843268-215c-4e13-8b68-f641484c432e"), 4, null, false, 38 },
                    { new Guid("73f6a2c9-eb5e-44d5-b0aa-3d5a3dd1017b"), 8, null, false, 4 },
                    { new Guid("740cdf27-fe9e-4230-bc76-e1932f469752"), 7, null, false, 10 },
                    { new Guid("74c9965e-80b5-4a9e-a474-10a7c6e1b562"), 5, null, false, 0 },
                    { new Guid("759701f5-3814-40f0-aaea-7bcf58489007"), 6, null, false, 4 },
                    { new Guid("7877e307-d84b-4c59-8ce9-9f336dc42331"), 9, null, false, 17 },
                    { new Guid("78ea024d-042c-4309-8aab-59f90261850c"), 9, null, false, 34 },
                    { new Guid("794176cc-5e37-41a3-8fd7-0e90569ef154"), 5, null, false, 37 },
                    { new Guid("79a5b8b8-55e4-4f84-95d1-02c4716f8757"), 3, null, false, 9 },
                    { new Guid("79e35f05-cb84-4325-a619-43c1179b5a25"), 6, null, false, 11 },
                    { new Guid("7ad90ecd-7098-4339-875b-3098d8a312a0"), 2, null, false, 22 },
                    { new Guid("7be40484-ee46-4d19-87d3-b7d6b415cf7d"), 1, null, false, 0 },
                    { new Guid("7c07fbfa-e1e0-4b6b-a56d-3a6cf6258ebf"), 1, null, false, 14 },
                    { new Guid("7cb936d3-af30-4b7e-a2da-ac9acc57ddd2"), 9, null, false, 12 },
                    { new Guid("7cea32e8-4206-490e-94cf-c84007675232"), 6, null, false, 25 },
                    { new Guid("7d56690c-3f67-48b7-82d3-0b0a06744374"), 7, null, false, 18 },
                    { new Guid("7d6a74a8-7f1e-42a5-a2db-d408f3f0b554"), 8, null, false, 32 },
                    { new Guid("7d78f922-bbce-4d2f-9e68-509ade3bb7d1"), 7, null, false, 29 },
                    { new Guid("7e0c6af9-669a-49d2-9b77-93b150fc1818"), 4, null, false, 35 },
                    { new Guid("7eb55ee3-5153-4b3a-93cd-4b4986a796fd"), 2, null, false, 28 },
                    { new Guid("7eba6351-73bf-4c87-95c6-75d3910da1a0"), 4, null, false, 47 },
                    { new Guid("7ebbc630-2c83-42ff-8b3b-f0679cc2b03a"), 6, null, false, 45 },
                    { new Guid("7ec50dab-adc1-4f87-ac2d-e84f77b1dbe4"), 3, null, false, 23 },
                    { new Guid("7f70213c-f2b5-49b1-b79a-f879564efb8a"), 1, null, false, 2 },
                    { new Guid("7f81af35-3887-4cb8-97ca-e75715279ed8"), 4, null, false, 7 },
                    { new Guid("7fb3dd2f-f36e-4a15-a135-e48341d3ccc7"), 2, null, false, 46 },
                    { new Guid("805cc4ff-eacb-45b8-b6af-f172d9125058"), 2, null, false, 19 },
                    { new Guid("8061f3da-b406-484b-8d5f-c7709d669db6"), 1, null, false, 39 },
                    { new Guid("80fd91ec-90b4-4e77-b7e1-5e218c964e89"), 8, null, false, 36 },
                    { new Guid("811ac750-d548-4c04-b714-6cdcba91b62a"), 1, null, false, 40 },
                    { new Guid("81966bc3-3371-4e2e-85a9-6f2d9ae49a5c"), 7, null, false, 48 },
                    { new Guid("82808315-4819-4662-8eaa-6837251efbfe"), 2, null, false, 48 },
                    { new Guid("831702ea-850d-4b0a-b1ca-20cc2fd8f007"), 3, null, false, 2 },
                    { new Guid("83381b44-d78a-466d-b3d3-6c643e089afc"), 1, null, false, 8 },
                    { new Guid("836a3629-aad2-4cec-9d5f-b4ba73c0e530"), 4, null, false, 34 },
                    { new Guid("83b39844-9a4d-4375-a0d6-4c05c31b7a2f"), 6, null, false, 30 },
                    { new Guid("86bd63c7-5672-477a-8d49-6a8d1aeb4220"), 3, null, false, 22 },
                    { new Guid("87f5fe6f-f11d-4d64-9f4a-a68a25a2105a"), 5, null, false, 39 },
                    { new Guid("88904f71-c1a9-4ec9-80d3-55bf5ab46cc2"), 6, null, false, 27 },
                    { new Guid("88ec1769-a921-4b62-abff-1b0d24a9d844"), 2, null, false, 49 },
                    { new Guid("89975807-9715-4557-836d-36262c42944e"), 8, null, false, 5 },
                    { new Guid("89f88ba5-d4fa-4240-93f4-ae1d86ce9b0f"), 4, null, false, 6 },
                    { new Guid("8a1989a7-0116-48b1-a1ca-b4cfe4d04e71"), 2, null, false, 13 },
                    { new Guid("8a457bc8-0698-4bd5-b008-097eabc91406"), 6, null, false, 46 },
                    { new Guid("8aa7db04-522b-4442-b0a7-f49699942856"), 5, null, false, 29 },
                    { new Guid("8ac405d5-2a69-42be-b1a3-4a8a9d89fa8e"), 1, null, false, 47 },
                    { new Guid("8b431763-3f9c-4ee4-b796-fe2b132b35aa"), 3, null, false, 13 },
                    { new Guid("8c2d591a-7c61-403a-9d7a-27466f1b0a51"), 1, null, false, 28 },
                    { new Guid("8d3b62a5-5b31-4ce1-a2da-cf2e6ba65d5c"), 6, null, false, 19 },
                    { new Guid("8da850c5-3232-43f9-ab09-0c4b11013dc8"), 4, null, false, 16 },
                    { new Guid("8edc657e-249e-4f79-80f0-8671b9717d59"), 1, null, false, 30 },
                    { new Guid("8f11f567-763a-4070-b59e-15a31405eedd"), 5, null, false, 9 },
                    { new Guid("8f1ba278-cac6-4d33-b4ce-52ec86aea128"), 5, null, false, 12 },
                    { new Guid("8fb2d42b-1213-4036-8ae7-d4646853e7b3"), 8, null, false, 22 },
                    { new Guid("90809b95-9adf-49f4-a1b3-e92c95e6585e"), 3, null, false, 8 },
                    { new Guid("90d526e4-acfb-4a71-940f-1cbbd12a6377"), 9, null, false, 24 },
                    { new Guid("916d4aa8-20d9-4e78-bd41-5f9dbf1ddc0c"), 9, null, false, 7 },
                    { new Guid("9175666e-5a6a-4473-9a6a-10782126d974"), 4, null, false, 1 },
                    { new Guid("9178c539-68c4-430c-a43b-0c74f6f24839"), 4, null, false, 21 },
                    { new Guid("91978dd0-b8e2-4c61-9e2c-58451cfc89b7"), 3, null, false, 11 },
                    { new Guid("91b0d384-782d-4bda-9fa4-c8cf10c3020f"), 7, null, false, 35 },
                    { new Guid("920e7fe6-835d-4ee1-a2c9-b664b104cf13"), 6, null, false, 32 },
                    { new Guid("9314c786-f1ba-44b1-9267-abbd937c69e3"), 9, null, false, 43 },
                    { new Guid("931c2d31-5b6c-448f-8c3d-fd06780492c1"), 2, null, false, 43 },
                    { new Guid("93855fb8-f674-4587-b9ec-9f6e1f551f71"), 8, null, false, 38 },
                    { new Guid("93d96669-28a8-4e9f-a6b5-a399125552bc"), 7, null, false, 45 },
                    { new Guid("93e664ca-02f6-4e1f-b869-08374d306d0f"), 3, null, false, 5 },
                    { new Guid("94692cef-c72c-477e-b814-38b55ce86423"), 8, null, false, 43 },
                    { new Guid("947ab2c2-2949-4353-87bd-7d483708138f"), 7, null, false, 44 },
                    { new Guid("94993efd-09c7-43c4-8265-7aa7bc8de719"), 9, null, false, 44 },
                    { new Guid("94a1160b-9ada-47aa-b686-e7d9426435e7"), 8, null, false, 7 },
                    { new Guid("95008b55-a117-4708-8f3b-b4ace238996f"), 7, null, false, 3 },
                    { new Guid("953b1f31-d0cd-41a5-9fcc-dd30678cc060"), 3, null, false, 44 },
                    { new Guid("9549d031-eb36-4e71-a690-dea3a3808d36"), 9, null, false, 36 },
                    { new Guid("9596edf4-02a6-49a6-ba7b-a9c4ba99e4ea"), 9, null, false, 26 },
                    { new Guid("95e6d91c-69bd-41d6-a79e-cff495cc3133"), 7, null, false, 19 },
                    { new Guid("960fb449-9f26-4f95-85f2-e9b7de8a6cbd"), 1, null, false, 6 },
                    { new Guid("962a8b43-6301-4f8b-8f27-b2c5e89d89c7"), 7, null, false, 6 },
                    { new Guid("9638c536-6d93-4cd5-9caa-ea1083ffc673"), 6, null, false, 6 },
                    { new Guid("9667c131-4c8f-4bcd-ad6c-4640f6d23f0e"), 2, null, false, 32 },
                    { new Guid("968422bd-1ef1-46ed-824c-827632b9e6c8"), 1, null, false, 34 },
                    { new Guid("97e388f2-c248-4d5a-83e2-12b0c7438749"), 5, null, false, 28 },
                    { new Guid("98045c28-eda6-4a1e-8802-b9017cab9524"), 7, null, false, 32 },
                    { new Guid("9887bcbc-0c09-4902-b55a-726fbbbcc414"), 3, null, false, 45 },
                    { new Guid("98f31f1e-4e97-4db6-85ed-dc71e0babd25"), 8, null, false, 14 },
                    { new Guid("992c4103-45ce-44a9-bd2c-d450cadead88"), 7, null, false, 42 },
                    { new Guid("994545d2-4cd0-42c5-806d-8bebe6d94f11"), 6, null, false, 40 },
                    { new Guid("994df681-ceba-4f39-896a-c12b5e520ff7"), 4, null, false, 46 },
                    { new Guid("9b22150d-e1a0-4d1a-9699-a19ab9cfb5ce"), 8, null, false, 10 },
                    { new Guid("9ba5cbe3-f1ff-49c4-96c9-b0cef3b4e00f"), 9, null, false, 9 },
                    { new Guid("9c3751a8-0eea-4d4a-99eb-543663598a4d"), 7, null, false, 15 },
                    { new Guid("9c8283ee-454f-4421-aed3-1ff34db0632c"), 1, null, false, 41 },
                    { new Guid("9ec81ace-6630-4e4c-94c2-204ad6264844"), 1, null, false, 11 },
                    { new Guid("9f1893e1-e133-40e7-bef9-f24f8c22ee99"), 7, null, false, 24 },
                    { new Guid("9fd5176f-d782-4154-b5bc-f12366bb12d9"), 6, null, false, 9 },
                    { new Guid("a04e2ca6-7960-4d53-8313-33510b44bc26"), 4, null, false, 10 },
                    { new Guid("a05381d3-b607-4791-a9df-be4a9282acaa"), 3, null, false, 41 },
                    { new Guid("a0a6ae7f-fdf7-4b62-b046-85d4761a4791"), 5, null, false, 3 },
                    { new Guid("a0ccaf38-fa3d-47fe-a6ab-08c12572a81c"), 5, null, false, 18 },
                    { new Guid("a1550be9-1638-4128-b951-81198b0b9cef"), 3, null, false, 1 },
                    { new Guid("a1da0b7a-5fcb-4518-a241-1dbab31b7658"), 6, null, false, 22 },
                    { new Guid("a206c513-0f0d-498f-abcd-232fdefb1013"), 1, null, false, 4 },
                    { new Guid("a27c375a-b988-4215-a94c-a1c4e6902824"), 9, null, false, 22 },
                    { new Guid("a2a26427-307b-4504-9748-d77b4362b7be"), 2, null, false, 23 },
                    { new Guid("a340cb4e-a243-454c-8525-6ddeacbe1ca2"), 3, null, false, 18 },
                    { new Guid("a4703e43-9263-443d-a0f2-0c0d5570baa4"), 8, null, false, 44 },
                    { new Guid("a479a2ee-4d6e-446f-a2fa-909c21eeef8e"), 4, null, false, 25 },
                    { new Guid("a47b635c-1b07-4146-a181-659c866fcd38"), 6, null, false, 26 },
                    { new Guid("a5054769-21f3-4d39-b57b-54e2b455cf8e"), 5, null, false, 23 },
                    { new Guid("a76189d1-5ac6-42c8-844f-53cb921fe279"), 6, null, false, 21 },
                    { new Guid("a8bf1844-1873-425f-9cbe-000708734c32"), 2, null, false, 25 },
                    { new Guid("a8fcd5ac-59b4-4467-99f2-1cbea196c0ce"), 4, null, false, 22 },
                    { new Guid("a97f4703-eace-4dff-a5bb-c35caf93fe7e"), 1, null, false, 31 },
                    { new Guid("aa01cbb0-3120-4d63-99b3-b6a5e91e5e85"), 1, null, false, 1 },
                    { new Guid("ab5d3602-d44b-4143-b4ef-e3063ccb7821"), 9, null, false, 14 },
                    { new Guid("ac276f4b-9dc5-48ea-8493-d150b2ead9d9"), 3, null, false, 46 },
                    { new Guid("aca9f759-c6f3-4478-88fa-0f5dbe0fe5fc"), 5, null, false, 13 },
                    { new Guid("ad299d8e-901a-4d27-96a8-e0da9c35f739"), 2, null, false, 8 },
                    { new Guid("aec6a597-b7f0-4bff-b19e-346c5b6d927e"), 7, null, false, 26 },
                    { new Guid("af0af711-986f-43dd-8fed-c8caff0775de"), 2, null, false, 36 },
                    { new Guid("b06ff8bd-f483-4fbd-b5db-9dd59a20185d"), 5, null, false, 49 },
                    { new Guid("b1ff9ded-122e-43d5-b57c-142944fd9a22"), 4, null, false, 37 },
                    { new Guid("b2e21939-b188-4a68-ab4e-d45878baedbb"), 4, null, false, 17 },
                    { new Guid("b3268c5b-aa66-4c28-b3cf-9b2d108caa21"), 6, null, false, 35 },
                    { new Guid("b486309e-4714-428b-bf30-e9039901c867"), 9, null, false, 16 },
                    { new Guid("b49f232c-b3ba-46b1-8908-e6ed3ffbe355"), 7, null, false, 33 },
                    { new Guid("b4bc2b22-11c1-4049-86df-c07735c4d7c6"), 1, null, false, 16 },
                    { new Guid("b4bd70f8-ac94-498f-8a03-9f5813396757"), 5, null, false, 2 },
                    { new Guid("b5343785-5171-4aa7-8043-5fcc46a19bf7"), 1, null, false, 44 },
                    { new Guid("b5df61f5-849f-4282-a297-575c988102ca"), 9, null, false, 48 },
                    { new Guid("b64e62cc-3dc0-4608-bce9-bc061bcd582f"), 4, null, false, 30 },
                    { new Guid("b7b9304f-fbcd-45a3-b881-a0cc5bd9ccc8"), 6, null, false, 7 },
                    { new Guid("b7d130aa-4169-4e06-b8d1-57e9baed8a45"), 9, null, false, 13 },
                    { new Guid("b8ab0b0c-c872-4939-8919-8834bc9e1730"), 6, null, false, 36 },
                    { new Guid("b9742c7c-b4e6-4ea8-bf19-b0641f163f87"), 7, null, false, 46 },
                    { new Guid("ba3ba93b-d3ff-4d9c-a784-99e55b00f85b"), 6, null, false, 39 },
                    { new Guid("bad3653a-aa66-4747-8b3f-a5a299f049fd"), 8, null, false, 18 },
                    { new Guid("bb2fcdec-c632-4142-a869-73c9b975ac23"), 5, null, false, 42 },
                    { new Guid("bb55b5b9-7e21-4ff2-8153-a5a531cf4ec3"), 1, null, false, 13 },
                    { new Guid("bc0a86ee-3d85-4304-9fd1-d08fdd7a26ea"), 5, null, false, 36 },
                    { new Guid("bc817c67-7119-4570-96b3-8953d24776d6"), 8, null, false, 24 },
                    { new Guid("bcaab52d-c0db-44ed-857d-ee145fe1cabf"), 8, null, false, 19 },
                    { new Guid("bceab6d9-cc80-412b-bc1b-d122479fc7f5"), 9, null, false, 11 },
                    { new Guid("bd7b28ca-c29b-4445-9516-4d13ecd9f0e5"), 7, null, false, 25 },
                    { new Guid("bdf848bf-2c4e-4cd3-a20f-11b9ae0c99f8"), 1, null, false, 38 },
                    { new Guid("be7c116f-032f-4995-9c6d-ca13b0039644"), 3, null, false, 4 },
                    { new Guid("bed73bb5-ad82-45fc-a579-90045399787b"), 5, null, false, 21 },
                    { new Guid("bf414457-47bf-48f0-9f79-45edd90ae411"), 5, null, false, 10 },
                    { new Guid("bfe261ed-41e3-429a-bcf7-a172ac12cfb1"), 5, null, false, 32 },
                    { new Guid("c06ab36a-17f0-47bb-bb0d-f532c9996015"), 1, null, false, 49 },
                    { new Guid("c12423be-14e6-458e-a1a0-80da58160418"), 1, null, false, 42 },
                    { new Guid("c2ad9894-2753-46df-a282-00b1206c1801"), 8, null, false, 9 },
                    { new Guid("c39a6f72-1513-46aa-b25e-d064952871ab"), 4, null, false, 4 },
                    { new Guid("c3a336cb-6f3d-43d3-b30a-5d2fcfa5bc05"), 7, null, false, 22 },
                    { new Guid("c5106922-c8e4-4644-a395-e98bde53a7c0"), 8, null, false, 29 },
                    { new Guid("c5538383-d18e-465e-b115-9655e249bfeb"), 6, null, false, 3 },
                    { new Guid("c6026bd6-1818-40ad-a4a5-eac191d4043a"), 9, null, false, 32 },
                    { new Guid("c63a01d1-45b4-498b-88ee-6a33aca98e41"), 9, null, false, 19 },
                    { new Guid("c6a9a2ff-7a97-44fe-956d-8a4fc0788950"), 3, null, false, 17 },
                    { new Guid("c6bb114d-9331-4c1d-af11-ce5286363ddb"), 1, null, false, 18 },
                    { new Guid("c736ca37-3e55-4bb4-8557-a94968e0ed4f"), 6, null, false, 2 },
                    { new Guid("c7564720-bb55-41c0-862c-c5f3b6ba5a62"), 4, null, false, 45 },
                    { new Guid("c7692bce-b35b-4555-bc44-1517e0bb0574"), 4, null, false, 18 },
                    { new Guid("c7d417aa-0cb0-48f9-92b5-c490edbdf2e7"), 6, null, false, 14 },
                    { new Guid("c7fb3d2e-a1be-4006-a3c0-1e3f75133d20"), 5, null, false, 44 },
                    { new Guid("c822b298-8b8d-4e95-a575-f5bdd8e14a0a"), 8, null, false, 34 },
                    { new Guid("c8405694-4842-42f0-ad6c-4ab7e2ac3649"), 1, null, false, 27 },
                    { new Guid("c89fccc6-7cc9-4260-a60f-c1470bae6b3f"), 8, null, false, 27 },
                    { new Guid("c8ff9910-d81c-4236-a3c5-7be603d58c23"), 8, null, false, 33 },
                    { new Guid("c92cf369-65c9-4ac3-a531-dfa22f0a5a26"), 3, null, false, 37 },
                    { new Guid("ca1ecb05-4dde-4f07-aaa5-9c1f5af9d7bd"), 8, null, false, 46 },
                    { new Guid("ca398966-b78b-431d-ade9-735bca1104e7"), 7, null, false, 12 },
                    { new Guid("ca80df71-1a14-48cd-b262-6cef80b8173e"), 2, null, false, 7 },
                    { new Guid("cab7bcd8-d21d-44e7-8357-2a7eb9226e3e"), 4, null, false, 12 },
                    { new Guid("cb7b1253-cdeb-44e7-ac7f-c4b9b52d1e61"), 3, null, false, 28 },
                    { new Guid("cbc0d374-a501-4887-ad74-40112ba998d1"), 2, null, false, 31 },
                    { new Guid("cbc4a679-59d3-4452-bae8-2591fc5efba1"), 8, null, false, 1 },
                    { new Guid("cbfbc880-3d40-4911-9b31-9d4fd5b3595d"), 5, null, false, 33 },
                    { new Guid("cc57422d-de7a-4868-86e4-761e66eb1ce2"), 6, null, false, 49 },
                    { new Guid("cc5c46a2-e788-4493-858a-eb700a793c4a"), 3, null, false, 14 },
                    { new Guid("cc5ccbad-5bcf-4701-8660-3378930bc419"), 5, null, false, 24 },
                    { new Guid("cca6284c-7d05-41fb-9ce8-b5fbcec30504"), 1, null, false, 15 },
                    { new Guid("cdbbf0cf-e1ad-47db-a8b7-2765256199df"), 3, null, false, 0 },
                    { new Guid("ce7b0414-05ca-405b-87b4-6e123d973f87"), 5, null, false, 30 },
                    { new Guid("d045fd36-2c66-4991-bd44-527ec015e529"), 8, null, false, 2 },
                    { new Guid("d15730ce-1eff-4d5c-a84b-53f109739d56"), 6, null, false, 38 },
                    { new Guid("d205e3e8-625a-4d07-ba1c-50bca6ad1d89"), 1, null, false, 48 },
                    { new Guid("d2579e91-5c2b-4b4d-9a36-6e1283411d83"), 9, null, false, 33 },
                    { new Guid("d347f51c-e4d0-4cca-9308-f32df6bd9f86"), 1, null, false, 29 },
                    { new Guid("d3f1ccae-a3c6-4717-89d5-3344432181f1"), 9, null, false, 40 },
                    { new Guid("d5161071-6848-45f1-8b55-d6e689527b55"), 9, null, false, 41 },
                    { new Guid("d59cc4b1-592d-49e2-87a2-4036b75edb39"), 3, null, false, 29 },
                    { new Guid("d6973ebf-bc9a-44c4-a05a-76a8d7a3d6b9"), 5, null, false, 19 },
                    { new Guid("d7e09f50-cc46-4c3d-a702-cecb4e99867c"), 2, null, false, 10 },
                    { new Guid("d7e0a347-4331-4d6a-bf83-51c85c87a47a"), 3, null, false, 16 },
                    { new Guid("d8783dd8-b064-4cc6-b0bb-9b043981b55a"), 2, null, false, 39 },
                    { new Guid("d9069da0-ca80-415d-ac9d-0a28183f194e"), 3, null, false, 6 },
                    { new Guid("d9128839-63b4-4edf-8c69-5742d07f33ab"), 2, null, false, 37 },
                    { new Guid("d98f6b07-88f3-487b-9be7-e50965404bb3"), 3, null, false, 42 },
                    { new Guid("d9a42699-604a-4f60-8573-53c0621d8d72"), 2, null, false, 6 },
                    { new Guid("d9b22508-dc9e-4051-b2e0-6f6fc66d7362"), 9, null, false, 2 },
                    { new Guid("d9da60fc-4dec-44b2-9083-3c8b790cbb6f"), 2, null, false, 35 },
                    { new Guid("d9fb5c80-4267-4cef-9151-0477148778ff"), 8, null, false, 13 },
                    { new Guid("da1b3d16-472f-4b3e-91a9-362bc492ad51"), 6, null, false, 10 },
                    { new Guid("da66b566-2d5f-467f-9044-77af83fabb72"), 8, null, false, 12 },
                    { new Guid("da9789ec-92f0-4372-a95f-ff34787074f7"), 1, null, false, 22 },
                    { new Guid("db31610a-9f89-4db3-a62d-85de5d611ad4"), 7, null, false, 20 },
                    { new Guid("dbc444c9-266c-418a-8a61-aa25e85dd409"), 1, null, false, 25 },
                    { new Guid("dbf660f2-ad01-4c9a-b299-d0312ea68cf0"), 5, null, false, 5 },
                    { new Guid("dbf99fe1-3c7d-4661-b0bc-7ad0b92fb1a8"), 5, null, false, 4 },
                    { new Guid("dc14913d-454f-4d16-9155-c37b95787ef4"), 7, null, false, 36 },
                    { new Guid("dcc2c694-06f7-47e2-8faa-15de1a14ee8c"), 3, null, false, 21 },
                    { new Guid("dd685526-f3ee-4aea-9ab6-abfbf8687cae"), 4, null, false, 0 },
                    { new Guid("de45970d-c49a-4923-82cc-d4648df288b7"), 3, null, false, 10 },
                    { new Guid("df2ece23-71c6-4bd0-9355-9ec5a1eba6d0"), 3, null, false, 12 },
                    { new Guid("dfe89c24-1656-414e-a14c-41d8f7b09193"), 8, null, false, 15 },
                    { new Guid("e0216e43-8f17-4c8c-ba6e-740668c3109f"), 3, null, false, 47 },
                    { new Guid("e07c88eb-2721-4578-81ae-04f390681de2"), 3, null, false, 35 },
                    { new Guid("e0883162-6c81-4475-b404-6ce1e9954c62"), 4, null, false, 24 },
                    { new Guid("e17cced8-4f4f-47a0-b689-813126c09755"), 5, null, false, 31 },
                    { new Guid("e2377047-fe10-4f3f-a5f8-d96b0322256f"), 8, null, false, 0 },
                    { new Guid("e3416bf5-558a-4815-b8fc-cd2aeb568307"), 7, null, false, 11 },
                    { new Guid("e4237b27-fcce-4fbe-9af1-6c67ea75479e"), 6, null, false, 18 },
                    { new Guid("e43516ec-9057-4b67-97dd-00a6ffe658aa"), 1, null, false, 21 },
                    { new Guid("e47f24ea-3c12-467b-8696-12867b656c8d"), 7, null, false, 39 },
                    { new Guid("e4ede3e7-1f51-414e-80d0-ad9dd229c49d"), 5, null, false, 46 },
                    { new Guid("e50cdf4b-bb14-4a1a-8d4f-c8ae6fcb4d32"), 1, null, false, 26 },
                    { new Guid("e516ef20-2202-4a1a-9e74-68b460be8f6d"), 9, null, false, 10 },
                    { new Guid("e548ec86-9453-49f3-90b7-27e848b3b4c6"), 6, null, false, 29 },
                    { new Guid("e5b72653-1854-4f9d-aefe-e16b693c81ae"), 4, null, false, 49 },
                    { new Guid("e7f8debf-0df2-4a7e-877b-3c8172800a09"), 7, null, false, 16 },
                    { new Guid("e9e5adcc-b155-402e-b63e-d5539979e576"), 4, null, false, 3 },
                    { new Guid("ea892d8c-3d31-4337-b98e-4576e0e607bd"), 5, null, false, 6 },
                    { new Guid("eb8084fc-ec04-43c3-bf2f-41bafafee99f"), 8, null, false, 39 },
                    { new Guid("eb914def-1418-4f07-98d4-726fa0852403"), 5, null, false, 48 },
                    { new Guid("ece65bba-9a4e-49af-87cd-2ae5d29b3c78"), 8, null, false, 40 },
                    { new Guid("eda57961-9166-40f1-b2a8-5c85343ee268"), 4, null, false, 42 },
                    { new Guid("ee380507-bf44-4214-b97b-13201ccc2096"), 8, null, false, 49 },
                    { new Guid("ee783e6f-0c89-4d05-bee6-cd183c4f1626"), 9, null, false, 20 },
                    { new Guid("ee7a6e5d-d616-440b-b716-d2d410305d0d"), 1, null, false, 20 },
                    { new Guid("eecf25e4-dc5c-4cc1-8c1e-b7e10f689709"), 5, null, false, 35 },
                    { new Guid("eed4811d-fddd-4df8-adc9-12a8735417e1"), 5, null, false, 16 },
                    { new Guid("f0af8c46-ae8b-474a-b4b1-d409988362fa"), 5, null, false, 14 },
                    { new Guid("f186971d-7142-4fa5-b420-9a04a0422ac1"), 4, null, false, 33 },
                    { new Guid("f22c0dca-0269-42d8-b10c-a37f105844e0"), 7, null, false, 5 },
                    { new Guid("f2fb128a-470b-47aa-9f80-321dca177100"), 9, null, false, 27 },
                    { new Guid("f4ea17f7-ec07-401d-bd70-f328a92d150d"), 9, null, false, 21 },
                    { new Guid("f53642a8-9e20-4d5a-aad7-7bb05979575f"), 5, null, false, 20 },
                    { new Guid("f5922374-8213-4eb1-b909-63ce6663f7e0"), 2, null, false, 5 },
                    { new Guid("f5b7d63f-0d74-4e90-bf2c-e025847707e8"), 3, null, false, 43 },
                    { new Guid("f68388d3-f678-4ba5-893f-e0ce738c76a3"), 3, null, false, 39 },
                    { new Guid("f94f35b5-f56f-4a64-aa09-eb236c02750c"), 9, null, false, 47 },
                    { new Guid("f9700d9e-f118-4fa1-88dd-e5dd03e96ec6"), 9, null, false, 1 },
                    { new Guid("f9a1eaa0-029f-4030-9d8e-e00b5b2f2ee1"), 9, null, false, 46 },
                    { new Guid("f9aad5bc-55e0-4e69-965b-df324db8921d"), 9, null, false, 4 },
                    { new Guid("f9e477db-729b-4c53-a668-eb7f9037831c"), 4, null, false, 13 },
                    { new Guid("fa18edad-451a-44a7-a531-46401d7db4a1"), 6, null, false, 12 },
                    { new Guid("fa5c8796-1d52-4fcc-8629-cb816c2556e7"), 5, null, false, 1 },
                    { new Guid("fa9e594c-0b85-4208-8e5a-e353c9a60b54"), 6, null, false, 37 },
                    { new Guid("fae3188f-14de-4e5b-843f-932b88202e83"), 5, null, false, 25 },
                    { new Guid("faeb7ead-2216-4112-981c-42e78abb9500"), 5, null, false, 38 },
                    { new Guid("fc1805a7-7f52-4119-9ac5-2c1c5496bf1c"), 2, null, false, 38 },
                    { new Guid("fc97925f-0573-4147-90d5-d82fb00df62e"), 7, null, false, 23 },
                    { new Guid("fce5d08f-1d65-44a4-afe9-e853656d2e10"), 6, null, false, 47 },
                    { new Guid("fda76aea-5fdf-4d94-b393-2897ec357ee4"), 8, null, false, 28 },
                    { new Guid("febb559e-c03f-4c7b-a104-fc0b94e5ae07"), 2, null, false, 18 },
                    { new Guid("fef6d834-23d6-41b7-aaca-cf8f0aae1a2e"), 8, null, false, 37 },
                    { new Guid("ff1c31bd-ec36-4264-bef8-a0f12ce0e1e9"), 2, null, false, 26 },
                    { new Guid("ff71cb50-cc1c-41cb-b0ff-7d6b2d815588"), 8, null, false, 30 },
                    { new Guid("ff791e1a-7f8a-4b13-bdd4-a003313e03fc"), 7, null, false, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalChip_OwnerPersonalIdentifier",
                schema: "Dogi",
                table: "AnimalChip",
                column: "OwnerPersonalIdentifier");

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
                name: "IX_PersonBannedInformation_PersonIdentifierId",
                schema: "Dogi",
                table: "PersonBannedInformation",
                column: "PersonIdentifierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalChip",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "IndividualProceeding",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "PersonBannedInformation",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "AnimalCategory",
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
                name: "Person",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "Zone",
                schema: "Dogi");
        }
    }
}
