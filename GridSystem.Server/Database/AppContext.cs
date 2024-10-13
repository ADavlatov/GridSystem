using Microsoft.EntityFrameworkCore;

namespace GridSystem.Server.Database;

public class AppContext : DbContext
{
    public DbSet<FileModel> Files { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=files.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileModel>(entity => 
        {
            entity.HasKey(x => x.Id);
            entity.HasOne(x => x.Name);
            entity.HasOne(x => x.Bytes);
        });
    }
}