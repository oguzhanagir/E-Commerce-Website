using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        public CategoryController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
            var subCategoryList = _subCategoryService.GetAllNormal();
            ViewBag.SubCategoryList = subCategoryList;
            
            return View(subCategoryList);
        }

        [HttpGet]
        public  IActionResult AddCategory()
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
        public  IActionResult AddSubCategory()
        {
            ViewBag.Categories =_categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddSubCategory(SubCategory subcategory)
        {
            if (subcategory != null)
            {
                _subCategoryService.Create(subcategory);
               
            }
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult UpdateSubCategory(int id)
        {
            var subCategory = _subCategoryService.GetById(id);
        
            return View(subCategory);
        }

        [HttpPost]
        public IActionResult UpdateSubCategory(SubCategory subcategory)
        {
            if (subcategory != null)
            {
                _subCategoryService.Update(subcategory);
            }
            return RedirectToAction("Index", "Category");
        }

        public IActionResult DeleteSubCategory(int id)
        {
            _subCategoryService.Delete(id);
            return RedirectToAction("Index", "Category");
        }

    }
}
