using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class ChangePassword: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
