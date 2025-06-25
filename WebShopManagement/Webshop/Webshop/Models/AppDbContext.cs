using Microsoft.EntityFrameworkCore;

namespace Webshop.Models;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; } 
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
        .HasOne(x => x.User)
        .WithMany(x => x.Products)
        .HasForeignKey(x => x.UserId)
        .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Customer>()
            .HasOne(x => x.User)
            .WithMany(x => x.Customers)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
   
}