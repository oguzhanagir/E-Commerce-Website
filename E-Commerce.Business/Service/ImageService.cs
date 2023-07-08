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
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(ProductImage entity)
        {
            _unitOfWork.Images.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var image = _unitOfWork.Images.GetById(id);
            if (image != null)
            {
                _unitOfWork.Images.Remove(image);
                _unitOfWork.CompleteAsync();
            }
        }

        public  IEnumerable<ProductImage> GetAll()
        {
            return  _unitOfWork.Images.GetAll();
        }

        public ProductImage GetById(int id)
        {
            return _unitOfWork.Images.GetById(id);
        }

        public void Update(ProductImage entity)
        {
            _unitOfWork.Images.Update(entity);
            _unitOfWork.CompleteAsync();
        }

        public IEnumerable<ProductImage> GetByProductId(int id)
        {
            var images = _unitOfWork.Images.GetAll().Where(x => x.ProductId == id);
            return images;
        }

    }
}
