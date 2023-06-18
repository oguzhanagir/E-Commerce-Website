using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class ProfileDetails:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            // Kullanıcının e-posta bilgisini Session'dan al
            string email = HttpContext.Session.GetString("Email")!;
            if (email != null)
            {

                ViewBag.Email = email;

                return View();
            }
            else
            {

                return View();
            }
        }
    }
}
