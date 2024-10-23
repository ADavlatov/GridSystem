using GridSystem.Web.Server.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GridSystem.Web.Server.Core.Contexts;

public class CoreContext : DbContext
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext()
        {
            Database.EnsureDeleted();
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
            });
        }
    }
 }