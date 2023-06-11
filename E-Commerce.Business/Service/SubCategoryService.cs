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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(SubCategory entity)
        {
            _unitOfWork.SubCategories.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var subCategory = _unitOfWork.SubCategories.GetById(id);
            if (subCategory != null)
            {
                _unitOfWork.SubCategories.Remove(subCategory);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return  _unitOfWork.SubCategories.GetAll();
        }

        public IEnumerable<SubCategory> GetAllNormal()
        {
            return _unitOfWork.SubCategories.GetAll(x=>x.Category!);
        }

        public SubCategory GetById(int id)
        {
            return _unitOfWork.SubCategories.GetById(id);
        }

        public void Update(SubCategory entity)
        {
            _unitOfWork.SubCategories.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }

}
