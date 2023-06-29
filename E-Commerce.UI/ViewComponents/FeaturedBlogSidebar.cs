using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class FeaturedBlogSidebar:ViewComponent
    {
        private readonly IBlogService _blogService;

        public FeaturedBlogSidebar(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var blogList = _blogService.GetAllNormal().Take(3);

            return View(blogList);
        }
    }
}
