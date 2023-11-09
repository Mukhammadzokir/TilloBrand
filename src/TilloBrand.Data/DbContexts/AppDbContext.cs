using Microsoft.EntityFrameworkCore;
using TilloBrand.Domain.Entities;

namespace TilloBrand.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders {  get; set; }
    public DbSet<Market> Markets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Market)  
            .WithMany(m => m.Products) 
            .HasForeignKey(p => p.MarketId);
    }
}