using E_Commerce.Core.Abstract.Repository;
using E_Commerce.Core.Abstract.Service;
using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public IEnumerable<Order> GetAll()
        {
            var orders = _unitOfWork.Orders.GetAll(
                order => order.OrderItems!,
                order => order.ShippingAddress!,
                order => order.Payment!,
                order => order.User!
               );

            foreach (var order in orders)
            {
                foreach (var orderItem in order.OrderItems!)
                {
                    orderItem.Product = _unitOfWork.Products.GetById(orderItem.ProductId);
                    orderItem.Product.Category = _unitOfWork.Categories.GetById(orderItem.Product.CategoryId); // Category'yi include et
                }
            }

            return orders;
        }



        public IEnumerable<OrderItem> GetAllProductsByUser(int id)
        {
            var orders = _unitOfWork.Orders.GetListByUser(id);
            var orderItems = orders.SelectMany(o => o.OrderItems!).ToList();

            foreach (var orderItem in orderItems)
            {
                orderItem.Product = _unitOfWork.Products.GetById(orderItem.ProductId);
            }

            return orderItems;
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
