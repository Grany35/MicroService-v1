using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CatalogService.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItem",
                schema: "catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PictureFileName = table.Column<string>(type: "text", nullable: true),
                    AvailableStock = table.Column<int>(type: "integer", nullable: false),
                    CatalogTypeId = table.Column<int>(type: "integer", nullable: false),
                    CatalogBrandId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalSchema: "catalog",
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalSchema: "catalog",
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "CatalogBrand",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "Azure" },
                    { 2, ".NET" },
                    { 3, "Visual Studio" },
                    { 4, "SQL Server" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "CatalogType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Mug" },
                    { 2, "T-Shirt" },
                    { 3, "Sheet" },
                    { 4, "USB Memory Stick" }
                });

            migrationBuilder.InsertData(
                schema: "catalog",
                table: "CatalogItem",
                columns: new[] { "Id", "AvailableStock", "CatalogBrandId", "CatalogTypeId", "Description", "Name", "PictureFileName", "Price" },
                values: new object[,]
                {
                    { 1, 100, 2, 2, ".NET Bot Black Hoodie", ".NET Bot Black Hoodie", "1.png", 19.5m },
                    { 2, 100, 2, 1, ".NET Black & White Mug", ".NET Black & White Mug", "2.png", 8.50m },
                    { 3, 100, 5, 2, "Prism White T-Shirt", "Prism White T-Shirt", "3.png", 12m },
                    { 4, 100, 2, 2, ".NET Foundation T-shirt", ".NET Foundation T-shirt", "4.png", 12m },
                    { 5, 100, 5, 3, "Roslyn Red Sheet", "Roslyn Red Sheet", "5.png", 8.5m },
                    { 6, 100, 2, 2, ".NET Blue Hoodie", ".NET Blue Hoodie", "6.png", 12m },
                    { 7, 100, 5, 2, "Roslyn Red T-Shirt", "Roslyn Red T-Shirt", "7.png", 12m },
                    { 8, 100, 5, 2, "Kudu Purple Hoodie", "Kudu Purple Hoodie", "8.png", 8.5m },
                    { 9, 100, 5, 1, "Cup<T> White Mug", "Cup<T> White Mug", "9.png", 12m },
                    { 10, 100, 2, 3, ".NET Foundation Sheet", ".NET Foundation Sheet", "10.png", 12m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogBrandId",
                schema: "catalog",
                table: "CatalogItem",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogTypeId",
                schema: "catalog",
                table: "CatalogItem",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItem",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "CatalogBrand",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "CatalogType",
                schema: "catalog");
        }
    }
}
