using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _0EFCoreBasics.Migrations
{
    public partial class orderAndOrderDetailsSeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "OrderedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 2, new DateTime(2021, 7, 19, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price", "QtyInStock" },
                values: new object[] { "hp dv5", 175000.00m, 5 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Name", "Price" },
                values: new object[] { 1, "hp dv6", 200000.00m });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Price" },
                values: new object[] { "iphone 6s", 50000.00m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "QtyInStock" },
                values: new object[] { 4, 2, "iphone 7", 70000.00m, 5 });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderId", "ProductId", "Discount", "Qty", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 0m, 1, 175000.00m },
                    { 1, 2, 0m, 1, 200000.00m },
                    { 2, 3, 0m, 2, 50000.00m },
                    { 2, 4, 0m, 2, 70000.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Price", "QtyInStock" },
                values: new object[] { "hp dv6", 220000.00m, 2 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Name", "Price" },
                values: new object[] { 2, "iphone 7", 75000.00m });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Price" },
                values: new object[] { "samsung s7", 87000.00m });
        }
    }
}
