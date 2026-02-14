using Microsoft.EntityFrameworkCore;
using MvcCrudApp.Models;

namespace MvcCrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Price = 499.99m, CategoryId = 2 },
                new Product { Id = 3, Name = "Novel", Price = 19.99m, CategoryId = 3 }
            );

        }
    }
}
