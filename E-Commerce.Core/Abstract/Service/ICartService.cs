using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface ICartService : IGenericService<Cart>
    {
        Cart GetCartByUser(int id);
        void AddToCart(int productId, int userId);
        void RemoveProductFromCart(int userId, int productId);
        void UpdateCartItemQuantity(int userId, int productId, int quantity);
 
        List<Product> GetProductByCart(Cart cart);
    }
}
