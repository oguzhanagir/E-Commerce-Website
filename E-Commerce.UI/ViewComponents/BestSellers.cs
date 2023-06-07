using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class BestSellers:ViewComponent
    {
        private readonly IProductService _productService;

        public BestSellers  (IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var getBlogByBestSell = _productService.GetAll(); // BestSellers Olarak Değiştirilecektir.

            return View(getBlogByBestSell);
        }
    }
}
