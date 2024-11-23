using Microsoft.EntityFrameworkCore;

namespace EFTuto.Models
{
    public class EFTutoDbContext : DbContext
    {
        public EFTutoDbContext(DbContextOptions<EFTutoDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price);

            modelBuilder.Entity<OrderItem>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
            .Property(p => p.SubTotal)
            .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Order>()
            .Property(p => p.Tax)
            .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Order>()
        .Property(p => p.Total)
        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
.Property(p => p.Shipping)
.HasColumnType("decimal(18,2)");
        }
    }
}