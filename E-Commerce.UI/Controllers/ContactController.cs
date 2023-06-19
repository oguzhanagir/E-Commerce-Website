using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

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
            var about = _aboutService.GetById(2);
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
            return View();
        }
    
        public IActionResult ContactMessageList()
        {
            var contactList = _contactService.GetAll();
            return View(contactList);
        }
    }
}
