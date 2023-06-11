using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class LatestBlogs: ViewComponent
    {
        private readonly IBlogService _blogService;

        public LatestBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var getLatestBlogs = _blogService.GetLatestBlogToThree();

            return View(getLatestBlogs);
        }
    }
}
