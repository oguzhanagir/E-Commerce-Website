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
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(OrderStatus entity)
        {
            _unitOfWork.OrderStatuses.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var orderStatus = _unitOfWork.OrderStatuses.GetById(id);
            if (orderStatus != null)
            {
                _unitOfWork.OrderStatuses.Remove(orderStatus);
                _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<OrderStatus>> GetAll()
        {
            return await _unitOfWork.OrderStatuses.GetAllAsync();
        }

        public OrderStatus GetById(int id)
        {
            return _unitOfWork.OrderStatuses.GetById(id);
        }

        public void Update(OrderStatus entity)
        {
            _unitOfWork.OrderStatuses.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

