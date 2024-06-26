using BillingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingAPI.Data
{
    public class BillingContext : DbContext
    {
        public BillingContext(DbContextOptions<BillingContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<BillingLine> BillingLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billing>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Billings)
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<BillingLine>()
                .HasOne(bl => bl.Billing)
                .WithMany(b => b.Lines)
                .HasForeignKey(bl => bl.BillingId);

            modelBuilder.Entity<BillingLine>()
                .HasOne(bl => bl.Product)
                .WithMany(p => p.BillingLines)
                .HasForeignKey(bl => bl.ProductId);

            modelBuilder.Entity<Billing>()
      .Property(b => b.TotalAmount)
      .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BillingLine>()
                .Property(bl => bl.Subtotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<BillingLine>()
                .Property(bl => bl.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
