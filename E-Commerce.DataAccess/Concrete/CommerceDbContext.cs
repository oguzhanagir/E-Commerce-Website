using E_Commerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class CommerceDbContext : DbContext
    {
        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) : base(options)
        {

        }
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Address>? Addresses { get; set; }
        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<OrderStatus>? OrderStatuses { get; set; }
        public DbSet<Payment>? Payments { get; set; }
        public DbSet<PaymentMethod>? PaymentMethods { get; set; }
        public DbSet<PaymentStatus>? PaymentStatuses { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductImage>? ProductImages { get; set; }
    }

}
