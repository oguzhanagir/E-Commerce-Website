using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class SpecialOffer : ViewComponent
    {
        private readonly IProductService _productService;

        public SpecialOffer(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var getBlogBySpecial = _productService.GetAll(); // Special Olarak Değiştirilecektir.

            return View(getBlogBySpecial);
        }
    }
}
