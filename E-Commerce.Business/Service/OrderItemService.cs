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
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(OrderItem entity)
        {
            _unitOfWork.OrderItems.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var orderItem = _unitOfWork.OrderItems.GetById(id);
            if (orderItem != null)
            {
                _unitOfWork.OrderItems.Remove(orderItem);
                _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            return await _unitOfWork.OrderItems.GetAllAsync();
        }

        public OrderItem GetById(int id)
        {
            return _unitOfWork.OrderItems.GetById(id);
        }

        public void Update(OrderItem entity)
        {
            _unitOfWork.OrderItems.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}
