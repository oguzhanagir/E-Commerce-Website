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
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AboutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(About entity)
        {
            _unitOfWork.Abouts.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public  void Delete(int id)
        {
            var about = _unitOfWork.Abouts.GetById(id);
            if (about != null)
            {
                 _unitOfWork.Abouts.Remove(about);
                 _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<About>> GetAll()
        {
            return await _unitOfWork.Abouts.GetAllAsync();
        }

        public About GetById(int id)
        {
            return _unitOfWork.Abouts.GetById(id);
        }

        public void Update(About entity)
        {
            _unitOfWork.Abouts.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}
