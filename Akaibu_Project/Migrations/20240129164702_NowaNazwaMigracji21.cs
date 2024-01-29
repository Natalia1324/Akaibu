using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akaibu_Project.Migrations
{
    public partial class NowaNazwaMigracji21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("7c71cdb4-16bd-485b-a4ea-6a4ccb03e00a"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8be05363-8e07-42d0-9e1a-d66adedefd1d"));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfProductionStart",
                value: new DateTime(2024, 1, 29, 17, 47, 1, 644, DateTimeKind.Local).AddTicks(6443));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfProductionStart",
                value: new DateTime(2024, 1, 29, 17, 47, 1, 647, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "DBAnimeId", "DateTheReportWasAdded", "ReportText", "UsersId" },
                values: new object[,]
                {
                    { new Guid("8cb30645-4ee4-414b-9fbd-bebe70d6dda3"), 5, new DateTime(2024, 1, 29, 17, 47, 1, 648, DateTimeKind.Local).AddTicks(9953), "Report 1", 8 },
                    { new Guid("aa834721-774d-4a28-a084-d0de32412b8e"), 6, new DateTime(2024, 1, 29, 17, 47, 1, 649, DateTimeKind.Local).AddTicks(661), "Report 2", 9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("8cb30645-4ee4-414b-9fbd-bebe70d6dda3"));

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: new Guid("aa834721-774d-4a28-a084-d0de32412b8e"));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfProductionStart",
                value: new DateTime(2024, 1, 29, 17, 42, 29, 548, DateTimeKind.Local).AddTicks(9111));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfProductionStart",
                value: new DateTime(2024, 1, 29, 17, 42, 29, 551, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "DBAnimeId", "DateTheReportWasAdded", "ReportText", "UsersId" },
                values: new object[,]
                {
                    { new Guid("7c71cdb4-16bd-485b-a4ea-6a4ccb03e00a"), 5, new DateTime(2024, 1, 29, 17, 42, 29, 553, DateTimeKind.Local).AddTicks(837), "Report 1", 8 },
                    { new Guid("8be05363-8e07-42d0-9e1a-d66adedefd1d"), 6, new DateTime(2024, 1, 29, 17, 42, 29, 553, DateTimeKind.Local).AddTicks(1535), "Report 2", 9 }
                });
        }
    }
}
