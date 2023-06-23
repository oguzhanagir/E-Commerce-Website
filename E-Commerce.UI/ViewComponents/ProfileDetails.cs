using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class ProfileDetails:ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
          
                return View();
            
        }
    }
}
