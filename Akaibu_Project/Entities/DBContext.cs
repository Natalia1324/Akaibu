using Akaibu_Project.Entions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
namespace Akaibu_Project.Entities
{
    public class DBAkaibu : DbContext
    {
        public DBAkaibu(DbContextOptions<DBAkaibu> options):base (options) {
        
        }
        public DbSet<Comments> comments { get; set; }
        public DbSet<DBAnime> anime{ get; set; }
        public DbSet<Reports> reports { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<Users> users { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            // Konfiguruje encję Users w modelu danych
            modelBuilder.Entity<Users>(eb=>{
               
                // Ustawia wymaganie, żeby pola w encji Users było niepuste (nie mogą być null)
                eb.Property(nick => nick.Nick).IsRequired();
                eb.Property(login => login.Login).IsRequired();
                eb.Property(nick => nick.Nick).IsRequired();
                eb.Property(passwd => passwd.Password).IsRequired();

                // Ustawia domyślną wartość 0 dla pola Ranks w encji Users
                eb.Property(ranks => ranks.Ranks).HasDefaultValue(0);
            });

            modelBuilder.Entity<Comments>(eb => {
                eb.Property(x => x.DateTheCommentWasAdded).HasDefaultValueSql("getutcdate");
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
    }



    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Akaibu_Project;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
    */
    
}
