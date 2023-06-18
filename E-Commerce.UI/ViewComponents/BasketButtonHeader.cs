using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class BasketButtonHeader : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly IUserService _userService;

        public BasketButtonHeader(ICartService cartService,IUserService userService)
        {
            _cartService = cartService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            string email = HttpContext.Session.GetString("Email")!;
            if (!string.IsNullOrEmpty(email))
            {
               var user = _userService.GetUserByMail(email);
                ViewBag.UserId = user.Id;
                var cart = _cartService.GetCartByUser(user.Id);
                if (cart != null)
                {
                    ViewBag.CartItemCount = cart.CartItems.Sum(ci => ci.Quantity);

                }
            }
            else
            {
                ViewBag.UserId = 0; 
                ViewBag.CartItemCount = 0;
            }

           

            return View();
        }
    }
}
