using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akaibu_Project.Migrations
{
    public partial class project : Migration
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
                    ShortStory = table.Column<string>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    DateOfProductionStart = table.Column<DateTime>(nullable: false),
                    DateOfProductionFinish = table.Column<DateTime>(nullable: true),
                    StatusAnime = table.Column<string>(nullable: false)
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
                    Ranks = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTheCommentWasAdded = table.Column<DateTime>(nullable: false),
                    CommentText = table.Column<string>(nullable: false),
                    MyRating = table.Column<string>(nullable: false),
                    DBAnimeId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false)
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
                    DateTheReportWasAdded = table.Column<DateTime>(nullable: false),
                    DBAnimeId = table.Column<int>(nullable: false),
                    UsersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_DBAnime_DBAnimeId",
                        column: x => x.DBAnimeId,
                        principalTable: "DBAnime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DBAnimeId",
                table: "Comments",
                column: "DBAnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UsersId",
                table: "Comments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DBAnimeId",
                table: "Reports",
                column: "DBAnimeId");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "DBAnime");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
