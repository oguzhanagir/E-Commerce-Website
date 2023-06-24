using E_Commerce.Core.Abstract.Service;
using E_Commerce.UI.Languages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace E_Commerce.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<Lang> _stringLocalizer;

        public HomeController(IStringLocalizer<Lang> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShippingInfo()
        {
            ViewBag.ShippingInfo = _stringLocalizer["shippingInfo.Shipping"];
            return View();
        }

        public IActionResult Footer()
        {
            return View();
        }




    }
}