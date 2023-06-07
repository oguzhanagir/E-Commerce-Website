using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogGrids()
        {
            return View();
        }
        public IActionResult BlogSingle()
        {
            return View();
        }
    }
}
