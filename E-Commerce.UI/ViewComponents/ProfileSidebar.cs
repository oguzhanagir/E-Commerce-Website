using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class ProfileSidebar : ViewComponent
    {
        private readonly IUserService _userService;

        public ProfileSidebar(IUserService userService)
        {
                _userService = userService;
        }
        public IViewComponentResult Invoke()
        {
            // Kullanıcının e-posta bilgisini Session'dan al
            string email = HttpContext.Session.GetString("Email")!;
            if (email != null)
            {
                ViewBag.Email = email;
                var user = _userService.GetUserByMail(email);
                return View(user);
            }
            else
            {

                return View();
            }
        }
    }
}
