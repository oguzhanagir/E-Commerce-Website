using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
               _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_userService.ValidateUser(model.Email!, model.Password!))
                {
                    // Kullanıcının bilgilerini Session'a kaydet
                    HttpContext.Session.SetString("Email", model.Email!);
                    
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Password", "Geçersiz e-posta veya şifre.");
                ViewBag.ErrorMessage = "Geçersiz e-posta veya şifre.";
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (_userService.GetCheckEmail(user.Email!))
            {
                ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanılıyor.");
                ViewBag.ErrorMessage = "Bu e-posta adresi zaten kullanılıyor.";
                return View();
            }
            else if (_userService.Register(user) == true)
            {
                ViewBag.SuccessMessage = "Kayıt başarıyla tamamlandı.";
                return View();
            }
            else
            {
                ModelState.AddModelError("PasswordConfirm", "Şifreler uyuşmuyor.");
                ViewBag.ErrorMessage = "Şifreler Uyuşmuyor";
                return View();
            }
            
        }
    }
}
