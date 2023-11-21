using Akaibu_Project.Entions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Status>()
                .HasKey(x => new { x.ID_USER, x.ID_ANIME });
            //base.OnModelCreating(modelBuilder);
        }
        */
    }
}
