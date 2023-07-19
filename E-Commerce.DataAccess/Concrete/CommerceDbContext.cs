using E_Commerce.Entity.Concrete;
using E_Commerce.Entity.Concrete.ar;
using E_Commerce.Entity.Concrete.en;
using E_Commerce.Entity.Concrete.ru;
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
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<CartItem>? CartItems { get; set; }
        public DbSet<Cargo>? Cargoes { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Subscribe>? Subscribes { get; set; }
        public DbSet<SubCategory>? SubCategories { get; set; }


        public DbSet<AboutEN>? AboutENs { get; set; }
        public DbSet<BlogEN>? BlogENs { get; set; }
        public DbSet<ProductEN>? ProductENs { get; set; }
        public DbSet<CategoryEN>? CategoryENs { get; set; }
        public DbSet<SubCategoryEN>? SubCategoryENs { get; set; }


        public DbSet<AboutRU>? AboutRUs { get; set; }
        public DbSet<BlogRU>? BlogRUs { get; set; }
        public DbSet<ProductRU>? ProductRUs { get; set; }
        public DbSet<CategoryRU>? CategoryRUs { get; set; }
        public DbSet<SubCategoryRU>? SubCategoryRUs { get; set; }


        public DbSet<AboutAR>? AboutARs { get; set; }
        public DbSet<BlogAR>? BlogARs { get; set; }
        public DbSet<ProductAR>? ProductARs { get; set; }
        public DbSet<CategoryAR>? CategoryARs { get; set; }

        public DbSet<SubCategoryAR>? SubCategoryARs { get; set; }
    }

}
