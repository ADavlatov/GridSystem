using Microsoft.EntityFrameworkCore;

namespace GridSystem.Server.Database;

public class AppContext : DbContext
{
    public DbSet<FileModel> Files { get; set; }
    public AppContext() => Database.EnsureCreated();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=files.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileModel>(entity => 
        {
            entity.HasKey(x => x.Id);
        });
    }
}