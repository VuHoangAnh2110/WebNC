using Microsoft.EntityFrameworkCore;
using MVC04.Models;

namespace MVC04.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> tblProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductName)
                .IsUnique(); // Đảm bảo ProductName không trùng
        }
    }

    
}
