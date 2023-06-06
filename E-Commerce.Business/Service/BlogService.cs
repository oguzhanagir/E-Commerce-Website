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
            _unitOfWork.Blogs.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var blog = _unitOfWork.Blogs.GetByIdAsync(id);
            if (blog != null)
            {
                await _unitOfWork.Blogs.DeleteAsync(blog);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Blog>> GetAll()
        {
            return await _unitOfWork.Blogs.GetAllAsync();
        }

        public Blog GetById(int id)
        {
            return _unitOfWork.Blogs.GetByIdAsync(id);
        }

        public void Update(Blog entity)
        {
            _unitOfWork.Blogs.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}
