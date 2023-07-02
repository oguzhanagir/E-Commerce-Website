using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace E_Commerce.UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CommentType = "Product";
            _commentService.Create(comment);
            return RedirectToAction("Index","Shop");
        }

        [HttpPost]
        public IActionResult AddCommentByBlog(Comment comment)
        {
            comment.CommentType = "Blog";
            _commentService.Create(comment);
            return RedirectToAction("Index", "Blog");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult DeleteComment(int id)
        {

            _commentService.Delete(id); 
            return RedirectToAction("ProductAdminList", "Shop");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult GetCommentByProductIdAdmin(int id)
        {
            var comments = _commentService.GetCommentsByProductId(id);
            return View(comments);
        }

      
    }
}
