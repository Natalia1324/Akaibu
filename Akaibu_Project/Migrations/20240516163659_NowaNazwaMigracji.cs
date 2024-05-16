using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akaibu_Project.Migrations
{
    public partial class NowaNazwaMigracji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBAnime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    NumberOfEpisodes = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    ShortStory = table.Column<string>(nullable: true),
                    Tag = table.Column<string>(nullable: true),
                    DateOfProductionStart = table.Column<DateTime>(nullable: false),
                    DateOfProductionFinish = table.Column<DateTime>(nullable: true),
                    StatusAnime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBAnime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nick = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Ranks = table.Column<int>(nullable: false, defaultValue: 0),
                    Bans = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Episods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Number = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    EpisodeLenght = table.Column<TimeSpan>(nullable: false),
                    DateTheEpisodWasAdded = table.Column<DateTime>(nullable: false),
                    DBAnimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episods_DBAnime_DBAnimeId",
                        column: x => x.DBAnimeId,
                        principalTable: "DBAnime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    UsersId = table.Column<int>(nullable: false),
                    DBAnimeId = table.Column<int>(nullable: false),
                    LastEpizod = table.Column<int>(nullable: false),
                    StatusValue = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => new { x.DBAnimeId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_Status_DBAnime_DBAnimeId",
                        column: x => x.DBAnimeId,
                        principalTable: "DBAnime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Status_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTheCommentWasAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CommentText = table.Column<string>(nullable: false),
                    MyRating = table.Column<string>(nullable: true),
                    DBAnimeId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false),
                    EpisodsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_DBAnime_DBAnimeId",
                        column: x => x.DBAnimeId,
                        principalTable: "DBAnime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Episods_EpisodsId",
                        column: x => x.EpisodsId,
                        principalTable: "Episods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReportText = table.Column<string>(nullable: false),
                    DateTheReportWasAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DBAnimeId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false),
                    CommentsId = table.Column<Guid>(nullable: false),
                    EpisodsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_DBAnime_DBAnimeId",
                        column: x => x.DBAnimeId,
                        principalTable: "DBAnime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Episods_EpisodsId",
                        column: x => x.EpisodsId,
                        principalTable: "Episods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DBAnime",
                columns: new[] { "Id", "Author", "DateOfProductionFinish", "DateOfProductionStart", "NumberOfEpisodes", "ShortStory", "StatusAnime", "Tag", "Title" },
                values: new object[,]
                {
                    { 5, "Madhouse", new DateTime(2007, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2006, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, "Yagami Light, nastoletni licealista będący prymusem w każdym przedmiocie szkolnym...", "Finished", "Akcja, Tajemnica, Kryminalne", "Death Note" },
                    { 6, "A.C.G.T.", null, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, "Akcja rozgrywa się w niedalekiej przyszłości, gdzie gry korzystające ze staromodnych ekranów...", "Ongoing", "Akcja, Przygodowe, Fantasy", "Shangri-La Frontier: Kusogee Hunter, Kamige ni Idoman to Su" },
                    { 7, "Author1", null, new DateTime(2024, 5, 16, 18, 36, 59, 635, DateTimeKind.Local).AddTicks(2868), 12, "Short story 1", "Status1", "Tag1", "Anime1" },
                    { 8, "Author2", null, new DateTime(2024, 5, 16, 18, 36, 59, 637, DateTimeKind.Local).AddTicks(8812), 24, "Short story 2", "Status2", "Tag2", "Anime2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bans", "Login", "Nick", "Password", "Ranks" },
                values: new object[,]
                {
                    { 8, null, "user1@example.com", "User1", "hashed_password1", 1 },
                    { 9, null, "user2@example.com", "User2", "hashed_password2", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DBAnimeId",
                table: "Comments",
                column: "DBAnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EpisodsId",
                table: "Comments",
                column: "EpisodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UsersId",
                table: "Comments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Episods_DBAnimeId",
                table: "Episods",
                column: "DBAnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CommentsId",
                table: "Reports",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DBAnimeId",
                table: "Reports",
                column: "DBAnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EpisodsId",
                table: "Reports",
                column: "EpisodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UsersId",
                table: "Reports",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_UsersId",
                table: "Status",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Episods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DBAnime");
        }
    }
}
