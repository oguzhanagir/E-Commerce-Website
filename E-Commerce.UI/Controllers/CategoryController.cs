using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
