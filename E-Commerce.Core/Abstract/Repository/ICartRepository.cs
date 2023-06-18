using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Repository
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Cart GetCartByUserId(int userId, params Expression<Func<Cart, object>>[] includeProperties);
        List<Product> GetProductByCart(Cart cart);
    }
}
