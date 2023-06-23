using E_Commerce.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Abstract.Service
{
    public interface IOrderService : IGenericService<Order>
    {
        IEnumerable<OrderItem> GetAllProductsByUser(int id);
        void ConfirmOrderService(int orderId);
        void CancelOrderService(int orderId);
        IEnumerable<Order> GetByUserId(int userId);
    }
}
