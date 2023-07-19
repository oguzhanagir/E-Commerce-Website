using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Reflection.Metadata;

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
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var categoryList = _categoryService.GetAllNormal();
            
            
            return View(categoryList);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public  IActionResult AddCategory()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category, IFormFile file)
        {
            if (category != null)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = "images/category/" + fileName;

                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    category.Image = filePath;
                }
                _categoryService.Create(category);
            }

          
           
            return RedirectToAction("Index","Category");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public  IActionResult AddSubCategory()
        {
            ViewBag.Categories =_categoryService.GetAll();
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddSubCategory(SubCategory subcategory)
        {
            if (subcategory != null)
            {
                _subCategoryService.Create(subcategory);
               
            }
            return RedirectToAction("Index", "Category");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateSubCategory()
        {
            ViewBag.SubCategory = _categoryService.GetSubCategories();
            ViewBag.Category = _categoryService.GetCategories();
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult UpdateSubCategory(SubCategory subcategory)
        {
            if (subcategory != null)
            {
                _subCategoryService.Update(subcategory);
            }
            return RedirectToAction("Index", "Category");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateMainCategory(int id)
        {
            ViewBag.Category = _categoryService.GetAllNormal();

            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async  Task<IActionResult> UpdateMainCategory(Category category, IFormFile file)
        {
            if (category != null)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = "images/category/" + fileName;

                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    category.Image = filePath;
                }
                _categoryService.Update(category);
            }
            return RedirectToAction("Index", "Category");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult DeleteSubCategory(int id)
        {
            _subCategoryService.Delete(id);
            return RedirectToAction("Index", "Category");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index", "Category");
        }


      

    }
}
