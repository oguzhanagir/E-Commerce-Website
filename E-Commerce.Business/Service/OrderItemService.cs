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
            _unitOfWork.OrderItems.AddAsync(entity);
            _unitOfWork.CompleteAsync();
        }

        public async void Delete(int id)
        {
            var orderItem = _unitOfWork.OrderItems.GetByIdAsync(id);
            if (orderItem != null)
            {
                await _unitOfWork.OrderItems.DeleteAsync(orderItem);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            return await _unitOfWork.OrderItems.GetAllAsync();
        }

        public OrderItem GetById(int id)
        {
            return _unitOfWork.OrderItems.GetByIdAsync(id);
        }

        public void Update(OrderItem entity)
        {
            _unitOfWork.OrderItems.UpdateAsync(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}
