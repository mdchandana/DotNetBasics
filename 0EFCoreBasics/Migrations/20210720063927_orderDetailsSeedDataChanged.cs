using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _0EFCoreBasics.Migrations
{
    public partial class orderDetailsSeedDataChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderedDate",
                value: new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderedDate",
                value: new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "Qty", "UnitPrice" },
                values: new object[] { 1, 70000.00m });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderId", "ProductId", "Discount", "Qty", "UnitPrice" },
                values: new object[] { 2, 2, 0m, 1, 50000.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderedDate",
                value: new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderedDate",
                value: new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "Qty", "UnitPrice" },
                values: new object[] { 2, 50000.00m });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderId", "ProductId", "Discount", "Qty", "UnitPrice" },
                values: new object[] { 2, 4, 0m, 2, 70000.00m });
        }
    }
}
