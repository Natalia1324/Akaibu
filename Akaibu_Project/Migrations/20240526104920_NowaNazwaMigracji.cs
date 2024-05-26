﻿using System;
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
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    NumberOfEpisodes = table.Column<int>(nullable: false),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    ShortStory = table.Column<string>(maxLength: 2000, nullable: true),
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
                    Nick = table.Column<string>(maxLength: 20, nullable: false),
                    Login = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
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
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Number = table.Column<float>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
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
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTheCommentWasAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    CommentText = table.Column<string>(maxLength: 500, nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UsersId",
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
                    StatusValue = table.Column<string>(nullable: false),
                    EpisodsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => new { x.DBAnimeId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_Status_DBAnime_DBAnimeId",
                        column: x => x.DBAnimeId,
                        principalTable: "DBAnime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Status_Episods_EpisodsId",
                        column: x => x.EpisodsId,
                        principalTable: "Episods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Status_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReportText = table.Column<string>(maxLength: 500, nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Episods_EpisodsId",
                        column: x => x.EpisodsId,
                        principalTable: "Episods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bans", "Login", "Nick", "Password", "Ranks" },
                values: new object[] { 8, null, "user1@example.com", "User1", "hashed_password1", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bans", "Login", "Nick", "Password", "Ranks" },
                values: new object[] { 9, null, "user2@example.com", "User2", "hashed_password2", 2 });

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
                name: "IX_Status_EpisodsId",
                table: "Status",
                column: "EpisodsId",
                unique: true);

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
