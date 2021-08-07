using Microsoft.EntityFrameworkCore.Migrations;

namespace _0EFCoreBasics.Migrations
{
    public partial class productSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { 1, 1, "hp dv6", 220000.00m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { 2, 2, "iphone 7", 75000.00m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Name", "Price" },
                values: new object[] { 3, 2, "samsung s7", 87000.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
