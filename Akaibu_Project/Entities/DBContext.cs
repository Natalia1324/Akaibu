using Akaibu_Project.Entions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
namespace Akaibu_Project.Entities
{
    public class DBAkaibu : DbContext
    {
        public DBAkaibu(DbContextOptions<DBAkaibu> options):base (options) {
        
        }
        public DbSet<Comments> comments { get; set; }
        public DbSet<DB_ANIME> anime{ get; set; }
        public DbSet<Reports> reports { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<Users> users { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Status>()
                .HasKey(x => new { x.ID_USER, x.ID_ANIME });
            //base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Users>(eb=>{
                eb.Property(nick => nick.Nick).IsRequired();
                eb.Property(login => login.Login).IsRequired();
                eb.Property(nick => nick.Nick).IsRequired();
                eb.Property(passwd => passwd.Password).IsRequired();

                eb.Property(ranks => ranks.Ranks).HasDefaultValue(0);
            });

            modelBuilder.Entity<Comments>(eb => {
                eb.Property(x => x.Date_The_comment_was_added).HasDefaultValueSql("getutcdate");
            });
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Akaibu_Project;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
