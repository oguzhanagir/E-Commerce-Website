using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class Footer : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public Footer(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public IViewComponentResult Invoke()
        {
            var contactInfo = _aboutService.GetById(2);
            ViewBag.ContactInfoMail = contactInfo.CompanyMail;
            ViewBag.ContactInfoPhoneNumber = contactInfo.CompanyPhoneNumber;
            return View();
        }
    }
}
