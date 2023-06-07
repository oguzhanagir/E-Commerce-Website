using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class PaymentMethodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
