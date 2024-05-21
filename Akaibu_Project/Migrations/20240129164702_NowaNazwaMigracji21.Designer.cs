﻿// <auto-generated />
using System;
using Akaibu_Project.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Akaibu_Project.Migrations
{
    [DbContext(typeof(DBAkaibuContext))]
    [Migration("20240129164702_NowaNazwaMigracji21")]
    partial class NowaNazwaMigracji21
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Akaibu_Project.Entions.Comments", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DBAnimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTheCommentWasAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("MyRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DBAnimeId");

                    b.HasIndex("UsersId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Akaibu_Project.Entions.DBAnime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfProductionFinish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfProductionStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfEpisodes")
                        .HasColumnType("int");

                    b.Property<string>("ShortStory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusAnime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DBAnime");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Author = "Madhouse",
                            DateOfProductionFinish = new DateTime(2007, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfProductionStart = new DateTime(2006, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfEpisodes = 37,
                            ShortStory = "Yagami Light, nastoletni licealista będący prymusem w każdym przedmiocie szkolnym...",
                            StatusAnime = "Finished",
                            Tag = "Akcja, Tajemnica, Kryminalne",
                            Title = "Death Note"
                        },
                        new
                        {
                            Id = 6,
                            Author = "A.C.G.T.",
                            DateOfProductionStart = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NumberOfEpisodes = 25,
                            ShortStory = "Akcja rozgrywa się w niedalekiej przyszłości, gdzie gry korzystające ze staromodnych ekranów...",
                            StatusAnime = "Ongoing",
                            Tag = "Akcja, Przygodowe, Fantasy",
                            Title = "Shangri-La Frontier: Kusogee Hunter, Kamige ni Idoman to Su"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Author1",
                            DateOfProductionStart = new DateTime(2024, 1, 29, 17, 47, 1, 644, DateTimeKind.Local).AddTicks(6443),
                            NumberOfEpisodes = 12,
                            ShortStory = "Short story 1",
                            StatusAnime = "Status1",
                            Tag = "Tag1",
                            Title = "Anime1"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Author2",
                            DateOfProductionStart = new DateTime(2024, 1, 29, 17, 47, 1, 647, DateTimeKind.Local).AddTicks(5886),
                            NumberOfEpisodes = 24,
                            ShortStory = "Short story 2",
                            StatusAnime = "Status2",
                            Tag = "Tag2",
                            Title = "Anime2"
                        });
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Reports", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DBAnimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTheReportWasAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReportText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DBAnimeId");

                    b.HasIndex("UsersId");

                    b.ToTable("Reports");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8cb30645-4ee4-414b-9fbd-bebe70d6dda3"),
                            DBAnimeId = 5,
                            DateTheReportWasAdded = new DateTime(2024, 1, 29, 17, 47, 1, 648, DateTimeKind.Local).AddTicks(9953),
                            ReportText = "Report 1",
                            UsersId = 8
                        },
                        new
                        {
                            Id = new Guid("aa834721-774d-4a28-a084-d0de32412b8e"),
                            DBAnimeId = 6,
                            DateTheReportWasAdded = new DateTime(2024, 1, 29, 17, 47, 1, 649, DateTimeKind.Local).AddTicks(661),
                            ReportText = "Report 2",
                            UsersId = 9
                        });
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Status", b =>
                {
                    b.Property<int>("DBAnimeId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("LastEpizod")
                        .HasColumnType("int");

                    b.Property<string>("StatusValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DBAnimeId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ranks")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            Login = "user1@example.com",
                            Nick = "User1",
                            Password = "hashed_password1",
                            Ranks = 1
                        },
                        new
                        {
                            Id = 9,
                            Login = "user2@example.com",
                            Nick = "User2",
                            Password = "hashed_password2",
                            Ranks = 2
                        },
                        new
                        {
                            Id = 10,
                            Bans = "GD lutowanie studenta <3 ",
                            Login = "user3@example.com",
                            Nick = "User3",
                            Password = "hashed_password3",
                            Ranks = 69
                        },
                        new
                        {
                            Id = 21,
                            Bans = "GD lutowanie studenta <3 ",
                            Login = "user4@example.com",
                            Nick = "User4",
                            Password = "hashed_password3",
                            Ranks = 69
                        });
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Comments", b =>
                {
                    b.HasOne("Akaibu_Project.Entions.DBAnime", "DBAnime")
                        .WithMany("Comments")
                        .HasForeignKey("DBAnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Akaibu_Project.Entions.Users", "Users")
                        .WithMany("Commensts")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Reports", b =>
                {
                    b.HasOne("Akaibu_Project.Entions.DBAnime", "DBAnime")
                        .WithMany("Reports")
                        .HasForeignKey("DBAnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Akaibu_Project.Entions.Users", "Users")
                        .WithMany("Reports")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Status", b =>
                {
                    b.HasOne("Akaibu_Project.Entions.DBAnime", "DBAnime")
                        .WithMany("Status")
                        .HasForeignKey("DBAnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Akaibu_Project.Entions.Users", "Users")
                        .WithMany("Status")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}