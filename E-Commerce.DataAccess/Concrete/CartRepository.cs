using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DataAccess.Concrete
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly CommerceDbContext _dbContext;
        public CartRepository(CommerceDbContext dbContext): base(dbContext)
        {
                _dbContext = dbContext;
        }

        public Cart GetCartByUserId(int userId, params Expression<Func<Cart, object>>[] includeProperties)
        {
            IQueryable<Cart> query = _dbContext.Carts!;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(c => c.UserId == userId)!;
        }

        public List<Product> GetProductByCart(Cart cart)
        {
            var productIds = cart.CartItems.Select(ci => ci.ProductId).ToList();

            var products = _dbContext.Products!
                .Where(p => productIds.Contains(p.Id))
                .Include(p => p.ProductImages)
                .ToList();

            return products;
        }

    }
}
