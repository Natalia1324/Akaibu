using Akaibu_Project.Entions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
namespace Akaibu_Project.Entities
{
    public class DBAkaibuContext : DbContext
    {
       
        public DBAkaibuContext(DbContextOptions<DBAkaibuContext> options) : base(options)
        {

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;

            // Dodaj tę linijkę, aby włączyć bardziej szczegółowe logowanie, w tym informacje o konfliktach kluczy
            // Może pomóc w zidentyfikowaniu, które encje powodują konflikty
            // Uwaga: Nie używaj tego w środowisku produkcyjnym z uwagi na bezpieczeństwo danych
            // DbContextOptionsBuilder.EnableSensitiveDataLogging();

        }

        public DbSet<Comments> Comments { get; set; }
        public DbSet<DBAnime> DBAnime { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Episods> Episods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Episods>(eb => {
                eb.Property(e => e.Id)
                 .ValueGeneratedOnAdd();

                eb.Property(n => n.Name).IsRequired();
                eb.Property(num => num.Number).IsRequired();
                eb.Property(desc => desc.Description).IsRequired();
                eb.Property(len => len.EpizodLenght).IsRequired();
                eb.Property(date => date.TehEoisodeWasAdded).IsRequired();
            });

            // Konfiguruje encję Users w modelu danych
            modelBuilder.Entity<Users>(eb=>{
                eb.Property(e => e.Id)
                 .ValueGeneratedOnAdd();

                // Ustawia wymaganie, żeby pola w encji Users było niepuste (nie mogą być null)
                eb.Property(nick => nick.Nick).IsRequired();
                eb.Property(login => login.Login).IsRequired();
                eb.Property(nick => nick.Ranks).IsRequired();
                eb.Property(passwd => passwd.Password).IsRequired();

                // Ustawia domyślną wartość 0 dla pola Ranks w encji Users
                eb.Property(ranks => ranks.Ranks).HasDefaultValue(0);
            });

            modelBuilder.Entity<Comments>(eb => {
                eb.Property(c => c.CommentText).IsRequired();
                eb.Property(m => m.MyRating).IsRequired();
                eb.Property(D => D.DateTheCommentWasAdded).IsRequired(); 
            });

            modelBuilder.Entity<DBAnime>(eb => {
                eb.Property(e => e.Id)
                 .ValueGeneratedOnAdd();

                eb.Property(t => t.Title).IsRequired();
                eb.Property(n => n.NumberOfEpisodes).IsRequired();
                eb.Property(a => a.Author).IsRequired();
                eb.Property(s => s.ShortStory).IsRequired();
                eb.Property(st => st.StatusAnime).IsRequired();
            });

            modelBuilder.Entity<Reports>(eb => {
                eb.Property(t => t.ReportText).IsRequired();
                eb.Property(d => d.DateTheReportWasAdded).IsRequired();
            });

            modelBuilder.Entity<Status>(eb => {
                eb.Property(le => le.LastEpizod).IsRequired();
                eb.Property(sv => sv.StatusValue).IsRequired();
            });


            // Referencje for Comments 
            modelBuilder.Entity<Users>(eb => {
                 eb.HasMany(w => w.Commensts)
                .WithOne(c => c.Users)
                .HasForeignKey(w => w.UsersId);
            });
            modelBuilder.Entity<DBAnime>(eb => {
                eb.HasMany(w => w.Comments)
                .WithOne(c => c.DBAnime)
                .HasForeignKey(w => w.DBAnimeId);
            });

            // Referencje for Reports
            modelBuilder.Entity<Users>(eb => {
                eb.HasMany(w => w.Reports)
               .WithOne(c => c.Users)
               .HasForeignKey(w => w.UsersId);
            });
            modelBuilder.Entity<DBAnime>(eb => {
                eb.HasMany(w => w.Reports)
                .WithOne(c => c.DBAnime)
                .HasForeignKey(w => w.DBAnimeId);
            });

            // Referencje for Status
            modelBuilder.Entity<Status>(eb => {
                // Definicja klucza głównego składającego się z AnimeId i UsersId
                eb.HasKey(x => new { x.DBAnimeId, x.UsersId });

                // Konfiguracja relacji wiele do jeden z tabelą Users
                eb.HasOne(x => x.Users)
                    .WithMany(u => u.Status)
                    .HasForeignKey(x => x.UsersId);

                // Konfiguracja relacji wiele do jeden z tabelą DBAnime
                eb.HasOne(x => x.DBAnime)
                    .WithMany(a => a.Status)
                    .HasForeignKey(x => x.DBAnimeId);
            });


            // Referencje for Episods
            modelBuilder.Entity<Episods>(eb => {
                eb.HasOne(w => w.DBAnime)
                .WithMany(c => c.Episods)
                .HasForeignKey(w => w.DBAnimeId);
            });
            modelBuilder.Entity<Reports>(eb => {
                eb.HasOne(w => w.Episods)
                .WithMany(c => c.Reports)
                .HasForeignKey(w => w.EpisodsId);
            });
            modelBuilder.Entity<Comments>(eb => {
                eb.HasOne(w => w.Episods)
                .WithMany(c => c.Comments)
                .HasForeignKey(w => w.EpisodsId);
            });

            SeedData(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DBAkaibu;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Przykładowe dane do tabeli DBAnime
            modelBuilder.Entity<DBAnime>().HasData(
                 new DBAnime
                 {
                     Id = 5,
                     Title = "Death Note",
                     NumberOfEpisodes = 37,
                     Author = "Madhouse",
                     ShortStory = "Yagami Light, nastoletni licealista będący prymusem w każdym przedmiocie szkolnym...",
                     Tag = "Akcja, Tajemnica, Kryminalne",
                     DateOfProductionStart = new DateTime(2006, 10, 04),
                     DateOfProductionFinish = new DateTime(2007, 06, 27),
                     StatusAnime = "Finished"
                 },
                new DBAnime
                {
                    Id = 6,
                    Title = "Shangri-La Frontier: Kusogee Hunter, Kamige ni Idoman to Su",
                    NumberOfEpisodes = 25,
                    Author = "A.C.G.T.",
                    ShortStory = "Akcja rozgrywa się w niedalekiej przyszłości, gdzie gry korzystające ze staromodnych ekranów...",
                    Tag = "Akcja, Przygodowe, Fantasy",
                    DateOfProductionStart = new DateTime(2023, 10, 01),
                    DateOfProductionFinish = null,
                    StatusAnime = "Ongoing"
                },
                new DBAnime
                {
                    Id = 7,
                    Title = "Anime1",
                    NumberOfEpisodes = 12,
                    Author = "Author1",
                    ShortStory = "Short story 1",
                    Tag = "Tag1",
                    DateOfProductionStart = DateTime.Now,
                    StatusAnime = "Status1"
                },
                new DBAnime
                {
                    Id = 8,
                    Title = "Anime2",
                    NumberOfEpisodes = 24,
                    Author = "Author2",
                    ShortStory = "Short story 2",
                    Tag = "Tag2",
                    DateOfProductionStart = DateTime.Now,
                    StatusAnime = "Status2"
                });

            // Przykładowe dane do tabeli Users
            modelBuilder.Entity<Users>().HasData(
            new Users
            {
                Id = 8,
                Nick = "User1",
                Login = "user1@example.com",
                Password = "hashed_password1", // Upewnij się, że używasz bezpiecznej metody haszowania hasła
                Ranks = 1
            },
            new Users
            {
                Id = 9,
                Nick = "User2",
                Login = "user2@example.com",
                Password = "hashed_password2",
                Ranks = 2
            }
            // Dodaj więcej danych, jeśli to konieczne
        );


            /*
             * 
             
            // Przykładowe dane do tabeli Comments
            modelBuilder.Entity<Comments>().HasData(
                new Comments
                {
                    Id = Guid.NewGuid(),
                    DateTheCommentWasAdded = DateTime.Now,
                    CommentText = "Comment 1",
                    MyRating = "5",
                    DBAnimeId = 1,
                    UsersId = 1
                },
                new Comments
                {
                    Id = Guid.NewGuid(),
                    DateTheCommentWasAdded = DateTime.Now,
                    CommentText = "Comment 2",
                    MyRating = "4",
                    DBAnimeId = 2,
                    UsersId = 2
                }
            // Dodaj więcej danych, jeśli to konieczne
            );
            
             
            // Przykładowe dane do tabeli Reports
            modelBuilder.Entity<Reports>().HasData(
                new Reports
                {
                    Id = Guid.NewGuid(),
                    ReportText = "Report 1",
                    DateTheReportWasAdded = DateTime.Now,
                    DBAnimeId = 1,
                    UsersId = 5
                },
                new Reports
                {
                    Id = Guid.NewGuid(),
                    ReportText = "Report 2",
                    DateTheReportWasAdded = DateTime.Now,
                    DBAnimeId = 2,
                    UsersId = 5
                }
            // Dodaj więcej danych, jeśli to konieczne
            );
            
            // Przykładowe dane do tabeli Status
            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    DBAnimeId = 1,
                    UsersId = 5,
                    LastEpizod = 10,
                    StatusValue = "Watched"
                },
                new Status
                {
                    DBAnimeId = 2,
                    UsersId = 5,
                    LastEpizod = 5,
                    StatusValue = "Planned"
                }
            );

            *
            */
        }
    }

}
