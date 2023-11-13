using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "BottomLimit", "Category", "Rate", "UpperLimit" },
                values: new object[] { 1, 0, 0, 0, 5000 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "BottomLimit", "Category", "Rate", "UpperLimit" },
                values: new object[] { 2, 5001, 1, 20, 20000 });

            migrationBuilder.InsertData(
                table: "TaxBands",
                columns: new[] { "Id", "BottomLimit", "Category", "Rate", "UpperLimit" },
                values: new object[] { 3, 20001, 2, 20, 2147483647 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaxBands",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
