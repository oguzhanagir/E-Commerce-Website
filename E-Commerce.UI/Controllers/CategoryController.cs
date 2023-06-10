using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryList = await _categoryService.GetAll();
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (category !=null)
            {
                _categoryService.Create(category);
            }
            return RedirectToAction("Index","Category");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryService.GetById(id);
       
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (category !=null)
            {
                _categoryService.Update(category);
            }
            return RedirectToAction("Index", "Category");
        }

        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index", "Category");
        }

    }
}
