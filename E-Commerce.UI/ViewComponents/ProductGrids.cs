using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class ProductGrids : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public ProductGrids(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var categoriesList = _productService.GetCategories();
            ViewBag.Categories = categoriesList;
            string email = HttpContext.Session.GetString("Email")!;
            if (!string.IsNullOrEmpty(email))
            {
                var user = _userService.GetUserByMail(email);
                ViewBag.UserId = user.Id;

            }
            else
            {
                ViewBag.UserId = 0;

            }

            if (HttpContext.Request.RouteValues.TryGetValue("id", out var categoryIdObject))
            {
                if (int.TryParse(categoryIdObject!.ToString(), out var categoryId))
                {
                    var getProductByCategoryId = _productService.GetAllWithCategoryById(categoryId);
                    return View(getProductByCategoryId);
                }
                else
                {
                    return View("Index","Home");
                }
            }
            else
            {
                var getProductByBestSell = _productService.GetAllWithCategory();
                return View(getProductByBestSell);
            }
        }
    }
}
