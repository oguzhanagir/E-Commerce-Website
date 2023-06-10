using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult BlogSingle()
        {
            return View();
        }
        public async Task<IActionResult> BlogAdminList()
        {
            var blogList = await _blogService.GetAll();
            return View(blogList);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog, IFormFile file)
        {
            if (blog != null)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = "images/blog" + fileName;

                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    blog.Image = filePath;
                }
                _blogService.Create(blog);
            }

            return RedirectToAction("BlogAdminList", "Blog");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var blog = _blogService.GetById(id);
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog blog,IFormFile file)
        {
            if (blog != null)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = "images/blog" + fileName;

                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    blog.Image = filePath;
                }
                _blogService.Update(blog);
            }

            return RedirectToAction("BlogAdminList", "Blog");
        }

        public IActionResult DeleteBlog(int id)
        {
            _blogService.Delete(id);
            return RedirectToAction("BlogAdminList", "Blog");
        }


    }
}
