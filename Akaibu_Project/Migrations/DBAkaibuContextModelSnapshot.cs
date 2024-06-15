﻿// <auto-generated />
using System;
using Akaibu_Project.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Akaibu_Project.Migrations
{
    [DbContext(typeof(DBAkaibuContext))]
    partial class DBAkaibuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("DBAnimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTheCommentWasAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid?>("EpisodsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MyRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DBAnimeId");

                    b.HasIndex("EpisodsId");

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
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("DateOfProductionFinish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfProductionStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfEpisodes")
                        .HasColumnType("int");

                    b.Property<string>("ShortStory")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("StatusAnime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

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
                            DateOfProductionStart = new DateTime(2024, 6, 15, 15, 40, 26, 536, DateTimeKind.Local).AddTicks(2087),
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
                            DateOfProductionStart = new DateTime(2024, 6, 15, 15, 40, 26, 538, DateTimeKind.Local).AddTicks(6331),
                            NumberOfEpisodes = 24,
                            ShortStory = "Short story 2",
                            StatusAnime = "Status2",
                            Tag = "Tag2",
                            Title = "Anime2"
                        });
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Episods", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DBAnimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTheEpisodWasAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<TimeSpan>("EpisodeLenght")
                        .HasColumnType("time");

                    b.Property<float>("Number")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("DBAnimeId");

                    b.ToTable("Episods");

                    b.HasData(
                        new
                        {
                            Id = new Guid("226b670d-aca3-4de5-91c1-aa83f0a049bc"),
                            DBAnimeId = 5,
                            DateTheEpisodWasAdded = new DateTime(2006, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Light Yagami finds the Death Note and starts to use it.",
                            EpisodeLenght = new TimeSpan(0, 0, 23, 0, 0),
                            Number = 1f,
                            Title = "Rebirth"
                        });
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Reports", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DBAnimeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTheReportWasAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid?>("EpisodsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReportText")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentsId");

                    b.HasIndex("DBAnimeId");

                    b.HasIndex("EpisodsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Status", b =>
                {
                    b.Property<int>("DBAnimeId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<Guid?>("EpisodsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatusValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DBAnimeId", "UsersId");

                    b.HasIndex("EpisodsId")
                        .IsUnique()
                        .HasFilter("[EpisodsId] IS NOT NULL");

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
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Nick")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20)
                        .HasAnnotation("MinLength", 8);

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
                            Password = "xxx",
                            Ranks = 1
                        },
                        new
                        {
                            Id = 9,
                            Login = "user2@example.com",
                            Nick = "User2",
                            Password = "hashed_password2",
                            Ranks = 2
                        });
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Comments", b =>
                {
                    b.HasOne("Akaibu_Project.Entions.DBAnime", "DBAnime")
                        .WithMany("Comments")
                        .HasForeignKey("DBAnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Akaibu_Project.Entions.Episods", "Episods")
                        .WithMany("Comments")
                        .HasForeignKey("EpisodsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Akaibu_Project.Entions.Users", "Users")
                        .WithMany("Commensts")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Episods", b =>
                {
                    b.HasOne("Akaibu_Project.Entions.DBAnime", "DBAnime")
                        .WithMany("Episods")
                        .HasForeignKey("DBAnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Reports", b =>
                {
                    b.HasOne("Akaibu_Project.Entions.Comments", "Comments")
                        .WithMany("Reports")
                        .HasForeignKey("CommentsId");

                    b.HasOne("Akaibu_Project.Entions.DBAnime", "DBAnime")
                        .WithMany("Reports")
                        .HasForeignKey("DBAnimeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Akaibu_Project.Entions.Episods", "Episods")
                        .WithMany("Reports")
                        .HasForeignKey("EpisodsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Akaibu_Project.Entions.Users", "Users")
                        .WithMany("Reports")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Akaibu_Project.Entions.Status", b =>
                {
                    b.HasOne("Akaibu_Project.Entions.DBAnime", "DBAnime")
                        .WithMany("Status")
                        .HasForeignKey("DBAnimeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Akaibu_Project.Entions.Episods", "Episods")
                        .WithOne("Status")
                        .HasForeignKey("Akaibu_Project.Entions.Status", "EpisodsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Akaibu_Project.Entions.Users", "Users")
                        .WithMany("Status")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
