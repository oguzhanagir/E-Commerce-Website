using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class BlogCategoryList : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogCategoryList(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var blogCategorList = _blogService.GetBlogCategoryList();
            ViewBag.CategoryList = blogCategorList;
            return View();
        }
    }
}
