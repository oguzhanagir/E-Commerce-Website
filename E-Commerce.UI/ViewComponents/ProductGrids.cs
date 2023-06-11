using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class ProductGrids : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductGrids(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var getBlogByBestSell =  _productService.GetAllWithCategory();
            var categoriesList = _productService.GetCategories();
            ViewBag.Categories = categoriesList;
         
            return View(getBlogByBestSell);
        }
    }
}
