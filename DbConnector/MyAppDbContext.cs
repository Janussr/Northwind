using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace Northwind.DbConnector
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {
        }

        // DbSet for your entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entities and their relationships
            modelBuilder.Entity<Product>().HasKey(e => e.ProductId);
            // Additional configuration
            modelBuilder.Entity<Supplier>().HasKey(e => e.SupplierId);
            // Alternatively, you can use separate configuration classes:
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyAppDbContext).Assembly);
        }
    }
}
