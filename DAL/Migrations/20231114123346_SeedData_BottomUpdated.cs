using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SeedData_BottomUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 1,
                column: "BottomLimit",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 1,
                column: "BottomLimit",
                value: 0);
        }
    }
}
