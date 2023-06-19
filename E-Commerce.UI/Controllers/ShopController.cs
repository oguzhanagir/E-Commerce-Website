using E_Commerce.Business.Service;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public ShopController(IProductService productService, IOrderService orderService, IUserService userService)
        {
            _productService = productService;
            _orderService = orderService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult HomeProductList()
        {
            return View();
        }

        public IActionResult BreadCrumbs()
        {
            return View();
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productService.GetById(id);

            return View(product);
        }

        public IActionResult SalesByUser()
        {
            string email = HttpContext.Session.GetString("Email")!;
            if (!string.IsNullOrEmpty(email))
            {
                var user = _userService.GetUserByMail(email);
                var orderItemByUser = _orderService.GetAllProductsByUser(user.Id);

                 return View(orderItemByUser);
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

        public IActionResult ProductAdminList()
        {
            var productList = _productService.GetAllWithCategory();
            return View(productList);
        }


        public IActionResult DeleteProduct(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("ProductAdminList", "Shop");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.Category = _productService.GetCategories();
            var product = _productService.GetById(id);
            return View(product);
        }

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
                _productService.Update(product);
            }
            return RedirectToAction("ProductAdminList", "Shop");
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Category = _productService.GetCategories();
            return View();
        }

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
    }
}
