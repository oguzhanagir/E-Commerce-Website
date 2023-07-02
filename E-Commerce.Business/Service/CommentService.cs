using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Service
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Comment entity)
        {
            _unitOfWork.Comments.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var comment = _unitOfWork.Comments.GetById(id);
            if (comment != null)
            {
                _unitOfWork.Comments.Remove(comment);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<Comment> GetAll()
        {
            return _unitOfWork.Comments.GetAll();
        }

        public Comment GetById(int id)
        {
            return _unitOfWork.Comments.GetById(id);
        }

        public void Update(Comment entity)
        {
            _unitOfWork.Comments.Update(entity);
            _unitOfWork.CompleteAsync();
        }

        public IEnumerable<Comment> GetCommentsByProductId(int id)
        {
            var comments = _unitOfWork.Comments.GetCommentByProductId(id).Where(x=>x.CommentType == "Product");
            return comments;
        }


        public IEnumerable<Comment> GetCommentListTypeBlog(int id)
        {
            var commentsBlog = _unitOfWork.Comments.GetCommentByBlogId(id).Where(x => x.CommentType == "Blog");
            return commentsBlog;
        }



    }
}
