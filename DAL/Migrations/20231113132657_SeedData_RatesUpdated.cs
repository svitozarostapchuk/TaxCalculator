using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SeedData_RatesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rate",
                value: 40);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rate",
                value: 20);
        }
    }
}
