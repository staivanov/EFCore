using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarData.Migrations
{
    public partial class GetAllCountriesByFirstLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE SelectCountryByFirstLetter @Letter CHAR(1)
                                    AS
                                    SELECT *
                                    FROM [dbo].[ProductionCountries]
                                    WHERE [Name] LIKE @Letter + '%'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC SelectCountryByFirstLetter");
        }
    }
}
