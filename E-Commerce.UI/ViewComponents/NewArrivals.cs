using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class NewArrivals : ViewComponent
    {
        private readonly IProductService _productService;

        public NewArrivals(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var getBlogByNew = _productService.GetNewArrivalsToThree();

            return View(getBlogByNew);
        }
    }
}
