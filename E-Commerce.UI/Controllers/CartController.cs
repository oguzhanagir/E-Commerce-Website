using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;

        public CartController(ICartService cartService, IUserService userService)
        {
            _cartService = cartService;
            _userService = userService;

        }



        public IActionResult Index()
        {
            string email = HttpContext.Session.GetString("Email")!;
            if (!string.IsNullOrEmpty(email))
            {
                var user = _userService.GetUserByMail(email);
                ViewBag.UserId = user.Id;

                var cart = _cartService.GetCartByUser(user.Id);

                if (cart != null)
                {
                    var product = _cartService.GetProductByCart(cart);
                    if (product != null)
                    {
                        ViewBag.Product = product;
                    }
                    ViewBag.UserId = user.Id;
                    return View(cart);
                }
            }

            return View();
        }

        [HttpPost]
        [Route("Cart/AddProductToCart/{id}/products/{productId}")]
        public IActionResult AddProductToCart(int id, int productId)
        {
            _cartService.AddToCart(id, productId);
            return RedirectToAction("Index", "Cart");
        }


        [HttpPost]
        [Route("Cart/RemoveProductFromCart/{userId}/products/{cartItemId}")]
        public IActionResult RemoveProductFromCart(int userId, int cartItemId)
        {
            _cartService.RemoveProductFromCart(userId, cartItemId);
            return RedirectToAction("Index", "Cart"); ;
        }

        [HttpPut("{userId}/products/{productId}")]
        public IActionResult UpdateCartItemQuantity(int userId, int productId, int quantity)
        {
            _cartService.UpdateCartItemQuantity(userId, productId, quantity);
            return Ok();
        }
    }
}
