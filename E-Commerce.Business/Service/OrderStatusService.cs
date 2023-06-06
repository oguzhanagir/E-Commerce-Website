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
            _unitOfWork.OrderStatuses.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var orderStatus = _unitOfWork.OrderStatuses.GetByIdAsync(id);
            if (orderStatus != null)
            {
                await _unitOfWork.OrderStatuses.DeleteAsync(orderStatus);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<OrderStatus>> GetAll()
        {
            return await _unitOfWork.OrderStatuses.GetAllAsync();
        }

        public OrderStatus GetById(int id)
        {
            return _unitOfWork.OrderStatuses.GetByIdAsync(id);
        }

        public void Update(OrderStatus entity)
        {
            _unitOfWork.OrderStatuses.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}

