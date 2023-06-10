using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class TrendProducts:ViewComponent
    {
        private readonly IProductService _productService;

        public TrendProducts(IProductService productService)
        {
            _productService = productService;
        }

        public  IViewComponentResult Invoke()
        {
            var getBlogByTrend =  _productService.GetAllWithCategory(); 

            return View(getBlogByTrend);
        }
    }
}
