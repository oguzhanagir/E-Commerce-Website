using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class AllCategoryHeader : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public AllCategoryHeader(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var getAllCategory = _categoryService.GetAllNormal();

            return View(getAllCategory);
        }

    }
}
