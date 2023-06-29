using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

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
            GetUserByEmail();
            string sorting = HttpContext.Request.Query["sorting"];

            if (HttpContext.Request.RouteValues.TryGetValue("id", out var categoryIdObject))
            {
                if (int.TryParse(categoryIdObject!.ToString(), out var categoryId))
                {
                    var getProductByCategoryId = Sorting(_productService.GetAllWithCategory().Where(c => c.CategoryId == categoryId), sorting);
                    return View(getProductByCategoryId);
                }
                else
                {
                    return View("Index", "Home");
                }
            }
            else
            {
                var getProductByBestSell = Sorting(_productService.GetAllWithCategory(), sorting);
                return View(getProductByBestSell);
            }
        }

        private void GetUserByEmail()
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
        }

        private IEnumerable<Product> Sorting(IEnumerable<Product> products, string sorting)
        {
            switch (sorting)
            {
                case "price_asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "name_asc":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                default:
                    break;
            }

            return products;
        }
    }
}
