using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akaibu_Project.Migrations
{
    public partial class Raports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfProductionStart",
                value: new DateTime(2023, 12, 29, 19, 6, 26, 604, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfProductionStart",
                value: new DateTime(2023, 12, 29, 19, 6, 26, 607, DateTimeKind.Local).AddTicks(3511));

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "DBAnimeId", "DateTheReportWasAdded", "ReportText", "UsersId" },
                values: new object[,]
                {
                    { new Guid("bedb3442-51bf-49ee-bea2-9c8faf466980"), 5, new DateTime(2023, 12, 29, 19, 6, 26, 608, DateTimeKind.Local).AddTicks(6014), "Report 1", 8 },
                    { new Guid("b4d92219-e380-4e7f-965c-458e5ef3587a"), 6, new DateTime(2023, 12, 29, 19, 6, 26, 608, DateTimeKind.Local).AddTicks(6705), "Report 2", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("b4d92219-e380-4e7f-965c-458e5ef3587a"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("bedb3442-51bf-49ee-bea2-9c8faf466980"));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfProductionStart",
                value: new DateTime(2023, 12, 18, 17, 35, 23, 761, DateTimeKind.Local).AddTicks(7594));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfProductionStart",
                value: new DateTime(2023, 12, 18, 17, 35, 23, 764, DateTimeKind.Local).AddTicks(1127));
        }
    }
}
