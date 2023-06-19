using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class MainCategory:ViewComponent
    {

        private readonly ICategoryService _categoryService;

        public MainCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var getAllCategory = _categoryService.GetAllNormalWithFive();

            return View(getAllCategory);
        }
    }
}
