using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class MainHeader:ViewComponent
    {
        private readonly IProductService _productService;


        public MainHeader(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var getBlogByPopular = _productService.GetPopularProducts();
          
            return View(getBlogByPopular);
        }
    }
}
