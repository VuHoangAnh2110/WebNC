using Microsoft.EntityFrameworkCore;
using MVC04.Models;

namespace MVC04.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> tblProducts { get; set; }
        public DbSet<Member> tblMembers {get; set; }
        public DbSet<Nhanxet> tblNhanxet {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Thiết lập khóa ngoại cho bảng NhanXet
            modelBuilder.Entity<Nhanxet>()
                .HasOne(n => n.Product)
                .WithMany(p => p.NhanXets)
                .HasForeignKey(n => n.FK_iProductID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Nhanxet>()
                .HasOne(n => n.Member)
                .WithMany(m => m.NhanXets)
                .HasForeignKey(n => n.FK_MemberID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    
}
