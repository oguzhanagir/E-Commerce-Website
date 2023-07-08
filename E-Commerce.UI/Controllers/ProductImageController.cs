using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace E_Commerce.UI.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IImageService _imageService;

        public ProductImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public IActionResult AddProductImage(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> AddProductImage(ProductImage productImage, IFormFile file)
        {
            if (productImage != null)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = "images/product/" + fileName;

                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    productImage.ImagePath = filePath;
                }
                productImage.Id = 0;
            _imageService.Create(productImage);
            }

            return RedirectToAction("UpdateProductImage", new { id = productImage!.ProductId });
        }


        [HttpGet]
        public IActionResult UpdateProductImage(int id)
        {
            var productImageList = _imageService.GetByProductId(id);
            ViewBag.ProductId = id;
            return View(productImageList);
        }


        public IActionResult DeleteProductImage(int id, int productId)
        {
            _imageService.Delete(id);
           
            return RedirectToAction("UpdateProductImage", new { id = productId });
        }
    }
}
