using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _userService.ValidateUser(model.Email!, model.Password!);
            if (user != null)
            {
                HttpContext.Session.SetString("Email", model.Email!);

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Email!),
            new Claim(ClaimTypes.Role, user.RoleId == 1 ? "Customer" : "Admin")
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                if (user.RoleId == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (user.RoleId == 2)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }

            ModelState.AddModelError("Password", "Geçersiz e-posta veya şifre.");
            ViewBag.ErrorMessage = "Geçersiz e-posta veya şifre.";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Auth");
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
