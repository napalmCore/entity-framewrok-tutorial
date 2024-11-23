using Microsoft.EntityFrameworkCore;

namespace EFTuto.Models
{
    public class EFTutoDbContext : DbContext
    {
        public EFTutoDbContext(DbContextOptions<EFTutoDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

    }
}