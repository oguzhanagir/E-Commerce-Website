using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class ContactController : Controller
    {
        private IAboutService _aboutService;

        public ContactController(IAboutService aboutService)
        {
                _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            var about = _aboutService.GetById(2);
            return View(about);
        }
    }
}
