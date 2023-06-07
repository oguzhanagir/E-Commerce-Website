using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class TopRated : ViewComponent
    {
        private readonly IProductService _productService;

        public TopRated(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var getBlogByTopRated = _productService.GetAll(); // TopRated Olarak Değiştirilecektir.

            return View(getBlogByTopRated);
        }
    }
}
