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
                name: "AnimalChip",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalChip", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "ProceedingStatus",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProceedingStatus", x => x.Id)
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
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "Animal",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SexId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_Animal_Sex_SexId",
                        column: x => x.SexId,
                        principalSchema: "Dogi",
                        principalTable: "Sex",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IndividualProceeding",
                schema: "Dogi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceptionDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AnimalChipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_AnimalChip_AnimalChipId",
                        column: x => x.AnimalChipId,
                        principalSchema: "Dogi",
                        principalTable: "AnimalChip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_Animal_AnimalId",
                        column: x => x.AnimalId,
                        principalSchema: "Dogi",
                        principalTable: "Animal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_ProceedingStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Dogi",
                        principalTable: "ProceedingStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IndividualProceeding_ReceptionDocument_ReceptionDocumentId",
                        column: x => x.ReceptionDocumentId,
                        principalSchema: "Dogi",
                        principalTable: "ReceptionDocument",
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
                table: "ProceedingStatus",
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

            migrationBuilder.CreateIndex(
                name: "IX_Animal_SexId",
                schema: "Dogi",
                table: "Animal",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_AnimalChipId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "AnimalChipId",
                unique: true,
                filter: "[AnimalChipId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_AnimalId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_CategoryId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_ReceptionDocumentId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "ReceptionDocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualProceeding_StatusId",
                schema: "Dogi",
                table: "IndividualProceeding",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualProceeding",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "AnimalCategory",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "AnimalChip",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "Animal",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "ProceedingStatus",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "ReceptionDocument",
                schema: "Dogi");

            migrationBuilder.DropTable(
                name: "Sex",
                schema: "Dogi");
        }
    }
}
