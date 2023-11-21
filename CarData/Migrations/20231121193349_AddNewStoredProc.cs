using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarData.Migrations
{
    public partial class AddNewStoredProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE SelectAllBrandsFromCountry @Country NVARCHAR(MAX) AS
                    SELECT B.[Name] FROM [dbo].[ProductionCountries] AS PC
                    INNER JOIN [dbo].[BrandProductionCountry] AS BP
                    ON PC.ProductionCountryId = BP.ProductionCountriesProductionCountryId
                    LEFT JOIN [dbo].[Brands] AS B
                    ON BP.BrandsBrandId = B.BrandId
                    WHERE PC.[Name] = @Country");


            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC SelectAllBrandsFromCountry");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, "Porsche" },
                    { 2, "BMW" },
                    { 3, "Mercedes" },
                    { 4, "VW" },
                    { 5, "Toyota" },
                    { 6, "Lexus" }
                });
        }
    }
}
