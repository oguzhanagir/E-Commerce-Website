using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly CommerceDbContext _dbContext;
        public ProductRepository(CommerceDbContext dbContext ): base( dbContext )
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetPopularProduct()
        {
            var popularProducts =  _dbContext.Products!.OrderByDescending(p => p.Price).Take(10).ToList();
            return popularProducts;
        }
    }
}
