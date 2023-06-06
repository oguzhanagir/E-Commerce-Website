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
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Order>? Orders { get; set; }
    }

}
