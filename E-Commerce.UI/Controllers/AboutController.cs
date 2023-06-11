﻿using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
                _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var about = _aboutService.GetById(2);
            return View(about);
        }

        public IActionResult AboutAdminList()
        {
            var about = _aboutService.GetById(2);
            return View(about);
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _aboutService.GetById(id);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(About about, IFormFile file)
        {
            if (about != null)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = "images/about/" + fileName;

                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    about.ImagePath = filePath;
                }
                _aboutService.Update(about);
            }

            return RedirectToAction("AboutAdminList", "About");
        }
    }
}
