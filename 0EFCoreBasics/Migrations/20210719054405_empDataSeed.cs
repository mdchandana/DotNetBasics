using Microsoft.EntityFrameworkCore.Migrations;

namespace _0EFCoreBasics.Migrations
{
    public partial class empDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "sidath" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "chandana" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "yasiru" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
