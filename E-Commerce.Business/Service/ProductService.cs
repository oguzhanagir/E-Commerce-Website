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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Product entity)
        {
            _unitOfWork.Products.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var product = _unitOfWork.Products.GetByIdAsync(id);
            if (product != null)
            {
                await _unitOfWork.Products.DeleteAsync(product);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public Product GetById(int id)
        {
            return _unitOfWork.Products.GetByIdAsync(id);
        }

        public void Update(Product entity)
        {
            _unitOfWork.Products.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}
