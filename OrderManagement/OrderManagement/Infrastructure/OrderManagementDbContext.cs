using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Infrastructure
{
    public class OrderManagementDbContext : DbContext
    {
        public OrderManagementDbContext() { }
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options) { }
    
        public DbSet<Product> TbProducts { get; set; }
        public DbSet<Order> TbOrders { get; set; }
        public DbSet<Customer> TbCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.OwnsOne(p => p.PriceMoney, price =>
                {
                    price.Property(p => p.MoneyValueAmount)
                         .HasPrecision(18, 2)
                         .IsRequired();

                    price.Property(p => p.MoneyValueAmount)
                         .HasMaxLength(10)
                         .IsRequired();
                });
            });
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderItem>(entity =>
        //    {
        //        entity.HasKey(x => x.Id);

        //        entity.OwnsOne(x => x.UnitPrice, money =>
        //        {
        //            money.Property(m => m.Amount)
        //                 .HasPrecision(18, 2)
        //                 .IsRequired();

        //            money.Property(m => m.Currency)
        //                 .HasMaxLength(10)
        //                 .IsRequired();
        //        });
        //    });
        //}


    }
}
