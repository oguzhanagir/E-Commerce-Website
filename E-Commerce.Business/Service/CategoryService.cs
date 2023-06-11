using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections;
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
            _unitOfWork.Categories.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category != null)
            {
                _unitOfWork.Categories.Remove(category);
                _unitOfWork.CompleteAsync();
            }
        }

        public  IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Categories.GetAll();
        }

        public IEnumerable<Category> GetAllNormal()
        {
            return _unitOfWork.Categories.GetAll(x=>x.SubCategories!);
        }

        public Task<int> GetProductCountWithCategory(int id)
        {
            var countProduct = _unitOfWork.Products.GetCountByCategoryId(id);
            return countProduct;
        }

        public Category GetById(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }

        public void Update(Category entity)
        {
            _unitOfWork.Categories.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }

}
