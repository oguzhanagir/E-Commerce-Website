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
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Blog entity)
        {
            _unitOfWork.Blogs.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public  void Delete(int id)
        {
            var blog = _unitOfWork.Blogs.GetById(id);
            if (blog != null)
            {
                 _unitOfWork.Blogs.Remove(blog);
                _unitOfWork.CompleteAsync();
            }
        }

        public   IEnumerable<Blog> GetAll()
        {
            return _unitOfWork.Blogs.GetAll();
        }

        public IEnumerable<Blog> GetAllNormal()
        {
            return _unitOfWork.Blogs.GetAll();
        }

        public IEnumerable<Blog> GetLatestBlogToThree()
        {
            return _unitOfWork.Blogs.GetLatestBlogToThree();
        }

        public Blog GetById(int id)
        {
            var blog = _unitOfWork.Blogs.GetById(id);
            return blog!;
        }

        public List<Blog> GetByIdList(int id)
        {
            var blog = _unitOfWork.Blogs.List(x=>x.Id == id);
            return blog!;
        }

        public void Update(Blog entity)
        {
            _unitOfWork.Blogs.Update(entity);
            _unitOfWork.CompleteAsync();
        }

        public List<string> GetBlogCategoryList()
        {
            var blogList = _unitOfWork.Blogs.GetAll();
            var categoryList = blogList.Select(blog => blog.BlogCategory).Distinct().ToList();

            return categoryList;
        }

    }
}
