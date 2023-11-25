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
        }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<DBAnime> DBAnime { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Users> Users { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder){



            // Konfiguruje encję Users w modelu danych
            modelBuilder.Entity<Users>(eb=>{
               
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
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DBAkaibu;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

    }

}
