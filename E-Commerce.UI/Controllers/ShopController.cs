using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace E_Commerce.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        private readonly ISubCategoryService _subCategoryService;

        public ShopController(IProductService productService, IOrderService orderService, IUserService userService, ICommentService commentService,ISubCategoryService subCategoryService)
        {
            _productService = productService;
            _orderService = orderService;
            _userService = userService;
            _commentService = commentService;
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProductGrids(int categoryId)
        {
            var getProductByCategoryId = _productService.GetAllWithCategoryById(categoryId);
            return ViewComponent("ProductGrids", getProductByCategoryId);
        }


        public IActionResult HomeProductList()
        {
            return View();
        }


        public IActionResult BreadCrumbs()
        {
            ViewBag.PageTitle = "Ürünler";
            ViewBag.PageRoot = "Ana Sayfa";
            ViewBag.PageController = "Mağaza";
            return View();
        }
      
        public IActionResult ProductDetails(int id)
        {
            var product = _productService.GetById(id);
            ViewBag.Point = _productService.GetPointByProductId(id);

            var comments = _commentService.GetCommentsByProductId(id);
            ViewBag.Comments = comments;
            return View(product);
        }

        public IActionResult SalesByUser()
        {
            string email = HttpContext.Session.GetString("Email")!;
            if (!string.IsNullOrEmpty(email))
            {
                var user = _userService.GetUserByMail(email);
                var orders = _orderService.GetByUserId(user.Id);

                 return View(orders);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Checkout()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        public IActionResult ProductAdminList()
        {
            var productList = _productService.GetAllWithCategory();
            return View(productList);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("ProductAdminList", "Shop");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            
       

            List<SelectListItem> categories = (from x in _productService.GetCategories()
                                           select new SelectListItem
                                           {
                                               Text = x.Name,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.Category = categories;

            List<SelectListItem> subCategories = (from x in _subCategoryService.GetAllNormal()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.SubCategories = subCategories;

            var product = _productService.GetById(id);
            return View(product);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product, List<IFormFile> files)

        {
            if (product != null)
            {
                if (files != null && files.Count > 0)
                {
                    var imageList = new List<ProductImage>(); // Image listesi burada tanımlanır

                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var filePath = "images/product/" + fileName;

                            using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            var image = new ProductImage
                            {
                                ImagePath = filePath,
                                ProductId = product.Id
                            };

                            imageList.Add(image); // Her bir image nesnesi imageList'e eklenir
                        }
                    }

                    product.ProductImages = imageList;
                }
                else
                {
                    var findProduct = _productService.GetById(product.Id);
                    product.ProductImages = findProduct.ProductImages;
                }
                
                _productService.Update(product);
            }
            return RedirectToAction("ProductAdminList", "Shop");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> categories = (from x in _productService.GetCategories()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.Category = categories;

            List<SelectListItem> subCategories = (from x in _subCategoryService.GetAllNormal()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
            ViewBag.SubCategories = subCategories;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, List<IFormFile> files)
        {

            if (product != null)
            {
                if (files != null && files.Count > 0)
                {
                    var imageList = new List<ProductImage>(); // Image listesi burada tanımlanır

                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var filePath = "images/product/" + fileName;

                            using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            var image = new ProductImage
                            {
                                ImagePath = filePath,
                                ProductId = product.Id
                            };

                            imageList.Add(image); // Her bir image nesnesi imageList'e eklenir
                        }
                    }

                    product.ProductImages = imageList; // product.ProductImages özelliğine imageList atanır
                }

                _productService.Create(product);
            }

            return RedirectToAction("ProductAdminList", "Shop");

        }
    
        
        public IActionResult GetProductByCategory(int id)
        {
            var products = _productService.GetAllWithCategoryById(id);
            ViewBag.Categories = _productService.GetCategories();
       
            return View(products);
        }

        public IActionResult GetProductBySubCategory(int id)
        {
            var products = _productService.GetAllWithSubCategoryById(id);
            ViewBag.Categories = _productService.GetCategories();
          
            return View(products);
        }
    }
}
