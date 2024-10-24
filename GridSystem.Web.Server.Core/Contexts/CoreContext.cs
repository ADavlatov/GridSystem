using GridSystem.Web.Server.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GridSystem.Web.Server.Core.Contexts;

public class CoreContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Result> Results { get; set; }

    public CoreContext()
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