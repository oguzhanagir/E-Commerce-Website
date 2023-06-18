using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Service
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(Cart entity)
        {
            _unitOfWork.Carts.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var about = _unitOfWork.Carts.GetById(id);
            if (about != null)
            {
                _unitOfWork.Carts.Remove(about);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<Cart> GetAll()
        {
            return _unitOfWork.Carts.GetAll();
        }

        public Cart GetById(int id)
        {
            return _unitOfWork.Carts.GetById(id);
        }

        public void Update(Cart entity)
        {
            _unitOfWork.Carts.Update(entity);
            _unitOfWork.CompleteAsync();
        }

        public void AddToCart(int userId, int productId )
        {
            var cart = _unitOfWork.Carts.GetCartByUserId(userId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };
            }

            var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }

            _unitOfWork.CompleteAsync();
        }


        public Cart GetCartByUser(int id)
        {
            var cart = _unitOfWork.Carts.GetCartByUserId(id,x=>x.CartItems);
            return cart;
        }

        public List<Product> GetProductByCart(Cart cart)
        {
            var product = _unitOfWork.Carts.GetProductByCart(cart);
            return product!;
        }



        public void RemoveProductFromCart(int userId, int cartItemId)
        {
            var cart = _unitOfWork.Carts.GetCartByUserId(userId,x=>x.CartItems);
            if (cart != null)
            {
                var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
                if (existingCartItem != null)
                {
                    cart.CartItems.Remove(existingCartItem);
                    _unitOfWork.CompleteAsync();
                }
            }
        }

        public void UpdateCartItemQuantity(int userId, int productId, int quantity)
        {
            var cart = _unitOfWork.Carts.GetCartByUserId(userId);
            if (cart != null)
            {
                var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity = quantity;
                    _unitOfWork.CompleteAsync();
                }
            }
        }
    }
}
