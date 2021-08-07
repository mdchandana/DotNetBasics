using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JqueryAjaxJson.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeePosition_EmployeePositionId",
                        column: x => x.EmployeePositionId,
                        principalTable: "EmployeePosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLeave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HalfFullLeaveType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLeave_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmployeePosition",
                columns: new[] { "Id", "Position", "PositionCode" },
                values: new object[,]
                {
                    { 1, "Irrigation Engineer", "IE" },
                    { 2, "Engineer Assistant", "EA" },
                    { 3, "Development Officer", "DO" },
                    { 4, "Management Assistant", "MA" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Address", "EmployeePositionId", "Name" },
                values: new object[,]
                {
                    { 1, "Matara", 1, "Buddika" },
                    { 2, "Matara", 2, "Perl" },
                    { 3, "Galle", 2, "Bandusiri" },
                    { 4, "Weeraketiya", 2, "Ranaweera" },
                    { 5, "Dickwella", 3, "Kumara" },
                    { 6, "Middeniya", 3, "Lucky" },
                    { 7, "Matara", 3, "Udayanga" },
                    { 8, "Matara", 4, "Anjana" },
                    { 9, "Matara", 4, "Hansika" },
                    { 10, "Matara", 4, "Gamage" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeePositionId",
                table: "Employee",
                column: "EmployeePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeave_EmployeeId",
                table: "EmployeeLeave",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLeave");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeePosition");
        }
    }
}
