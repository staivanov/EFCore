using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarData.Migrations
{
    public partial class BrandAndProductionCountriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionCountries",
                columns: table => new
                {
                    ProductionCountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISO3166Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountries", x => x.ProductionCountryId);
                });

            migrationBuilder.CreateTable(
                name: "BrandProductionCountry",
                columns: table => new
                {
                    BrandsBrandId = table.Column<int>(type: "int", nullable: false),
                    ProductionCountriesProductionCountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandProductionCountry", x => new { x.BrandsBrandId, x.ProductionCountriesProductionCountryId });
                    table.ForeignKey(
                        name: "FK_BrandProductionCountry_Brands_BrandsBrandId",
                        column: x => x.BrandsBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandProductionCountry_ProductionCountries_ProductionCountriesProductionCountryId",
                        column: x => x.ProductionCountriesProductionCountryId,
                        principalTable: "ProductionCountries",
                        principalColumn: "ProductionCountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandProductionCountry_ProductionCountriesProductionCountryId",
                table: "BrandProductionCountry",
                column: "ProductionCountriesProductionCountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandProductionCountry");

            migrationBuilder.DropTable(
                name: "ProductionCountries");
        }
    }
}
