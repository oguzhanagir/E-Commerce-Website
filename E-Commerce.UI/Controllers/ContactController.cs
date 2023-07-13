using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.UI.Controllers
{
    public class ContactController : Controller
    {
        private IAboutService _aboutService;
        private IContactService _contactService;

        public ContactController(IAboutService aboutService,IContactService contactService)
        {
                _aboutService = aboutService;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var about = _aboutService.GetAll().First();
            return View(about);
        }


        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            if (contact == null)
            {
                ViewBag.ErrorMessage = "Geçersiz iletişim bilgileri.";
                return View();
            }

            _contactService.Create(contact);
            ViewBag.SuccessMessage = "İletişim bilgileri başarıyla eklendi.";
            return RedirectToAction("Index","Contact");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult ContactMessageList()
        {
            var contactList = _contactService.GetAll();
            return View(contactList);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult DeleteContact(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction("ContactMessageList", "Contact");
        }

       
    }
}
