using Microsoft.EntityFrameworkCore;
using SimpleDDD.Domain.Entity;

namespace SimpleDDD.Infrastructure;

public class BaseDbContext:DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Table> Tables{ get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnStr"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
