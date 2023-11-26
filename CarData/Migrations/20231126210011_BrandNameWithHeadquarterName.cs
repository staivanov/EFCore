using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarData.Migrations
{
    public partial class BrandNameWithHeadquarterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [BrandsNamesWithHeadquarterName] AS
                                SELECT B.[Name] AS [BrandName], H.[Name] AS [HeadquarterName]
                                FROM [dbo].[Brands] B
                                INNER JOIN [dbo].[Headquarter] H
                                ON B.BrandId = H.BrandId");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW [BrandsNamesWithHeadquarterName] ");
        }
    }
}
