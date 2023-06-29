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
    public class SubscribeService : ISubscribeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscribeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Subscribe entity)
        {
            _unitOfWork.Subscribes.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var subscribe = _unitOfWork.Subscribes.GetById(id);
            if (subscribe != null)
            {
                _unitOfWork.Subscribes.Remove(subscribe);
                _unitOfWork.CompleteAsync();
            }
        }

        public IEnumerable<Subscribe> GetAll()
        {
            return _unitOfWork.Subscribes.GetAll();
        }

        public Subscribe GetById(int id)
        {
            return _unitOfWork.Subscribes.GetById(id);
        }

        public void Update(Subscribe entity)
        {
            _unitOfWork.Subscribes.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}
