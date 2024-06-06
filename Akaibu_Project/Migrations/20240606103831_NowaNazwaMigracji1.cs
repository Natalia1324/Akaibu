using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akaibu_Project.Migrations
{
    public partial class NowaNazwaMigracji1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DBAnime",
                columns: new[] { "Id", "Author", "DateOfProductionFinish", "DateOfProductionStart", "NumberOfEpisodes", "ShortStory", "StatusAnime", "Tag", "Title" },
                values: new object[,]
                {
                    { 5, "Madhouse", new DateTime(2007, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2006, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "Yagami Light, nastoletni licealista będący prymusem w każdym przedmiocie szkolnym...", "Finished", "Akcja, Tajemnica, Kryminalne", "Death Note" },
                    { 6, "A.C.G.T.", null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Akcja rozgrywa się w niedalekiej przyszłości, gdzie gry korzystające ze staromodnych ekranów...", "Ongoing", "Akcja, Przygodowe, Fantasy", "Shangri-La Frontier: Kusogee Hunter, Kamige ni Idoman to Su" },
                    { 7, "Author1", null, new DateTime(2024, 6, 6, 12, 38, 31, 212, DateTimeKind.Local).AddTicks(7758), 12, "Short story 1", "Status1", "Tag1", "Anime1" },
                    { 8, "Author2", null, new DateTime(2024, 6, 6, 12, 38, 31, 214, DateTimeKind.Local).AddTicks(5997), 24, "Short story 2", "Status2", "Tag2", "Anime2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DBAnime",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
