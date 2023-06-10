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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Order entity)
        {
            _unitOfWork.Orders.Add(entity);
            _unitOfWork.CompleteAsync();
        }

        public void Delete(int id)
        {
            var order = _unitOfWork.Orders.GetById(id);
            if (order != null)
            {
                _unitOfWork.Orders.Remove(order);
                _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public Order GetById(int id)
        {
            return _unitOfWork.Orders.GetById(id);
        }

        public void Update(Order entity)
        {
            _unitOfWork.Orders.Update(entity);
            _unitOfWork.CompleteAsync();
        }
    }
}
