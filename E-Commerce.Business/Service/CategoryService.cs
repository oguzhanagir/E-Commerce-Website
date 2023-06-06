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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Category entity)
        {
            _unitOfWork.Categories.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var category = _unitOfWork.Categories.GetByIdAsync(id);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public Category GetById(int id)
        {
            return _unitOfWork.Categories.GetByIdAsync(id);
        }

        public void Update(Category entity)
        {
            _unitOfWork.Categories.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}
