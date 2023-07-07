using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using E_Commerce.UI.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

[assembly: ResourceLocation("Resources")]
[assembly: RootNamespace("E_Commerce.UI")]

namespace E_Commerce.UI.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
     
        public HomeController(IProductService productService)
        {
            _productService = productService;
            

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult ShippingInfo()
        {

            return View();
        }

        public IActionResult Footer()
        {
            return View();
        }


        public IActionResult Search(string query)
        {
            var search = _productService.SearchProduct(query);

            return View(search);
        }

    }
}