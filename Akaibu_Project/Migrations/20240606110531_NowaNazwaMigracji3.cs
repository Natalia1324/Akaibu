using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akaibu_Project.Migrations
{
    public partial class NowaNazwaMigracji3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Status_EpisodsId",
                table: "Status");

            migrationBuilder.AlterColumn<Guid>(
                name: "EpisodsId",
                table: "Status",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfProductionStart",
                value: new DateTime(2024, 6, 6, 13, 5, 31, 315, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfProductionStart",
                value: new DateTime(2024, 6, 6, 13, 5, 31, 317, DateTimeKind.Local).AddTicks(2989));

            migrationBuilder.InsertData(
                table: "Episods",
                columns: new[] { "Id", "DBAnimeId", "DateTheEpisodWasAdded", "Description", "EpisodeLenght", "Number", "Title" },
                values: new object[] { new Guid("c907670b-878e-42c7-bb70-b2d511e0b78c"), 5, new DateTime(2006, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Light Yagami finds the Death Note and starts to use it.", new TimeSpan(0, 0, 23, 0, 0), 1f, "Rebirth" });

            migrationBuilder.CreateIndex(
                name: "IX_Status_EpisodsId",
                table: "Status",
                column: "EpisodsId",
                unique: true,
                filter: "[EpisodsId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Status_EpisodsId",
                table: "Status");

            migrationBuilder.DeleteData(
                table: "Episods",
                keyColumn: "Id",
                keyValue: new Guid("c907670b-878e-42c7-bb70-b2d511e0b78c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EpisodsId",
                table: "Status",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateOfProductionStart",
                value: new DateTime(2024, 6, 6, 12, 38, 31, 212, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateOfProductionStart",
                value: new DateTime(2024, 6, 6, 12, 38, 31, 214, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.CreateIndex(
                name: "IX_Status_EpisodsId",
                table: "Status",
                column: "EpisodsId",
                unique: true);
        }
    }
}
