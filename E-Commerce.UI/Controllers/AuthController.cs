﻿using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
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
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    HttpContext.Session.SetString("Email", model.Email!);
                    // Kullanıcının bilgilerini Session'a kaydet

                    // Rol bilgisini claims olarak ekleyin
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email!),
                new Claim(ClaimTypes.Role, user.RoleId == 1 ? "Customer" : "Admin")
            };

                    var identity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(principal);

                    if (user.RoleId == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (user.RoleId == 0)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Geçersiz e-posta veya şifre.");
                    ViewBag.ErrorMessage = "Geçersiz e-posta veya şifre.";
                }
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
