using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akaibu_Project.Migrations
{
    public partial class NowaNazwaMigracji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfProductionStart",
                value: new DateTime(2023, 12, 17, 12, 3, 8, 840, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfProductionStart",
                value: new DateTime(2023, 12, 17, 12, 3, 8, 842, DateTimeKind.Local).AddTicks(6187));
        }
    }
}
