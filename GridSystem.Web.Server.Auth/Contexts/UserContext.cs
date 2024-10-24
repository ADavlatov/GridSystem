using GridSystem.Web.Server.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace GridSystem.Web.Server.Auth.Contexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results { get; set; }

        public UserContext()
        {
            Database.EnsureCreated();
        }

        //@TODO заменить на постгресс, для тестов используется sqlite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Users.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => 
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.Results).WithOne(x => x.User);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.User).WithMany(x => x.Results);
            });
        }
    }
}