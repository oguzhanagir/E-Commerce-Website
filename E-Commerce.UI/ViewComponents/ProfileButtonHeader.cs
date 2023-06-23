using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class ProfileButtonHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string email = HttpContext.Session.GetString("Email")!;
           if (email == null)
            {
                ViewBag.User = false;
                return View();
            }
            else
            {
                ViewBag.User = true;
                return View();
            }
        }
    }
}
