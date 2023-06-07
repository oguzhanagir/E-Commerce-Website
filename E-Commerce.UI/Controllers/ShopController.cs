using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult HomeProductList()
        {
            return View();
        }

        public IActionResult BreadCrumbs()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

       
    }
}
