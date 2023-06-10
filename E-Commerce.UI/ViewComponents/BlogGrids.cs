using E_Commerce.Core.Abstract.Service;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.UI.ViewComponents
{
    public class BlogGrids : ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogGrids(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var blogList =  _blogService.GetAllNormal(); 

            return View(blogList);
        }
    }
}
