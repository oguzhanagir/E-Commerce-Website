using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class FeaturedCategories : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public FeaturedCategories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var getAllCategory = _categoryService.GetAll(); 

            return View(getAllCategory);
        }
    }
}
