using Microsoft.EntityFrameworkCore;

namespace AspireDatabaseSample.Service.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed method call here
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Game> Game { get; set; }
}