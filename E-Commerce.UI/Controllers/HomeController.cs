using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce.UI.Controllers
{
    public class HomeController : Controller
    {
    

        public IActionResult Index()
        {
            return View();
        }

     
    }
}